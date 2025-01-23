using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    #region Singleton
    public static PlayerBehaviour instance;
    void Awake()
    {
        instance = this;
    }
    #endregion

    public LayerMask interactableLayer;

    [Header("Oxygen Settings")]
    [SerializeField] private float maxOxygen = 100.0f;
    [SerializeField] private float currentOxygen;
    [SerializeField] private float oxygenDepletionRate = 5.0f;
    private bool isUnderwater = true;

    [SerializeField] private Slider _slider;

    [Header("EXP Settings")]
    [SerializeField] private Slider expSlider;
    [SerializeField] private int currentExp;

    public int equipSlot;
    [SerializeField] private List<GameObject> equipmentList;

    private bool injectionIsShot;
    public GameObject injection;
    private KeyControls keyControls;
    private GameObject player;


    void Start()
    {
        player = GameObject.Find("Harry");
        keyControls = GetComponent<KeyControls>();
        injection = GameObject.Find("Injection");
        currentOxygen = maxOxygen;
        _slider.value = currentOxygen;

        expSlider.value = currentExp;

        equipSlot = 1;
        equipmentList[0].SetActive(true);
        equipmentList[1].SetActive(false);
        RefreshInjection();
    }

    void Update()
    {
        _slider.value = currentOxygen;

        if (isUnderwater)
        {
            DepleteOxygen();
        }
        SwitchEquipment();
        ShootInjection();
        CheckInjection();

        if (!injectionIsShot)
        {
            injection.transform.position = transform.position;
        }
    }

    public void AddExp(int amount)
    {
        currentExp += amount;
        expSlider.value = currentExp;
    }
    private void SwitchEquipment()
    {
        if (keyControls.SwitchEquip() && equipSlot == 1)
        {
            equipmentList[1].SetActive(true);
            equipmentList[0].SetActive(false);
            equipSlot = 2;
        }
        else if (keyControls.SwitchEquip() && equipSlot == 2)
        {
            equipmentList[1].SetActive(false);
            equipmentList[0].SetActive(true);
            equipSlot = 1;
        }
    }

    private void ShootInjection()
    {
        if (keyControls.Attack() && equipSlot == 2 && !injectionIsShot)
        {
            injection.SetActive(true);
            injectionIsShot = true;
            if(player.GetComponent<SpriteRenderer>().flipX == true)
            {
                injection.GetComponent<Rigidbody2D>().velocity = new Vector2(50f, 0);
            }
            else
            {
                injection.GetComponent<Rigidbody2D>().velocity = new Vector2(-50f, 0);
            }
        }
    }

    private void CheckInjection()
    {

        if (injectionIsShot && Vector2.Distance(transform.position, injection.transform.position) >= 100f)
        {
            RefreshInjection();
        }
    }

    public void RefreshInjection() 
    {
        injection.transform.position = transform.position;
        injectionIsShot = false;
        injection.SetActive(false);
    }

    void DepleteOxygen()
    {
        currentOxygen -= oxygenDepletionRate * Time.deltaTime;
        currentOxygen = Mathf.Clamp(currentOxygen, 0, maxOxygen);

        if (currentOxygen <= 0)
        {
            Debug.Log("Player is out of oxygen!");
            Die();
        }
    }
    public void TakeDamage(int damageAmount)
    {
        currentOxygen -= damageAmount;
        Debug.Log($"Player takes {damageAmount} damage. Current oxygen: {currentOxygen}");
    }

    public void SetOxygenLevel(int level)
    {
        switch (level)
        {
            case 1:
                oxygenDepletionRate = 0.5f;
                maxOxygen = 100.0f;
                break;
            case 2:
                oxygenDepletionRate = 0.25f;
                maxOxygen = 150.0f;
                break;
            case 3:
                oxygenDepletionRate = 0.1f;
                maxOxygen = 200.0f;
                break;
            default:
                Debug.LogWarning($"Unsupported oxygen level {level}!");
                break;
        }

        currentOxygen = maxOxygen;
    }

    void Die()
    {
        Debug.Log("Player has died.");
        SceneManager.LoadScene("OverworldScene");
    }
}

[System.Serializable]
public class Stat
{
    [SerializeField] private int baseValue = 10;
    private List<int> modifiers = new List<int>();

    public int GetValue()
    {
        int finalValue = baseValue;
        modifiers.ForEach(modifier => finalValue += modifier);
        return finalValue;
    }

    public void AddModifier(int modifier)
    {
        if (modifier != 0) modifiers.Add(modifier);
    }

    public void RemoveModifier(int modifier)
    {
        if (modifier != 0) modifiers.Remove(modifier);
    }
}
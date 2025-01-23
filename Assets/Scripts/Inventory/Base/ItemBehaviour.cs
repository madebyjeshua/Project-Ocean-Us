using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    [SerializeField] private KeyControls keyControls;
    [SerializeField] private InventoryBehaviour inventoryBehaviour;
    [SerializeField] private GameObject player;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pickUpSound;
    private int questId;

    private void Start()
    {
        player = GameObject.Find("Player");
        keyControls = FindFirstObjectByType<KeyControls>();
        inventoryBehaviour = FindFirstObjectByType<InventoryBehaviour>();
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        IQuest iQuest = GetComponent<IQuest>();
        if (iQuest != null)
        {
            questId = iQuest.SetId();
        }
        else
        {
            questId = 100;
        }
    }

    private void Update()
    {
        HoverColor();
        Pickup();
    }

    private void Pickup()
    {
        if (keyControls.PickItems() && CheckDistance())
        {
            Quest quest = FindFirstObjectByType<Quest>();

            inventoryBehaviour.PutInInventory(this.gameObject);
            quest.CheckId(this.questId);

            PlaySound(pickUpSound);
        }
    }

    private void HoverColor()
    {
        if (CheckDistance())
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    private bool CheckDistance()
    {
        PlayerData playerData = FindFirstObjectByType<PlayerData>();
        return Vector2.Distance(transform.position, player.transform.position) <= playerData.range;
    }

    private void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}

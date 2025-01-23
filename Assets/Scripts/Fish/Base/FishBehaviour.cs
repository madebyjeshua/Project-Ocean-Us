using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class FishBehaviour : MonoBehaviour
{
    [SerializeField] bool isSleeping = false;
    [SerializeField] float sleepTimer;

    [SerializeField] FishHealth fishHealth;
    [SerializeField] Transform player;
    [SerializeField] PlayerBehaviour PlayerOxygen;

    [SerializeField] float detectionRange;
    [SerializeField] bool isBigFish;
    [SerializeField] float swimSpeed;
    [SerializeField] float chaseSpeed;
    [SerializeField] int attackDamage;
    [SerializeField] float attackCooldown;
    [SerializeField] float distanceToPlayer;
    [SerializeField] float distanceToAttack;
    [SerializeField] float distanceToBeAttacked;
    [SerializeField] private float knockbackForce;
    [SerializeField] private float attackCooldownTimer;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip attackSound;
    Vector3 target;

    private KeyControls keyControls;
    private PlayerBehaviour playerBehaviour;

    void Start()
    {
        keyControls = FindFirstObjectByType<KeyControls>();
        playerBehaviour = FindFirstObjectByType<PlayerBehaviour>();
        target = transform.position;
        fishHealth = GetComponent<FishHealth>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        PlayerOxygen = FindAnyObjectByType<PlayerBehaviour>(); 
        isBigFish = gameObject.CompareTag("BigFish");
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.position);
        AttackedByPlayer();
        ShotToSleep();
        if (isSleeping)
        {
            this.GetComponent<SpriteRenderer>().color = Color.gray;

            sleepTimer -= Time.deltaTime;
            if (sleepTimer <= 0)
            {
                WakeUp();
            }
        }
        else
        {
            this.GetComponent<SpriteRenderer>().color = Color.white;
            if (player != null)
            {
                if (distanceToPlayer <= detectionRange)
                {
                    if (isBigFish)
                    {
                        AttackPlayer(distanceToPlayer);
                    }
                }
                else
                {
                    Swim();
                }
            }
            else
            {
                Swim();
            }
        }

        // Cooldown timer for attacks
        if (attackCooldownTimer > 0)
        {
            attackCooldownTimer -= Time.deltaTime;
        }
    }

    public void Sleep(float duration)
    {
        if (!isSleeping)
        {
            isSleeping = true;
            sleepTimer = duration;

            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.zero;
                rb.simulated = false; // Disable physics simulation
            }

            print($"{name} is now asleep for {duration} seconds.");
        }
    }

    private void WakeUp()
    {
        isSleeping = false;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.simulated = true;
        }

        print($"{name} has woken up!");
    }

    private void Swim()
    {
        Vector3 randomDirection = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
        if(Vector3.Distance(transform.position,target)<.1f)
        {
            target = (randomDirection * swimSpeed) +  transform.position;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, target, swimSpeed*Time.deltaTime);
        }
    }

    private void AttackPlayer(float distanceToPlayer)
    {
        if (distanceToPlayer <= distanceToAttack && attackCooldownTimer <= 0)
        {
            if (PlayerOxygen != null)
            {
                PlayerOxygen.TakeDamage(attackDamage);
                PlaySound(attackSound);
                print($"{name} attacked the player for {attackDamage} damage!");
                attackCooldownTimer = attackCooldown;

            ApplyKnockback();    

            attackCooldownTimer = attackCooldown;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, swimSpeed*Time.deltaTime);
        }
    }

    private void AttackedByPlayer()
    {
        if (isBigFish && keyControls.Attack() && distanceToPlayer <= distanceToBeAttacked && playerBehaviour.equipSlot == 1)
        {
            this.GetComponent<SpriteRenderer>().color = Color.red;
            FishHealth health = GetComponent<FishHealth>();
            PlayerData playerData = FindFirstObjectByType<PlayerData>();
            health.TakeDamage(playerData.playerSave.damage);
        }
        else
        {
            this.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    private void ShotToSleep()
    {
        if (isBigFish && Vector2.Distance(transform.position, playerBehaviour.injection.transform.position) <= 10f)
        {
            PlayerData playerData = FindFirstObjectByType<PlayerData>();
            sleepTimer = playerData.playerSave.sleepDuration;
            playerBehaviour.RefreshInjection();
            isSleeping = true;
        }
    }

    private void ApplyKnockback()
    {
        if (player.TryGetComponent<Rigidbody2D>(out Rigidbody2D playerRb))
        {
            Vector2 knockbackDirection = (player.position - transform.position).normalized;

            playerRb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
        }
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
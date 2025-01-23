using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference _inputActionReference;
    [SerializeField] private float speed;
    [SerializeField] Animator playerAnimator;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip movementSound;

    private bool isMoving = false;

    private void OnEnable()
    {
        _inputActionReference.action.Enable();
    }

    private void OnDisable()
    {
        _inputActionReference.action.Disable();
    }

    private void HandlePlayerMovement()
    {
        Vector3 movement = _inputActionReference.action.ReadValue<Vector2>();

        playerAnimator.SetFloat("Speed", movement.magnitude);
        transform.position += (movement  * speed) * Time.deltaTime;
        if (movement.x < 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (movement.x > 0)
        {
            spriteRenderer.flipX = true;
        }

        if (movement.magnitude > 0 && !isMoving)
        {
            StartMovingSound();
        }
        else if (movement.magnitude == 0 && isMoving)
        {
            StopMovingSound();
        }
    }

    private void StartMovingSound()
    {
        if (audioSource != null && movementSound != null)
        {
            audioSource.clip = movementSound;
            audioSource.loop = true; // Loop the sound while moving
            audioSource.Play();
            isMoving = true;
        }
    }

    private void StopMovingSound()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
            isMoving = false;
        }
    }

    void Update()
    {
        HandlePlayerMovement();
    }
}

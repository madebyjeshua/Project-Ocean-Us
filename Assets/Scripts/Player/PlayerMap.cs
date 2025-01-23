using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMap : MonoBehaviour
{
    [SerializeField] private float speed;
    private void HandlePlayerMovement()
    {
        Transform player = GameObject.Find("Player").GetComponent<Transform>();
        transform.position = new Vector2((player.position.x-100)/5f + 1590, (player.position.y-30)/7.27f + 1024);
    }

    void Update()
    {
        HandlePlayerMovement();
    }
}

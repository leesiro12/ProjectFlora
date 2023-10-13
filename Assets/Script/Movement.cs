using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpForce = 5f;
    float playerDir = 0f;
    PlayerActions playerActions;
    public float movementSpeed = 3f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        playerActions = new PlayerActions();
        playerActions.Enable();     //enabling input system
        playerActions.Player.Move.performed += moving =>
        {

        };

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Move()
    {
        rb.velocity = new Vector2(playerDir * movementSpeed, rb.velocity.y);
    }
    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log("Jump: " + context.phase);
        rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
    }
}

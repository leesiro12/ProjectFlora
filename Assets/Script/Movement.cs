using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpForce = 5f;
    Vector2 playerDir = Vector2.zero;
    public ProjectFloraInputs playerController;
    InputAction playerMove;
    InputAction playerJump;
    public float movementSpeed = 3f;

    private void Awake()
    {
        playerController = new ProjectFloraInputs();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        playerMove = playerController.Player.Move;
        playerMove.Enable();

        playerJump = playerController.Player.Move;
        playerJump.Enable();
        playerJump.performed += Jump;
    }
    private void OnDisable()
    {
        playerMove.Disable();
        playerJump.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        playerDir = playerMove.ReadValue<Vector2>();
        Move();
    }
    public void Move()
    {
        rb.velocity = new Vector2(playerDir.x * movementSpeed, rb.velocity.y);
    }
    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log("Jump: " + context.phase);
        rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
    }
}

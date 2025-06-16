using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Controlls movement
    [SerializeField]
    private float moveSpeed;
    private Vector2 moveVector;

    //Controlls jumping
    [SerializeField]
    private float jumpPower;
    public bool isGrounded;

    private Rigidbody playerRB;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MovePlayerCalculation();
    }

    public void MovePlayer(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
    }

    private void MovePlayerCalculation()
    {
        if (moveVector.x > 0)
        {
            Debug.Log("Moving right");
            playerRB.AddForce(transform.right * moveSpeed);
            //playerRB.linearVelocity = transform.right * moveSpeed;
        }

        if (moveVector.x < 0)
        {
            Debug.Log("Moving left");
            playerRB.AddForce(transform.right * -moveSpeed);
            //playerRB.linearVelocity = transform.right * -moveSpeed;
        }
    }

    public void JumpPlayer(InputAction.CallbackContext context)
    {
        if (!isGrounded)
        {
            return;
        }
        if (isGrounded)
        {
            playerRB.AddForce(transform.up * jumpPower);
            //playerRB.linearVelocity = transform.up * jumpPower;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}

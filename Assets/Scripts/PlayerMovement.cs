using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;
    [SerializeField]
    Transform orientation;
    [SerializeField]
    float speed;

    // ground check support
    [SerializeField]
    float playerHeight;
    [SerializeField]
    LayerMask ground;
    bool grounded;
    [SerializeField]
    float groundDrag;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        // ground check raycast with max distance(half the player height + 0.2 buffer)
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight
            * 0.5f + 0.2f, ground);

        GetInput();
        ControlSpeed();

        // apply drag to player velocity to control it
        CheckGround(grounded);
    }

    void FixedUpdate()
    {
        // move player in fixed update for a better movement performance
        MovePlayer();
    }

    void GetInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }
    void MovePlayer()
    {
        // the direction your are looking at
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * speed, ForceMode.Force);
    }

    void CheckGround(bool grounded)
    {
        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }
    void ControlSpeed()
    {
        // limit the speed
        Vector3 currentVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (currentVelocity.magnitude > speed)
        {

            Vector3 limitedVelocity = currentVelocity.normalized * speed;
            rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
        }
    }


}

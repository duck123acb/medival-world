using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // components
    [SerializeField]
    Camera mainCamera;
    Rigidbody rb;

    // movement
    [SerializeField]
    float speed, jumpHeight;
    bool toJump, touchingGround;
    Vector2 movement;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Jump();
    }

    void FixedUpdate()
    {
        MoveCharacter(movement);
        if (toJump && touchingGround)
        {
            touchingGround = false;
            toJump = false;
            rb.AddForce(new Vector3(0, jumpHeight), ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) touchingGround = true;
    }

    void MoveCharacter(Vector2 direction)
    {
        rb.MovePosition(transform.position + (direction.y * speed * Time.deltaTime * transform.forward) + (direction.x * speed * Time.deltaTime * transform.right));
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && touchingGround)
        {
            toJump = true;
        }
    }
}
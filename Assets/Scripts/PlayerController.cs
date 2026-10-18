using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private float moveInput;
    private GameStateManager gameStateManager;
    public bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameStateManager = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();
        
    }

    private void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * 5, rb.linearVelocity.y);
        //if (Input.GetKey(KeyCode.A))
        //{
        //    rb.linearVelocity = new Vector2(moveInput * 5, rb.linearVelocity.y);
        //    //rb.MovePosition(rb.position + (Vector2.left * 0.3f) + rb.totalForce);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    rb.linearVelocity = new Vector2(1 * 5, rb.linearVelocity.y);
        //    //rb.MovePosition(rb.position + (Vector2.right * 0.3f) + rb.totalForce);
        //}
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            gameStateManager.TogglePause();
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(Vector2.up * 500);
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D contact = collision.GetContact(0);

        float hitAngle = Vector2.Angle(Vector2.up, contact.normal);

        if(hitAngle < 80)
        {
            isGrounded = true;
        }
        
        
    }
}

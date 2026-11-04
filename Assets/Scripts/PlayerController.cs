using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private float moveInput;
    private GameStateManager gameStateManager;
    private UiManager uiManager;
    public bool isGrounded;
    private int direction;

    private RaycastHit2D hit;
    private RaycastHit2D groundDetected;
    public LayerMask targetlayer;
    public LayerMask groundLayer;

    public GameObject Door;
    public GameObject Button;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameStateManager = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();
        uiManager = GameObject.Find("UiManager").GetComponent<UiManager>();
    }

    private void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * 5, rb.linearVelocity.y);
        
        if (Input.GetKey(KeyCode.A))
        {
            direction = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction = 1; 
        }

        hit = Physics2D.Raycast(transform.position, new Vector2(direction * 2, 0), 2, targetlayer);
        groundDetected = Physics2D.Raycast(transform.position, Vector2.down, 1, groundLayer);
        Debug.DrawRay(transform.position, Vector2.down, Color.red);
        Debug.DrawRay(transform.position, new Vector2(direction * 2, 0), Color.red);

        if (hit.collider != null)
        {
            uiManager.ShowInteractionUI();
            if (Input.GetKeyDown(KeyCode.E))
            {
                Button.transform.localScale.Set(0.5f, 0.76f, 1f);
                Destroy(Door.gameObject);
            }
        }
        else uiManager.HideInteractionU();

        if (groundDetected.collider != null)
        {
            Debug.Log("is grounded");
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameStateManager.TogglePause();
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(Vector2.up * 500);
        }
    }

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (hit.collider != null)
    //    {
    //        uiManager.ShowInteractionUI();
    //    }
    //    else uiManager.HideInteractionU();
    //}
    private void OnCollisionExit2D(Collision2D collision)
    {
        

    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    ContactPoint2D contact = collision.GetContact(0);

    //    float hitAngle = Vector2.Angle(Vector2.up, contact.normal);

    //    if(hitAngle < 80)
    //    {
    //        isGrounded = true;
    //    }
        
        
    //}

}

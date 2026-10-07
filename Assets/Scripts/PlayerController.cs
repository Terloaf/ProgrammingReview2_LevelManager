using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.MovePosition(rb.position + (Vector2.left * 0.3f));
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.MovePosition(rb.position + (Vector2.right * 0.3f));
        }

    }

}

using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isJumped;
    private float y;
    private Rigidbody2D rb;
    private int jumpForce;

    private void OnEnable()
    {
        Messenger.AddListener(EventKey.SETPARENTNULL, SetParentNull);
    }

    private void OnDisable()
    {
        Messenger.RemoveListener(EventKey.SETPARENTNULL, SetParentNull); // Always remember to remove this listener
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        isJumped = false;
        jumpForce = 2;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
            transform.SetParent(null);
            isJumped = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Base"))
        {
            float distance = transform.position.y - CameraController.instance.transform.position.y;
            if (distance < -3f)
                Generator.instance.steps = true;
            Generator.instance.Generate();
            CameraController.instance.Move();
            GameController.instance.ShowScore(distance);
            transform.parent = collision.transform;
        }

        if (collision.gameObject.CompareTag("EndGame"))
        {
            GameController.instance.EndGame();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Base") && isJumped)
        {
            collision.collider.isTrigger = true;
            isJumped = false;
        }
    }

    public void SetParentNull()
    {
        transform.SetParent(null);
    }
}
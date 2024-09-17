using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isJumped;
    private float y;
    private Rigidbody2D rb;
    private int jumpForce;
    private Animator anim;

    private void OnEnable()
    {
        Messenger.AddListener(EventKey.SETPARENTNULL, SetParentNull); //Tên sự kiện sai convention,khó nhìn
    }

    private void OnDisable()
    {
        Messenger.RemoveListener(EventKey.SETPARENTNULL, SetParentNull); // Always remember to remove this listener
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
            SetParentNull();
            isJumped = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Base"))
        {
            float distance = transform.position.y - CameraController.instance.transform.position.y;
            if (distance < -3f)
                Base_WallGenerate.instance.steps = true;
            Base_WallGenerate.instance.Generate();
            CameraController.instance.Move();
            GameController.instance.ShowScore(distance);
            transform.parent = collision.transform;
            anim.SetBool("Jump", false);
        }

        if (collision.gameObject.CompareTag("EndGame")) // sửa lại Tag nhé,tên chưa phù hợp
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
        anim.SetBool("Jump", true);
    }
}
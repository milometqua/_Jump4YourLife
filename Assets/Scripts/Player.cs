using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isJumped;
    private bool canJump;
    private float y;
    private Rigidbody2D rb;
    private int jumpForce;
    private Animator anim;

    private void OnEnable()
    {
        Messenger.AddListener(EventKey.SetParentNull, SetParentNull);
    }

    private void OnDisable()
    {
        Messenger.RemoveListener(EventKey.SetParentNull, SetParentNull);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        isJumped = false;
        canJump = true;
        jumpForce = 2;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && canJump)
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
            canJump = true;
            float distance = transform.position.y - CameraController.instance.transform.position.y;
            if (distance < -3f)
            {
                Base_WallGenerate.instance.steps = true;
                ScoreManager.AddScore(2);
            }
            else ScoreManager.AddScore(1);
            Base_WallGenerate.instance.Generate();
            CameraController.instance.Move();
            //GameController.instance.ShowScore(distance);
            transform.parent = collision.transform;
            anim.SetBool("Jump", false);
        }

        if (collision.gameObject.CompareTag("DeadLimit"))
        {
            GameController.Instance.EndGame();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Base") && isJumped)
        {
            collision.collider.isTrigger = true;
            isJumped = false;
            canJump = false;
        }
    }

    public void SetParentNull()
    {
        transform.SetParent(null);
        canJump = false;
        anim.SetBool("Jump", true);
    }
}
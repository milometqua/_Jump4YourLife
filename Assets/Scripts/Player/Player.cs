using Common;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isJumped;
    private bool canJump;
    private bool perfect;
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
        perfect = false;
        GameController.Instance.OnTap();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && canJump && !UIHelper.IsMouseOverUI())
        {
            GameController.Instance.OffTap();
            AudioManager.Instance.PlaySFX(AudioManager.Instance.jump);
            rb.velocity = Vector2.up * jumpForce;
            SetParentNull();
            isJumped = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Base"))
        {
            Debug.Log(transform.position.y);
            canJump = true;
            float distance = transform.position.y - CameraController.instance.transform.position.y;
            //Debug.Log(distance);
            if (distance < -3f)
            {
                Base_WallGenerate.instance.steps = true;
                if (perfect)
                {
                    ScoreManager.AddScore(4);
                    GameController.Instance.OnPerfect();
                }
                else ScoreManager.AddScore(2);
            }
            else
            {
                if (perfect)
                {
                    ScoreManager.AddScore(2);
                    GameController.Instance.OnPerfect();
                }
                else ScoreManager.AddScore(1);
            }
            Base_WallGenerate.instance.Generate();
            CameraController.instance.Move(transform.position.y);
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
        if ((collision.gameObject.CompareTag("Base")|| collision.gameObject.CompareTag("FirstBase")) && isJumped)
        {
            collision.collider.isTrigger = true;
            isJumped = false;
            canJump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        perfect = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        perfect = false;
        GameController.Instance.OffPerfect();
    }
    public void SetParentNull()
    {
        transform.SetParent(null);
        canJump = false;
        anim.SetBool("Jump", true) ;
        Debug.Log(anim.GetBool("Jump"));
    }
}
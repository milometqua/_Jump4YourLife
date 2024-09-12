using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Sprite breakIce;
    [SerializeField] private Sprite Ice;
    private Vector3 director;
    private Camera mainCamera;
    private float limitX;
    private bool canBreak;
    private int touch = 0;
    private GameObject spriteBreakIce;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        mainCamera = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        director = Vector3.right;
        limitX = 1.36f;
        canBreak = false;
    }

    private void Update()
    {
        Move();
        float x = transform.position.x;
        if (x >= limitX)
            director = Vector3.left;
        else if (x <= limitX * (-1f))
            director = Vector3.right;
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);
        if (viewportPosition.y > 1f)
        {
            boxCollider.isTrigger = false;
            spriteRenderer.sprite = Ice;
            gameObject.SetActive(false);
        }
    }

    private void Move()
    {
        transform.position += director * speed * Time.deltaTime;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            canBreak = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("WallLeft") || collision.gameObject.CompareTag("WallRight"))
        {
            if (canBreak)
            {
                touch++;
            }

            if (touch == 1)
            {
                spriteRenderer.sprite = breakIce;
            }
            else if (touch == 2)
            {
                boxCollider.isTrigger = true;
                Messenger.Broadcast(EventKey.SETPARENTNULL);
                spriteRenderer.sprite = null;
            }
        }
    }
}
using System;
using UnityEditor.Timeline;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Sprite breakIce;
    [SerializeField] private Sprite Ice;
    [SerializeField] private float invisibleSpeed;

    private Vector3 director;
    private Camera mainCamera;
    private float limitX;
    private bool canBreak;
    private int isTouch = 0;
    private GameObject spriteBreakIce;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    private float angle = 0f;
    private bool isUp = true;
    private int type = 0;

    private void Awake()
    {
        mainCamera = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        int id = PlayerPrefs.GetInt("BackgroundId");
        breakIce = Resources.Load<BackgroundInfos>("Backgrounds/" + id).BreakBases;
        Ice = Resources.Load<BackgroundInfos>("Backgrounds/" + id).Bases;
        speed = 2f;
        int randomValue = UnityEngine.Random.Range(0, 2);
        if (randomValue == 0)
        {
            director = Vector3.left;
        }
        else
            director = Vector3.right;
        //director = Random.Range(Vector3.left, Vector3.right);
        limitX = 1.36f;
        canBreak = false;
        KindOfBase();
        /*if (ScoreManager.Score > 10)
        {
            Debug.Log("Randommm");
            KindOfBase();
        }*/
    }

    private void Update()
    {
        Normal();
        if (type == 3)
            GoDiagonal();
        else if (type == 2)
            limitX = 1.53f;
        else if (type == 4)
            Blur();
        if (transform.position.x <= -limitX || transform.position.x >= limitX)
        {
            if (transform.position.x <= -limitX)
            {
                transform.position = new Vector3(-limitX, transform.position.y, transform.position.z);
                director = Vector3.right;
            }
            else if (transform.position.x >= limitX)
            {
                transform.position = new Vector3(limitX, transform.position.y, transform.position.z);
                director = Vector3.left;
            }
            isUp = !isUp;
        }
        /*float x = transform.position.x;
        if (x >= limitX)
        {
            Debug.Log(x);
            transform.position = new Vector3(x, transform.position.y, 0);
            if (type == 3)
            {
                isUp = !isUp;
            }
            director = Vector3.left;
        }
        else if (x <= -limitX)
        {
            Debug.Log(x);
            transform.position = new Vector3(x, transform.position.y, 0);
            if (type == 3)
            {
                isUp = !isUp;
            }
            director = Vector3.right;
        }*/
        Reset();
    }

    private void Reset()
    {
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);
        if (viewportPosition.y > 1f)
        {
            boxCollider.isTrigger = false;
            spriteRenderer.sprite = Ice;
            gameObject.SetActive(false);
            transform.localScale = Vector3.one;
            angle = 0f;
            KindOfBase();
            Color color = spriteRenderer.color;
            color.a = 1f;
            spriteRenderer.color = color;
            invisibleSpeed = Math.Abs(invisibleSpeed);
        }
    }

    private void Normal()
    {
        transform.position += director * speed * Time.deltaTime;
    }

    private void GoDiagonal()
    {
        if (isUp)
            transform.position += angle * Vector3.up * Time.deltaTime;
        else
            transform.position += angle * Vector3.down * Time.deltaTime;
        float x = transform.position.x;
        /*if (x >= limitX || x <= -limitX)
        {
            isUp = !isUp;
        }*/
    }
    private void Blur()
    {
        Color color = spriteRenderer.color;
        if (spriteRenderer.color.a >= 1f)
        {
            Color tmp = spriteRenderer.color;
            tmp.a = 1f;
            spriteRenderer.color = tmp;
            invisibleSpeed = -Math.Abs(invisibleSpeed);
        }
        else if (spriteRenderer.color.a <= 0f)
        {
            Color tmp = spriteRenderer.color;
            tmp.a = 0f;
            spriteRenderer.color = tmp;
            invisibleSpeed = Math.Abs(invisibleSpeed);
        }
        color.a += invisibleSpeed * Time.deltaTime;
        spriteRenderer.color = color;
    }
    private void KindOfBase()
    {
        type = UnityEngine.Random.Range(0, 5);
        if (type == 0)
        {
            Debug.Log("normal");
        }
        else if (type == 1)
        {
            Debug.Log("fast");
            speed = 2.5f;
        } 
        else if(type == 2)
        {
            Debug.Log("small");
            transform.localScale = new Vector3(0.8f, 1f, 1f);
        }
        else if(type == 3)
        {
            angle = 0.6f;
            Debug.Log("diagonal");
        }
        else
        {
            Debug.Log("invisible");
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Vua cham");
        if (collision.gameObject.CompareTag("Player"))
            canBreak = true;
    }

    /*private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log(type);
        Debug.Log(spriteRenderer.color.a);
    }*/
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTouch = 0;
            canBreak = false;
        }
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("WallLeft") || collision.gameObject.CompareTag("WallRight"))
        {
            if (canBreak)
            {
                isTouch++;
            }
            if (isTouch == 1)
            {
                AudioManager.Instance.PlaySFX(AudioManager.Instance.breakSound);
                spriteRenderer.sprite = breakIce;
            }
            else if (isTouch == 2)
            {
                AudioManager.Instance.PlaySFX(AudioManager.Instance.breakSound);
                boxCollider.isTrigger = true;
                Messenger.Broadcast(EventKey.SetParentNull);
                spriteRenderer.sprite = null;
                canBreak = false;
                isTouch = 0;
            }
        }
    }
}
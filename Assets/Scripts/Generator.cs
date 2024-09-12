using UnityEngine;

public class Generator : MonoBehaviour
{
    public static Generator instance;
    
    [SerializeField] private GameObject basePrefab;
    [SerializeField] private GameObject WallLeft;
    [SerializeField] private GameObject WallRight;
    
    private int amount;
    private float firstPosY;
    private GameObject finalBase;
    public float finalWallY;
    public int check;
    public bool steps;
    private float y;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        steps = false;
        y = 2.08f;
        firstPosY = 3f;
        amount = 3;
        check = 0;
        Init();
    }

    private void Init()
    {
        for (int i = 0; i < amount; i++)
        {
            Instantiate(WallLeft, new Vector3(2.23f, firstPosY, 0f), new Quaternion(0, 180, 0, 0));
            Instantiate(WallRight, new Vector3(-2.23f, firstPosY, 0f), Quaternion.identity);
            firstPosY -= 10.41f;
            if (i == amount - 1)
            {
                finalWallY = firstPosY;
            }
        }

        for (int i = 0; i < 10; i++)
        {
            GameObject obj = PoolBase.Instance.GetPool();
            obj.transform.position = new Vector3(Random.Range(-1.36f, 1.36f), y -= 3.2f, 0);
            obj.transform.rotation = Quaternion.identity;
            if (i == 9) finalBase = obj;
        }
    }

    public void Generate()
    {
        GameObject obj = PoolBase.Instance.GetPool();
        float finalY = finalBase.transform.position.y;
        obj.transform.position = new Vector3(Random.Range(-1.36f, 1.36f), finalY -= 3.2f, 0);
        obj.transform.rotation = Quaternion.identity;
        if (steps)
        {
            GameObject gameObject2 = PoolBase.Instance.GetPool();
            finalY = finalBase.transform.position.y;
            obj.transform.position = new Vector3(Random.Range(-1.36f, 1.36f), finalY -= 3.2f, 0);
            obj.transform.rotation = Quaternion.identity;
            finalBase = gameObject2;
            steps = false;
        }
        else finalBase = obj;
    }
}
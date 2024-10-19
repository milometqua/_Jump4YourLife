using UnityEngine;

public class Base_WallGenerate : MonoBehaviour
{
    public static Base_WallGenerate instance;
    [SerializeField] private GameObject basePrefab;
    [SerializeField] private GameObject WallLeft;
    [SerializeField] private GameObject WallRight;
    
    private int amountWall; 
    private float firstPosY;
    private GameObject finalBase;
    public float finalWallY;
    public int numWallOutCam;
    public bool steps;
    private float posY_Base;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        Debug.Log("Sinh base");
        int id = PlayerPrefs.GetInt("BackgroundId");
        Debug.Log(id);
        basePrefab.GetComponent<SpriteRenderer>().sprite = Resources.Load<BackgroundInfos>("Backgrounds/" + id).Bases;
        steps = false;
        posY_Base = 2.08f;
        firstPosY = 3f;
        amountWall = 3;
        numWallOutCam = 0;
        Init();
    }

    private void Init()
    {
        for (int i = 0; i < amountWall; i++)
        {
            Instantiate(WallRight, new Vector3(2.23f, firstPosY, 0f), new Quaternion(0, 180, 0, 0));
            Instantiate(WallLeft, new Vector3(-2.23f, firstPosY, 0f), Quaternion.identity);
            firstPosY -= 10.41f;
            if (i == amountWall - 1)
            {
                finalWallY = firstPosY;
            }
        }

        for (int i = 0; i < 10; i++)
        {
            GameObject obj = PoolBase.Instance.GetPool();
            obj.transform.position = new Vector3(Random.Range(-1.36f, 1.36f), posY_Base -= 3.2f, 0);
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
        finalBase = obj;
        if (steps)
        {
            GameObject gameObject2 = PoolBase.Instance.GetPool();
            finalY = finalBase.transform.position.y;
            gameObject2.transform.position = new Vector3(Random.Range(-1.36f, 1.36f), finalY -= 3.2f, 0);
            gameObject2.transform.rotation = Quaternion.identity;
            finalBase = gameObject2;
            steps = false;
        }
    }
}
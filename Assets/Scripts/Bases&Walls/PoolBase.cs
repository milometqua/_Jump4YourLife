using System.Collections.Generic;
using UnityEngine;

public class PoolBase : MonoBehaviour
{
    public static PoolBase Instance;

    [SerializeField] private GameObject Base;

    private List<GameObject> basePool = new List<GameObject>();
    private int amount = 10;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        int id = PlayerPrefs.GetInt("BackgroundId");
        Base.GetComponent<SpriteRenderer>().sprite = Resources.Load<BackgroundInfos>("Backgrounds/" + id).Bases;
        Init();

    }

    private void Init()
    {
        for (int i = 0; i <= amount; i++)
        {
            GameObject obj = Instantiate(Base);
            obj.SetActive(false);
            basePool.Add(obj);
        }
    }

    public GameObject GetPool()
    {
        for (int i = 0; i <= amount; i++)
        {
            if (!basePool[i].activeInHierarchy)
            {
                basePool[i].SetActive(true);
                return basePool[i];
            }
        }

        GameObject obj = Instantiate(Base);
        basePool.Add(obj);
        amount++;
        return obj;
    }
}
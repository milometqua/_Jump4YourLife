using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolBase : MonoBehaviour
{
    public static PoolBase Instance;
    private List<GameObject> basePool = new List<GameObject>();
    private int ammount = 10;
    [SerializeField] private GameObject Base;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        Init();
    }
    private void Init()
    {
        for (int i = 0; i <= ammount; i++)
        {
            GameObject gameObject = Instantiate(Base);
            gameObject.SetActive(false);
            basePool.Add(gameObject);
        }
    }

    public GameObject GetPool()
    {
        for (int i = 0; i <= ammount; i++)
        {
            if (!basePool[i].activeInHierarchy)
            {
                basePool[i].SetActive(true);
                return basePool[i];
            }
        }
        GameObject gameObject = Instantiate(Base);
        basePool.Add(gameObject);
        ammount++;
        return gameObject;
    }
}

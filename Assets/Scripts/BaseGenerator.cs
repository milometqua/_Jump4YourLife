using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGenerator : MonoBehaviour
{
    [SerializeField] private GameObject basePrefab;
    public bool enableGenerateBase;
    private float countdown;
    public float timeDuration;
    float y, k;

    private void Start()
    {
        enableGenerateBase = true;
        countdown = 0.5f;
        y = 1.92f;
        StartCoroutine(Init());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator Init()
    {
        for(int i = 0; i < 10; i++)
        {
            GameObject gameObject = PoolBase.Instance.GetPool();
            gameObject.transform.position = new Vector3(0f, y -= 2.91f, 0);
            gameObject.transform.rotation = Quaternion.identity;
            yield return new WaitForSeconds(0.5f);
        }
    }
}

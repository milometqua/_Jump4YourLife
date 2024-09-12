using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    private float smooth;
    private float range;
    [SerializeField]private GameObject Player;
    private float playerPos_y;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void Move()
    {
        playerPos_y = Player.GetComponent<Player>().transform.position.y;
        range = transform.position.y;
        StartCoroutine(Smooth());
    }
    IEnumerator Smooth()
    {
        while (transform.position.y > playerPos_y-3f)
        {
            transform.position = new Vector3(0, range-=0.2f, -10);
            yield return new WaitForSeconds(0.01f);
        }
    }
}

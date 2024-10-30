using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    //private GameObject Player;

    private float smooth;
    private float range;
    private float playerPos_y;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Move(float posY)
    {
        playerPos_y = posY;
        Debug.Log(playerPos_y);
        range = transform.position.y;
        StartCoroutine(MoveSmooth());
    }

    IEnumerator MoveSmooth()
    {
        while (transform.position.y > playerPos_y - 3f)
        {
            transform.position = new Vector3(0, range -= 0.2f, -10);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
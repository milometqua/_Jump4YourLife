using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    [SerializeField] private GameObject Player;

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

    public void Move()
    {
        playerPos_y = Player.GetComponent<Player>().transform.position.y;
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
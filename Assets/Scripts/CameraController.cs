using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    private float smooth;
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
        transform.position = new Vector3(0, playerPos_y - 3, -10);
    }
}

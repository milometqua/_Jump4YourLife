using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField] private GameObject BaseGenerate;
    private float posY;
    private void Awake()
    {
        mainCamera = Camera.main;
    }
    void Update()
    {
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);
        if (viewportPosition.y > 1.8f)
        {
            posY = Generator.instance.finalWallY;
            //Debug.Log(posY);
            if (gameObject.CompareTag("WallLeft"))
            {
                Generator.instance.check++;
                transform.position = new Vector3(2.23f, posY, 0f);
            }

            if (gameObject.CompareTag("WallRight"))
            {
                Generator.instance.check++;
                transform.position = new Vector3(-2.23f, posY, 0f);
            }

            if(Generator.instance.check == 2)
            {
                Generator.instance.finalWallY = posY - 10.41f;
                Generator.instance.check = 0;
            }
        }
    }
}

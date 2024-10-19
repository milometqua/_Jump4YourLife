using UnityEngine;

public class WallMovement : MonoBehaviour
{
    [SerializeField] private GameObject BaseGenerate;
    
    private Camera mainCamera;
    private float posY;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);
        if (viewportPosition.y > 2.0f)
        {
            posY = Base_WallGenerate.instance.finalWallY;
            if (gameObject.CompareTag("WallRight"))
            {
                Base_WallGenerate.instance.numWallOutCam++;
                transform.position = new Vector3(2.23f, posY, 0f);
            }

            if (gameObject.CompareTag("WallLeft"))
            {
                Base_WallGenerate.instance.numWallOutCam++;
                transform.position = new Vector3(-2.23f, posY, 0f);
            }

            if (Base_WallGenerate.instance.numWallOutCam == 2)
            {
                Base_WallGenerate.instance.finalWallY = posY - 10.41f;
                Base_WallGenerate.instance.numWallOutCam = 0;
            }
        }
    }
}
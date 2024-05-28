using UnityEngine;

public class AsteroidOffScreen : MonoBehaviour
{
    private Camera mainCamera;
    private bool isOffScreen;
    private float offScreenTime;
    private float offScreenDuration = 5f;

    void Start()
    {
        mainCamera = Camera.main;
        isOffScreen = false;
        offScreenTime = 0f;
    }

    void Update()
    {
        Vector3 screenPosition = mainCamera.WorldToViewportPoint(transform.position);

        if (screenPosition.x < 0 || screenPosition.x > 1 || screenPosition.y < 0 || screenPosition.y > 1)
        {
            if (!isOffScreen)
            {
                isOffScreen = true;
                offScreenTime = Time.time;
            }
            else if (Time.time - offScreenTime > offScreenDuration)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            isOffScreen = false;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FovChanger : MonoBehaviour
{
    float durationInSeconds = 7f;
    float durationInSecondsReturn = 8f;

    float currentTimeChangeFov;
    float currentTimeReturnFov;

    public static bool ShouldEngageFovChange = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ChangeFov();
        }

        FogManager();

    }

    void FogManager()
    {
        if (ShouldEngageFovChange)
        {
            currentTimeReturnFov = 0f;

            ChangeFov();
        }
        else
        {
            currentTimeChangeFov = 0f;

            ReturnFog();
        }
    }
    void ChangeFov()
    {
        currentTimeChangeFov += Time.deltaTime / durationInSeconds;
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 85, currentTimeChangeFov);
    }

    void ReturnFog()
    {
        currentTimeReturnFov += Time.deltaTime / durationInSecondsReturn;
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 63, currentTimeReturnFov);
    }

}

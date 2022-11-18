using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public static float Intentos, Aciertos;

    public static bool PlayerCurrentlyInPlatform = true;
    float outsidePlatformCounter;

    PlayerFallsAndRelocates playerFallsAndRelocates;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerCurrentlyInPlatform)
        {
            outsidePlatformCounter += Time.deltaTime;

            if (outsidePlatformCounter>6f)
            {
                //go back 2 prev platform
                playerFallsAndRelocates.GoBackToPreviousPlatform();
            }
        }
        else
        {
            outsidePlatformCounter = 0f;
        }
        
    }
}

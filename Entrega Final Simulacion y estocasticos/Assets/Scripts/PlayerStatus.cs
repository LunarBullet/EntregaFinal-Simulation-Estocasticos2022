using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStatus : MonoBehaviour
{
    public float Fallos = 0f;
    public float Aciertos = 0f;
    public float Collectables = 0f;

    [SerializeField] TMP_Text fallosText, aciertosText, collectablesText;

    public static bool PlayerCurrentlyInPlatform = true;
    float outsidePlatformCounter;

    PlayerFallsAndRelocates playerFallsAndRelocates;

    // Start is called before the first frame update
    void Start()
    {
        fallosText = GameObject.Find("Fallos").GetComponent<TextMeshProUGUI>();
        aciertosText = GameObject.Find("Aciertos").GetComponent<TextMeshProUGUI>();
        collectablesText = GameObject.Find("Collectables").GetComponent<TextMeshProUGUI>();
        playerFallsAndRelocates = GetComponent<PlayerFallsAndRelocates>();
    }

    // Update is called once per frame
    void Update()
    {
        fallosText.text = "Fallos: " + Fallos;
        aciertosText.text = "Aciertos: " + Aciertos;
        collectablesText.text = "Coleccionables: " + Collectables;


        if (!PlayerCurrentlyInPlatform)
        {
            outsidePlatformCounter += Time.deltaTime;

            if (outsidePlatformCounter>3f)
            {
                //go back 2 prev platform
                playerFallsAndRelocates.GoBackToPreviousPlatform();
                Fallos++;
                PlayerCurrentlyInPlatform = true;

            }
        }
        else
        {
            outsidePlatformCounter = 0f;
        }
        
    }

    public void AddCollectable()
    {
        Collectables++;
    }
}

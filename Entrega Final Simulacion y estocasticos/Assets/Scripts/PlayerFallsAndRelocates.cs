using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallsAndRelocates : MonoBehaviour
{
    [SerializeField] public GameObject LastTouchedPlatform;
    [SerializeField] GameObject player;
    Rigidbody playerRigidbody;

    private void Start()
    {
        player = GameObject.Find("Player");
        playerRigidbody = player.GetComponent<Rigidbody>();

    }
    private void Update()
    {
        
    }

    public void GoBackToPreviousPlatform()
    {
        player.transform.localPosition = LastTouchedPlatform.transform.localPosition + new Vector3(0, 0.75f, 0); //offset
        playerRigidbody.velocity = Vector3.zero;
        Debug.Log("Going back to previous platform");
    }

}

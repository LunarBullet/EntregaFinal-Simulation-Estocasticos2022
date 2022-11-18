using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayOnPlatform : MonoBehaviour
{
    PlayerFallsAndRelocates playerFallsAndRelocates;
    PlayerStatus playerStatus;
    [SerializeField] ParticleSystem particleSystem;
    private void Start()
    {
        playerFallsAndRelocates = GameObject.Find("Player").GetComponent<PlayerFallsAndRelocates>();
        playerStatus = GameObject.Find("Player").GetComponent<PlayerStatus>();

    }
    // Update is called once per frame
    void Update()
    {

    }

    void IfPlayerTouchesPlatform()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.localPosition = this.transform.localPosition + new Vector3(0, 0.75f, 0); //offset
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

            Debug.Log("Player entered area");
            playerFallsAndRelocates.LastTouchedPlatform = this.gameObject;
            PlayerStatus.PlayerCurrentlyInPlatform = true;
            playerStatus.Aciertos++;
            particleSystem.Play();
            this.GetComponent<Collider>().enabled = false;


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerStatus.PlayerCurrentlyInPlatform = false;

        }

    }
}

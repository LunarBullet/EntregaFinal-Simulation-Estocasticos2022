using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] ParticleSystem particleSystem;
    MeshRenderer meshRenderer;
    Collider collider;

    PlayerFallsAndRelocates playerFallsAndRelocates;
    Rigidbody playerRigidbody;

    PlayerStatus playerStatus;
    

    // Start is called before the first frame update
    void Start()
    {
        playerFallsAndRelocates = GameObject.Find("Player").GetComponent<PlayerFallsAndRelocates>();
        playerRigidbody = GameObject.Find("Player").GetComponent<Rigidbody>();

        meshRenderer = GetComponent<MeshRenderer>();
        collider = GetComponent<Collider>();

        playerStatus = GameObject.Find("Player").GetComponent<PlayerStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerStatus.Fallos++;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.localPosition = this.transform.localPosition + new Vector3(0, 0.75f, 0); //offset
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Debug.Log("Player entered area");
            particleSystem.Play();
            StartCoroutine(StartFallingPlatform());

        }
    }

    IEnumerator StartFallingPlatform()
    {
        yield return new WaitForSeconds(2f); //delay time before platform is destroyed
        DestroyPlatform();
        //start platform shake 
        //then destroy platform

         yield return new WaitForSeconds(1.8f); //time for platform falling animation and then restarting the platform

         yield return new WaitForSeconds(0.2f); //time for platform falling animation and then restarting the platform
        GoBackToThePreviousPlatform();

        yield return new WaitForSeconds(.5f);

        RestartPlatform();

    }

    void RestartPlatform()
    {
        playerRigidbody.useGravity = false;
        meshRenderer.enabled = true;
        collider.enabled = true;

        Debug.Log("Restarting platform");
    }

    void DestroyPlatform()
    {
        playerRigidbody.useGravity = true;
        meshRenderer.enabled = false;
        collider.enabled = false;
    }

    void GoBackToThePreviousPlatform()
    {
        playerRigidbody.useGravity = false;
        playerFallsAndRelocates.GoBackToPreviousPlatform();

    }

}

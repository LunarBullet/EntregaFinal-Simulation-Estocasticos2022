using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostToTarget : MonoBehaviour
{
    [SerializeField] float fuelConsumptionMultiplier = 15f;
    [SerializeField] GameObject youLostGameObject;


    Slider slider;
    
    Rigidbody rigidbody;
    [SerializeField] float impulse = 0f; //10 is a nice boost
    float boostMultiplier = 6.5f;
    // Start is called before the first frame update

    public float Fuel = 100f;
    void Start()
    {
        slider = GameObject.Find("FuelCounter").GetComponent<Slider>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Fuel <= 1)
        {
            StartCoroutine(YouLostTimed());
            youLostGameObject.SetActive(true);

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel.RestartMyLevel();
        }

        if (PlayerStatus.PlayerCurrentlyInPlatform)
        {
            if (Fuel > 0)
            {
                if (Input.GetMouseButton(0))
                {
                    impulse += Time.deltaTime * boostMultiplier;
                    ConsumeFuel();

                }
            }
          

            if (Input.GetMouseButtonUp(0))
            {
                BoostCat();
                StartCoroutine(ResetVariables());

                PlayerStatus.PlayerCurrentlyInPlatform = false;
            }
        }

        if (PlayerStatus.PlayerCurrentlyInPlatform)
        {
            FovChanger.ShouldEngageFovChange = false;
        }
        else
        {
            FovChanger.ShouldEngageFovChange = true;
        }

    }

    void YouLostLogic()
    {

    }

    IEnumerator YouLostTimed()
    {
        yield return new WaitForSeconds(5f);
        RestartLevel.RestartMyLevel();
    }

    void BoostCat()
    {
        rigidbody.AddForce(this.transform.forward* impulse, ForceMode.Impulse);
        FovChanger.ShouldEngageFovChange = true;
    }

    void ConsumeFuel()
    {

        if (Fuel>0)
        {
            Fuel -= Time.deltaTime * fuelConsumptionMultiplier;
        }

        slider.value = Fuel;

    }

    IEnumerator ResetVariables()
    {
        yield return new WaitForSeconds(0.15f);
        impulse = 0f;
    }


}

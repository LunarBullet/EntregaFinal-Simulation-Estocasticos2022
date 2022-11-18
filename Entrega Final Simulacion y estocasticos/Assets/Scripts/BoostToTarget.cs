using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostToTarget : MonoBehaviour
{
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
        if (Input.GetMouseButton(0))
        {
            impulse += Time.deltaTime * boostMultiplier;
            ConsumeFuel();
        }

        if (Input.GetMouseButtonUp(0))
        {
            BoostCat();
            StartCoroutine(ResetVariables());
        }
    }

    void BoostCat()
    {
        rigidbody.AddForce(this.transform.forward* impulse, ForceMode.Impulse);
    }

    void ConsumeFuel()
    {
        float fuelConsumptionMultiplier = 15f;

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

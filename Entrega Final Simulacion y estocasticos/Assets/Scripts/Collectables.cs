using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    [SerializeField] GameObject target;

    [SerializeField] bool doesItRotateAroundTarget;
    private void Start()
    {
        
    }
    private void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime * 6.5f);

        if (doesItRotateAroundTarget)
        {
            RotateAround();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerStatus>().AddCollectable();
            Destroy(this.gameObject);
        }
    }
    void RotateAround()
    {
        transform.RotateAround(target.transform.position, Vector3.down * 2, 100 * Time.deltaTime);
    }


}

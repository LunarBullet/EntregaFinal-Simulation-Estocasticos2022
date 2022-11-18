using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtMouse : MonoBehaviour
{
    [SerializeField] Camera cam;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookAtMouse();
    }

    void LookAtMouse()
    {
        float rotationPower = 1f; 

        Vector3 targetDir = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = rotationPower * (Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg) - 90f;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.up * -1);

    }

}

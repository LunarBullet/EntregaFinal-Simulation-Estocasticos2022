using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAfterTime : MonoBehaviour
{

    // Start is called before the first frame update
    void awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 3f);

    }
}

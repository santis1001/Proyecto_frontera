using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToTarget : MonoBehaviour
{

    public GameObject target;
    public float snapDistance = 0.1f;


    // Update is called once per frame
    void Update()
    {
        if (target !=null && Vector3.Distance(transform.position, target.transform.position) <= snapDistance)
        {
            transform.position = target.transform.position;
            transform.rotation = target.transform.rotation;
            //transform.localScale.y = target.transform.localScale.y;
        }
    }
}

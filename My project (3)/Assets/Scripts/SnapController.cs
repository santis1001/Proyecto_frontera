using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapController : MonoBehaviour
{

    public Vector3 targetPosition;
    public float snapDistance = 1;
    public List<Transform> nodes = new List<Transform>();

    // Start is called before the first frame update
    void Update()
    {
        transform.position = targetPosition;
        float smallestDistance = snapDistance;
        foreach (Transform node in nodes)
        {
            if (Vector3.Distance(node.position, targetPosition) < smallestDistance)
            {
                transform.position = node.position;
                smallestDistance = Vector3.Distance(node.position, targetPosition);
            }
        }
    }

}

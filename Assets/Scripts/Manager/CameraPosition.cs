using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public Transform target;

    void Start()
    {
        if (target == null)
            return;
    }

    void Update()
    {
        if (target == null)
            return;

        transform.position = new Vector3(target.position.x, target.position.y, -10);
    }
}

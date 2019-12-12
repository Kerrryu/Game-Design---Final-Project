using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotation : MonoBehaviour
{
    void Update()
    {
        // var difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.parent.position;
        var difference = Utility.GetMousePos() - transform.position;

        difference.Normalize();

        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
    }
}

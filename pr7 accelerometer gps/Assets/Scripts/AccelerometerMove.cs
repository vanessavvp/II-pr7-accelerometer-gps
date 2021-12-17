using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerometerMove : MonoBehaviour
{
    void Update()
    {
        float temp = Input.acceleration.x;

        transform.Translate(temp, 0, temp);
    }
}

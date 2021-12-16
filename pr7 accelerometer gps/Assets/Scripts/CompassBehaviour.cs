using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompassBehaviour : MonoBehaviour
{
    public GameObject compass;
    float smooth = 5.0f;

    void Update()
    {
        if (Input.location.status == LocationServiceStatus.Running)
        {
            Input.compass.enabled = true;
            Quaternion target = Quaternion.Euler(0, 0, Input.compass.trueHeading);
            compass.transform.rotation =  Quaternion.Slerp(compass.transform.rotation, target,  Time.deltaTime * smooth);
        }
        else
        {
            Input.location.Start();
        }      
    }
}

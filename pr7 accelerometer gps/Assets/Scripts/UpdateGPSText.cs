using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpdateGPSText : MonoBehaviour
{
    Text coordinates;

    private void Start()
    {
        coordinates = GameObject.Find("GPSText").GetComponent<Text>();
    }

    private void Update()
    {
        coordinates.text = "Latitude: " + GPS.Instance.Latitude.ToString() + "\nLongitude: " + GPS.Instance.Longitude.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;

public class GPS : MonoBehaviour
{
    public static GPS Instance { set; get; }
    public float Latitude;
    public float Longitude;
    Text CoordinatesInfo;

    private void Start()
    {
        CoordinatesInfo = GameObject.Find("GPSText").GetComponent<Text>();
    }

    private void Update()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(StartLocationService());
    }

    IEnumerator StartLocationService()
    {
        #if UNITY_EDITOR
        //Wait until Unity connects to the Unity Remote, while not connected, yield return null
        while (!UnityEditor.EditorApplication.isRemoteConnected)
        {
            yield return null;
        }
        #endif

        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
            Permission.RequestUserPermission(Permission.CoarseLocation);
        }

        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("User has not enabled GPS");
            yield return new WaitForSeconds(3);
        }

        Input.location.Start();
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait < 1)
        {
            Debug.Log("Timed out");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable determine device location");
            yield break;
        } 
        else
        {
            // Service is working 
            if (Input.location.status == LocationServiceStatus.Running)
            {
                Latitude = Input.location.lastData.latitude;
                Longitude = Input.location.lastData.longitude;
                CoordinatesInfo.text = "Latitude: " + Latitude.ToString() + "\nLongitude: " + Longitude.ToString();
            }
        }
        yield break;
    }

}

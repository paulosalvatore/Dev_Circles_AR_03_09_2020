using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlacement : MonoBehaviour
{
    public ARRaycastManager raycastManager;

    public GameObject targetMarker;

    public GameObject spider;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);

        var hitResults = new List<ARRaycastHit>();

        raycastManager.Raycast(screenCenter, hitResults, TrackableType.Planes);

        if (hitResults.Count > 0)
        {
            var hitPoint = hitResults[0].pose;
            transform.position = hitPoint.position;
            transform.rotation = hitPoint.rotation;

            targetMarker.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0))
        {
            spider.SetActive(true);

            spider.transform.position = transform.position;
        }
    }
}

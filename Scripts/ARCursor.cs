using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;

public class ARCursor : MonoBehaviour
{

    public UnityEvent objectSpawned;

    [SerializeField]
    private GameObject cursorChildObject;
    [SerializeField]
    private GameObject objectToPlace;
    [SerializeField]
    private ARRaycastManager raycastManager;

    private bool useCursor = true;

    void Start()
    {
        useCursor = true;
        cursorChildObject.SetActive(useCursor);
    }

    void Update()
    {
        if (useCursor)
        {
            UpdateCursor();
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (useCursor)
            {
                GameObject.Instantiate(objectToPlace, transform.position, transform.rotation);
                objectSpawned.Invoke();
            }
            else
            {
                List<ARRaycastHit> hits = new List<ARRaycastHit>();
                raycastManager.Raycast(Input.GetTouch(0).position, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);
                if (hits.Count > 0)
                {
                    GameObject.Instantiate(objectToPlace, hits[0].pose.position, hits[0].pose.rotation);
                    objectSpawned.Invoke();
                }
            }
        }
    }

    void UpdateCursor()
    {
        Vector2 screenPosition = Camera.main.ViewportToScreenPoint(new Vector2(0.5f, 0.5f));
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        raycastManager.Raycast(screenPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

        if (hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;
        }
    }
}
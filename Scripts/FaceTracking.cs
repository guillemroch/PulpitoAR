using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class FaceTracking : MonoBehaviour
{

    private Text errorText;
    [SerializeField] 
    private GameObject headPrefab;

    private GameObject headGameObject;
    private ARFace userFace;


    // Start is called before the first frame update
    void Awake()
    {
        userFace = GetComponent<ARFace>();
    }

    void OnEnable() {
        ARFaceManager faceManager = FindObjectOfType<ARFaceManager>();
        if(faceManager != null && faceManager.subsystem != null)
        {
            userFace.updated += OnUpdated;
             Debug.Log("FUNCIONA");
        }
        else{
            Debug.Log("ERROR");
        }

    }

    private void OnDisable() 
    {
        userFace.updated -= OnUpdated;
        SetVisibility(false);
    }

    void OnUpdated(ARFaceUpdatedEventArgs eventArgs)
    {   
        Debug.Log("UPDATED");
        Debug.Log(userFace.leftEye);
        Debug.Log(userFace.transform.position);
        if(userFace.leftEye != null && headGameObject == null){
            Debug.Log("Detectando cara");
            headGameObject = Instantiate(headPrefab, userFace.leftEye);
            Debug.Log("position" + headGameObject.transform.position);
            headGameObject.SetActive(false);
        }
        headGameObject = Instantiate(headPrefab, userFace.transform);
        headGameObject.SetActive(false);

        bool shouldBeVisible = (userFace.trackingState == TrackingState.Tracking) && (ARSession.state > ARSessionState.Ready);
        SetVisibility(shouldBeVisible);
    }


    void SetVisibility(bool isVisible){
        if (headGameObject != null)
        {
            Debug.Log("Objeto visible");
            headGameObject.SetActive(isVisible);
        }
    }

}

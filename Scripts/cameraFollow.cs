using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed = .3f;

    private Vector3 currentVelocity;

    // Update is called once per frame
    void LateUpdate()
    {
        if (target.position.y > transform.position.y)
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(transform.position.x, target.position.y, transform.position.z), ref currentVelocity, smoothSpeed * Time.deltaTime);
    }
}

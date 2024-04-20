using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //public Transform defaultTarget;
    private Transform currentTarget;
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity=Vector3.zero;
    [SerializeField] private Transform defaulttarget;
    void Start()
    {
        currentTarget = defaulttarget;
    }

    
    void Update()
    {
        Vector3 targetPosition = defaulttarget.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}

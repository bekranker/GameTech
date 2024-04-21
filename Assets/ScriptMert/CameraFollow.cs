using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity=Vector3.zero;
    [SerializeField] private Transform defaulttarget;
    [SerializeField] private Transform _parent;
    
    void Update()
    {
        Vector3 targetPosition = defaulttarget.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
    public void SetTarget(Transform target)
    {
        defaulttarget = target;
    }
    public void ScreenShake()
    {
        DOTween.Kill(_parent);

        _parent.DOPunchPosition(Vector3.right * Random.Range(-1, 1), .1f);
        _parent.DOPunchRotation(Vector3.forward * Random.Range(-1, 1) * 3, .1f).OnComplete(()=>
        {
            _parent.transform.rotation = Quaternion.Euler(Vector3.zero);
        });

    }
}

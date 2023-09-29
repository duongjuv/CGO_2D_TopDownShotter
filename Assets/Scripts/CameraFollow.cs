using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed = 5f;

    private Vector3 distance;

    private void Start()
    {
        distance = target.position - transform.position;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = target.position - distance;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        transform.LookAt(target);
    }
}

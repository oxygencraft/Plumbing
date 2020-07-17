using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothDampToLocation : MonoBehaviour
{
    public Vector3 target;
    public float smoothTime;
    public float maxSpeed = Mathf.Infinity;
    public bool cutoff = false;
    public Vector3 cutoffPoint;
    private Vector3 currentVelocity = Vector2.zero;

    void Update()
    {
        float z = transform.position.z;
        transform.position =
            Vector3.SmoothDamp(transform.position, target, ref currentVelocity, smoothTime, maxSpeed);
        Vector3 finalPosition = transform.position;
        finalPosition.z = z;
        transform.position = finalPosition;
        if (transform.position == target || cutoff && cutoffPoint.x >= transform.position.x && cutoffPoint.y >= transform.position.y)
        {
            transform.position = target;
            Destroy(this);
        }
    }
}

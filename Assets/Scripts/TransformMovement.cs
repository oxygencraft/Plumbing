using UnityEngine;

public class TransformMovement : MonoBehaviour
{
    public float movementSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;
        newPosition.x += movementSpeed * Time.deltaTime;
        transform.position = newPosition;
    }
}

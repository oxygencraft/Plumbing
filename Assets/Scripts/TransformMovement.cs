using UnityEngine;

public class TransformMovement : MonoBehaviour
{
    public Vector3 initialMovement = new Vector2(3.5f, 0f);
    public Vector3 incrementPerFrame = new Vector2(0.05f, 0f);
    public Vector3 movement = new Vector2(5f, 0f);
    private Vector3 _movement;
    public float stopTime = -1;
    public float startTime = 0;

    void Start()
    {
        _movement = initialMovement;
        Stop();
        Invoke("StartMovement", startTime);
        if (stopTime <= 0)
            return;
        Invoke("Stop", stopTime + startTime);
    }

    void StartMovement()
    {
        enabled = true;
    }

    void Stop()
    {
        enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (initialMovement.x < _movement.x)
        {
            _movement.x += incrementPerFrame.x;
        }
        if (initialMovement.y < _movement.y)
        {
            _movement.y += incrementPerFrame.y;
        }

        Vector3 newPosition = transform.position;
        newPosition += _movement * Time.deltaTime;
        transform.position = newPosition;
    }
}

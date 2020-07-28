using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCycle : MonoBehaviour
{
    public float time = 0;
    public float speed = 0.05f;
    public float nightTimeEnd = 10f;
    public float nightTimeStart = 50f;
    public float resetTime = 70f;
    public float timeUntilStartCycle = 3.5f;
    public bool nightTime = true;
    private bool started = false;

    [Header("Wwise")]
    public AK.Wwise.RTPC TimeOfTheDayRTPC;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartCycle", timeUntilStartCycle);
    }

    void StartCycle()
    {
        started = true;
    }

    // Update is called once per frame
    void Update()
    {
        TimeOfTheDayRTPC.SetGlobalValue(time);

        if (!started)
            return;
        Vector3 position = transform.position; 
        position.y += speed;
        transform.position = position;
        time = position.y;
        if (time >= nightTimeEnd)
            nightTime = false;
        if (time >= nightTimeStart)
            nightTime = true;
        if (time >= resetTime)
        {
            position.y = 0f;
            transform.position = position;
            time = 0f;
            nightTime = true;
        }
    }
}

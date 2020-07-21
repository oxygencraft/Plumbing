using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpeedRTPC : MonoBehaviour
{
    public AK.Wwise.RTPC WaterSpeedRPTC;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        WaterSpeedRPTC.SetGlobalValue(MetaballManager.waterSpeed);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmountOfWaterRPTC : MonoBehaviour
{
    public AK.Wwise.RTPC AmountOfWater;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AmountOfWater.SetGlobalValue(MetaballManager.waterSpeed);
    }
}

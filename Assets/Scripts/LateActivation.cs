using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LateActivation : MonoBehaviour
{
    public float timeUntilEnable;

    void Awake()
    {
        gameObject.SetActive(false);
        Invoke("Enable", timeUntilEnable);
    }

    void Enable()
    {
        gameObject.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float timeUntilSelfDestruct = 1f;

    void Start()
    {
        Invoke("DestroyObject", timeUntilSelfDestruct);
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}

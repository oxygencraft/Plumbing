using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nudger : MonoBehaviour
{
    void Start()
    {
        Invoke("DestroyObject", 1f);
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}

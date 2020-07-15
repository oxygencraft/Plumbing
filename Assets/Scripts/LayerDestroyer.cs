using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerDestroyer : MonoBehaviour
{
    public int layer;

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collider = collision.gameObject;
        if (collider.layer == layer)
        {
            Destroy(collider);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerDestroyer : MonoBehaviour
{
    public int layer;
    public bool destroyTriggerCollider = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collider = collision.gameObject;
        if (collider.layer == layer)
        {
            if (!destroyTriggerCollider && collision.isTrigger)
                return;
            Destroy(collider);
        }
    }
}

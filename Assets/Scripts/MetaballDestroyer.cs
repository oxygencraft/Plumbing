using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaballDestroyer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collider = collision.gameObject;
        if (collider.layer == 8)
        {
            Destroy(collider);
        }
    }
}

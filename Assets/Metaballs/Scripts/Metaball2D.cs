using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Metaball2D : MonoBehaviour
{
    public new CircleCollider2D collider;
    public bool onGround = true;

    private void Awake()
    {
        collider = GetComponent<CircleCollider2D>();
        MetaballSystem2D.Add(this);
        Transform parent = null;
        try
        {
            parent = FindObjectOfType<GameManager>().metaballParent;
        }
        catch (Exception) { }
        if (parent != null)
            transform.SetParent(parent);
    }

    public float GetRadius()
    {
        float totalSize = transform.localScale.x + transform.localScale.y;
        float size = totalSize / 2;
        return size * collider.radius;
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (onGround)
            return;
        int layer = collision.collider.gameObject.layer;
        if (layer != 9 && layer != 8)
            return;
        if (layer == 8)
        {
            Metaball2D metaball = collision.gameObject.GetComponent<Metaball2D>();
            if (metaball == null || !metaball.onGround)
            {
                return;
            }
        }
        onGround = true;
        MetaballManager.OnGround();
    }

    private void OnDestroy()
    {
        MetaballSystem2D.Remove(this);
    }
}

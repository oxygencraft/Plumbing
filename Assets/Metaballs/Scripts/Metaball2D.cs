using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Metaball2D : MonoBehaviour
{
    public new CircleCollider2D collider;
    public bool onGround = true;
    public float mass;

    private float rbMass;
    private List<int> metaballsCollidedWith = new List<int>();

    private void Awake()
    {
        rbMass = GetComponent<Rigidbody2D>().mass;
        mass = rbMass;
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
        int layer = collision.collider.gameObject.layer;
        if (layer != 9 && layer != 8)
            return;
        if (layer == 8)
        {
            Metaball2D metaball = collision.gameObject.GetComponent<Metaball2D>();
            if (metaball == null)
                return;
            if (!metaball.onGround)
                return;
        }
        onGround = true;
        MetaballManager.OnGround();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!metaballsCollidedWith.Contains(collision.gameObject.GetInstanceID()))
            return;
        mass -= collision.rigidbody.mass;
        metaballsCollidedWith.Remove(collision.gameObject.GetInstanceID());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != 8)
            return;
        Vector2 otherPosition = collision.transform.position;
        if (otherPosition.x <= 0.5f && -0.5f <= otherPosition.x && otherPosition.y > transform.position.y)
        {
            mass += collision.rigidbody.mass;
            metaballsCollidedWith.Add(collision.gameObject.GetInstanceID());
        }
    }

    public void Jumped()
    {
        onGround = false;
    }

    private void OnDestroy()
    {
        MetaballSystem2D.Remove(this);
    }
}

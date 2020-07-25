using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleProjectile : MonoBehaviour
{
    public AK.Wwise.Event WaterCollides;
    public new Rigidbody2D rigidbody;
    public int collisionsUntilDestroy = 2;

    private int hits = 0;
    private Vector2 direction;

    void Start()
    {
        // get random direction and get the object to fly in that direction
        direction = Random.insideUnitCircle.normalized * 8;
        // Convert negative number to positive number
        // because it shouldn't be flying downwards
        if (direction.y < 0)
            direction.y *= -1; 
        //Debug.Log(direction, gameObject);
        rigidbody.velocity = direction;
    }

    void FixedUpdate()
    {
        direction = direction.normalized * 8;
        rigidbody.velocity = direction;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != 8)
            return;
        FindObjectOfType<MetaballManager>().AddInfluencingAbility();
        WaterCollides.Post(gameObject);
        Destroy(collision.gameObject);
        if (++hits == collisionsUntilDestroy)
            Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public AK.Wwise.Event WaterCollides;

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.layer != 8)
            return;
        FindObjectOfType<MetaballManager>().AddInfluencingAbility();
        WaterCollides.Post(gameObject);
        Destroy(collision.gameObject);
    }
}

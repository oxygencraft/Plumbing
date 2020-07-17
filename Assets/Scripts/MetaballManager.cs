using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaballManager : MonoBehaviour
{
    private static List<Metaball2D> metaballs = new List<Metaball2D>();

    public float defaultMovementSpeed = 200f;
    public float movementSpeed;
    public float timeUntilMove = 2.5f;
    private bool allowMove = false;
    private GameObject masterObject = null;

    void Awake()
    {
        movementSpeed = defaultMovementSpeed;
        Invoke("AllowMove", timeUntilMove);
    }

    void AllowMove()
    {
        allowMove = true;
    }

    void FixedUpdate()
    {
        if (!allowMove)
            return;
        foreach (var metaball in metaballs)
        {
            if (masterObject == null)
                masterObject = metaball.gameObject;
            Rigidbody2D rb = metaball.GetComponent<Rigidbody2D>();
            Vector2 force = new Vector2(movementSpeed, 0f);
            /*if (metaball.gameObject != masterObject)
            {
                force += ((Vector2)metaball.transform.position - (Vector2)masterObject.transform.position) *
                         Vector2.Distance(metaball.transform.position, masterObject.transform.position);
            }*/
            rb.AddForce(force * Time.deltaTime, ForceMode2D.Force);
        }
    }

    public static void AddMetaball(Metaball2D metaball)
    {
        metaballs.Add(metaball);
    }

    public static List<Metaball2D> GetMetaballs()
    {
        return metaballs;
    }

    public static void RemoveMetaball(Metaball2D metaball)
    {
        metaballs.Remove(metaball);
        if (metaballs.Count == 0)
        {
            try
            {
                FindObjectOfType<GameManager>().LoseGame();
            }
            catch (System.NullReferenceException) { }
        }
    }
}

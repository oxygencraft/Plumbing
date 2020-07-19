using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MetaballManager : MonoBehaviour, Controls.IGameActions
{
    private static List<Metaball2D> metaballs = new List<Metaball2D>();

    public float defaultMovementSpeed = 200f;
    public float movementSpeed;
    public float timeUntilMove = 2.5f;
    public float timeUntilControlsEnable = 5.5f;

    private bool allowMove = false;
    private Controls controls;

    void Awake()
    {
        movementSpeed = defaultMovementSpeed;
        Invoke("AllowMove", timeUntilMove);
        //Invoke("EnableControls", timeUntilControlsEnable);
    }

    void EnableControls()
    {
        controls = new Controls();
        controls.Game.SetCallbacks(this);
        controls.Game.Enable();
    }

    void AllowMove()
    {
        allowMove = true;
    }

    public void OnSpeed(InputAction.CallbackContext context)
    {
        Debug.Log(context.action.phase);
        float change = context.ReadValue<float>();
        if (movementSpeed - change < 0)
            return;
        movementSpeed += change;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnFly(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    void FixedUpdate()
    {
        if (!allowMove)
            return;
        foreach (var metaball in metaballs)
        {
            Rigidbody2D rb = metaball.GetComponent<Rigidbody2D>();
            Vector2 force = new Vector2(movementSpeed, 0f);
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

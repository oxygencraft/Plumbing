using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MetaballManager : MonoBehaviour
{
    private static List<Metaball2D> metaballs = new List<Metaball2D>();

    public float defaultMovementSpeed = 200f;
    public float movementSpeed;
    public float jumpForce = 0.85f;
    public int jumpIterations = 4;
    public float flySpeed = 0.1f;
    public float timeUntilMove = 2.5f;
    public float timeUntilControlsEnable = 5.5f;
    public static float waterSpeed;

    private bool allowMove = false;
    private bool allowControl = false;

    private float speedChange = 0f;
    private bool jump = false;
    private bool isFlying = false;
    private float _flySpeed = 0f;

    
    void Awake()
    {
        movementSpeed = defaultMovementSpeed;
        Invoke("AllowMove", timeUntilMove);
        Invoke("EnableControls", timeUntilControlsEnable);
    }

    void EnableControls()
    {
        allowControl = true;
    }

    void AllowMove()
    {
        allowMove = true;
    }

    // Get input from the controls in the next four methods
    // Do not do this in FixedUpdate or Update
    public void OnSpeed(InputAction.CallbackContext context)
    {
        if (!allowControl)
            return;
        //Debug.Log(context.action.phase);
        if (context.action.phase == InputActionPhase.Canceled)
        {
            speedChange = 0;
            return;
        }
        speedChange = context.ReadValue<float>();
    }

    private bool isHoldingSpace = false;
    private bool pressedSpace = false;

    public void OnSpace(InputAction.CallbackContext context)
    {
        if (!allowControl)
            return;
        if (context.canceled)
        {
            Debug.Log("Space Cancelled!");
            isHoldingSpace = false;
            return;
        }
        Debug.Log("Space!");

        isHoldingSpace = true;
        Invoke("PerformSpaceAction", 0.2f);
    }

    private void PerformSpaceAction()
    {
        if (!isHoldingSpace)
        {
            Debug.Log("Jumping!");
            OnJump();
            return;
        }
        if (!isFlying)
            Fly(0f);
    }

    public void OnFly(InputAction.CallbackContext context)
    {
        Fly(context.ReadValue<float>(), context.canceled);
    }

    private float preFlySpeed = 0f;

    private void Fly(float flySpeed, bool canceled = false)
    {
        if (!isHoldingSpace)
        {
            Debug.Log("Flying Control Stopped!");
            preFlySpeed = canceled ? 0f : flySpeed;
            isFlying = false;
            return;
        }
        if (!isFlying)
        {
            Debug.Log("Early Fly Start");
            isFlying = true;
        }

        if (canceled)
        {
            Debug.Log("Fly speed change canceled!");
            _flySpeed = 0f;
            return;
        }
        isFlying = true;
        _flySpeed = preFlySpeed != 0f ? preFlySpeed : flySpeed;
        Debug.Log("Flying! Flying speed:" + _flySpeed + " PreFlySpeed:" + preFlySpeed);
    }

    public void OnJump()
    {
        // I give up for now so I'm disabling jump
        onGround = false;
        if (!onGround)
            return;
        jump = true;
        onGround = false;
        onGroundMetaballs = 0;
        foreach (var metaball in metaballs)
        {
            metaball.Jumped();
        }
    }

    // Make sure we don't jump when we jumped and are still in the air
    private static bool onGround = true;
    private static int onGroundMetaballs = 0;

    public static void OnGround()
    {
        if (++onGroundMetaballs >= metaballs.Count)
            onGround = true;
    }

    // You need to apply velocity force more than one time in order for water to jump
    // This is a jump iteration system to make it apply force several times
    private int jumpIteration = 0;

    // Do not handle controls here, do that in Update
    // You can respond to velocity variables in here however
    void FixedUpdate()
    {
        if (!allowMove)
            return;
        foreach (var metaball in metaballs)
        {
            Rigidbody2D rb = metaball.GetComponent<Rigidbody2D>();
            float _jumpForce = 0f;
            if (jump)
            {
                _jumpForce = jumpForce * metaball.mass;
                if (jumpIteration++ == jumpIterations)
                {
                    jumpIteration = 0;
                    jump = false;
                }
            }
            Vector2 force = new Vector2(movementSpeed, rb.velocity.y + _jumpForce);
            if (!isHoldingSpace)
                isFlying = false;
            if (isFlying)
                force.y = _flySpeed * flySpeed;
            rb.velocity = force;
        }
    }

    // Only handle controls changing speed or velocity here
    // If changing velocity, put it inside a variable and have
    // FixedUpdate add that velocity on top of the current velocity
    // and then have it reset that variable
    void Update()
    {
        if (speedChange != 0 && !(movementSpeed + speedChange <= 0))
            movementSpeed += speedChange * 0.09f;
        waterSpeed = movementSpeed;
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

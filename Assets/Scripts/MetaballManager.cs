using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MetaballManager : MonoBehaviour
{
    // List of metaballs (see metaball management methods for adding, removing or getting the list)
    private static List<Metaball2D> metaballs = new List<Metaball2D>();

    #region Settings/Public variables
    public static float waterSpeed; // Static version of movementSpeed for RTPC

    [Header("Movement/controls settings")]
    public bool move = false;
    public bool control = false;
    [Space(10f)]
    public float defaultMovementSpeed = 200f;
    public float movementSpeed;
    public float changeSpeedSpeed = 0.1f;
    [Space(10f)]
    public float jumpForce = 0.85f;
    public int jumpIterations = 4;
    [Space(5f)]
    public float flySpeed = 0.1f;
    [Space(10f)]
    public float timeUntilMove = 2.5f;
    public float timeUntilControlsEnable = 5.5f;

    [Header("Water Influencing Ability Settings")]
    [Tooltip("If disabled, the controls will not be disabled")]
    public bool enabled = true;
    public int waterInfluencingAbility = 200;
    public float pointsUntilInfluencingAbilityDecrease = 1000f;
    public int maxWaterInfluencingAbility = 200;
    public int maxWaterInfluencingAbilityGiven = 4;
    public int chanceToNotGetInfluencingAbility = 11;
    public Slider waterInfluencingAbilityMeter;

    [Space(10f)]

    public float changeSpeedPoints = 5f;
    public float flyPoints = 20f;

    [Header("Misc")]
    public AK.Wwise.RTPC speedOfWaterRTPC;
    #endregion

    #region Internal variables
    private float influencingPoints;

    private float speedChange = 0f;
    private bool jump = false;
    private bool isFlying = false;
    private float _flySpeed = 0f;
    #endregion

    // Awake method is to setup the metaball manager
    void Awake()
    {
        movementSpeed = defaultMovementSpeed;
        influencingPoints = pointsUntilInfluencingAbilityDecrease;
        Invoke("AllowMove", timeUntilMove);
        Invoke("EnableControls", timeUntilControlsEnable);
    }

    // Enable or disable methods (controls and movement) in this region
    #region Enable/Disable methods
    public void EnableControls()
    {
        control = true;
    }

    public void DisableControls()
    {
        control = false;
    }

    public void AllowMove()
    {
        move = true;
    }

    public void DisallowMove()
    {
        move = false;
    }
    #endregion

    // Methods related to the influencing ability system
    #region Influencing ability system
    public void SubtractPoints(float points)
    {
        float decrease = points;
        if (metaballs.Count <= 20)
            decrease += 100 / metaballs.Count;
        influencingPoints -= decrease * Time.deltaTime;
        //Debug.Log(influencingPoints);
        if (influencingPoints <= 0)
        {
            influencingPoints = pointsUntilInfluencingAbilityDecrease;
            waterInfluencingAbility--;
            waterInfluencingAbilityMeter.value = waterInfluencingAbility;
        }

        if (waterInfluencingAbility <= 0 && enabled)
        {
            DisableControls();
            speedChange = 0f;
            isFlying = false;
            _flySpeed = 0f;
        }
    }

    public void AddInfluencingAbility()
    {
        if (!ShouldGiveInfluencingAbility())
            return;
        EnableControls();
        waterInfluencingAbility += Random.Range(1, maxWaterInfluencingAbilityGiven);
        if (waterInfluencingAbility > maxWaterInfluencingAbility)
            waterInfluencingAbility = maxWaterInfluencingAbility;
        waterInfluencingAbilityMeter.value = waterInfluencingAbility;
    }

    private bool ShouldGiveInfluencingAbility()
    {
        return Random.Range(0, chanceToNotGetInfluencingAbility) != 0;
    }
    #endregion

    private bool isHoldingSpace = false;

    // Get input from the controls in this region
    // Do not do this in FixedUpdate or Update
    #region Input callbacks
    public void OnSpeed(InputAction.CallbackContext context)
    {
        if (!control)
            return;
        //Debug.Log(context.action.phase);
        if (context.action.phase == InputActionPhase.Canceled)
        {
            speedChange = 0;
            return;
        }
        speedChange = context.ReadValue<float>();
    }

    public void OnFly(InputAction.CallbackContext context)
    {
        Fly(context.ReadValue<float>(), context.canceled);
    }

    public void OnSpace(InputAction.CallbackContext context)
    {
        if (!control)
            return;
        if (context.canceled)
        {
            // Debug.Log("Space Cancelled!");
            isHoldingSpace = false;
            return;
        }
        //Debug.Log("Space!");

        isHoldingSpace = true;
        Invoke("PerformSpaceAction", 0.2f);
    }

    #endregion

    // Do something with the inputs if needed to be handled separately from callbacks
    #region Input actions
    private void PerformSpaceAction()
    {
        if (!isHoldingSpace)
        {
            //Debug.Log("Jumping!");
            OnJump();
            return;
        }
        if (!isFlying)
            Fly(0f);
    }

    private float preFlySpeed = 0f;

    private void Fly(float flySpeed, bool canceled = false)
    {
        if (!isHoldingSpace)
        {
            //Debug.Log("Flying Control Stopped!");
            preFlySpeed = canceled ? 0f : flySpeed;
            isFlying = false;
            return;
        }
        if (!isFlying)
        {
            //Debug.Log("Early Fly Start");
            isFlying = true;
        }

        if (canceled)
        {
            //Debug.Log("Fly speed change canceled!");
            _flySpeed = 0f;
            return;
        }
        isFlying = true;
        _flySpeed = preFlySpeed != 0f ? preFlySpeed : flySpeed;
        preFlySpeed = 0f;
        //Debug.Log("Flying! Flying speed:" + _flySpeed + " PreFlySpeed:" + preFlySpeed);
    }
    #endregion

    // Code related to jumping (jumping is disabled at the moment)
    #region Jumping system
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
    #endregion

    // Update and FixedUpdate methods where movement and changing speed is handled
    #region Update methods
    // Do not handle controls here, do that in Update
    // You can respond to velocity variables in here however
    void FixedUpdate()
    {
        if (!move)
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
            {
                force.y = _flySpeed * flySpeed;
                SubtractPoints(flyPoints);
            }
            if (speedChange != 0f)
                SubtractPoints(changeSpeedPoints);
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
            movementSpeed += speedChange * changeSpeedSpeed;
        waterSpeed = movementSpeed;
        speedOfWaterRTPC.SetGlobalValue(MetaballManager.waterSpeed);
    }
    #endregion

    // Add, remove or get metaballs from the list
    #region Metaball management methods
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
    #endregion
}

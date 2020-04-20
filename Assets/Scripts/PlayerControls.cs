using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    float jumpVelocity;

    static Animator anim;

    private Vector3 inputVector;

    public float speed;
    public float jumpHeight = 7f;
    public float gravity = -12f;
    float velocityY;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    private float jumpCoolDown;
    public float coolDown = 2f;
    public int numberOfJumps = 0;
    public float groundCheckPosition;

    public float currentGroundLevel;

    public LayerMask groundLayers;

    public CharacterController controller;

    private Vector3 previousRunningFrame;
    private bool timeCompare;
    public float runCoolDownTimer;
    public float runCoolDown = 0.01f;

    public float flippableBarrier = 0.61f;

    public AudioSource collectSound;

    public bool enteredJumper;

    // Start is called before the first frame update
    void Start()
    { 
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();

        jumpVelocity = Mathf.Sqrt(-2 * gravity * jumpHeight);
    }

    // Update is called once per frame
    void Update()
    {
        print("enteredJumper = " + enteredJumper);

        if (controller.isGrounded) {
            groundCheckPosition = controller.transform.position.y;
        }

        Vector3 currentRunningFrame = controller.transform.position;

        if(runCoolDownTimer > 0)
        {
            runCoolDownTimer -= Time.deltaTime;
        }

        if(runCoolDownTimer < 0)
        {
            runCoolDownTimer = 0;
        }

        if(previousRunningFrame != currentRunningFrame)
        {
            timeCompare = true;
        }
        else
        {
            if(runCoolDownTimer == 0)
            {
                timeCompare = true;
                runCoolDownTimer = runCoolDown;
            }
            else
            {
                timeCompare = false;
            }
        }

        // Move Crash left or right //
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal") * speed, 0, Input.GetAxisRaw("Vertical") * speed);

        // Turns Crash to face the direction he is moving //
        transform.LookAt(transform.position + new Vector3(inputVector.x, 0, inputVector.z));

        // Checks to see if Crash is falling //
        if (!controller.isGrounded)
        {
            anim.SetBool("isFalling", true);
        }
        else
        {
            anim.SetBool("isFalling", false);
        }
        //////////////////////////////////////

        // Checks to see if Crash can jump and sets cooldown timer //
        if (jumpCoolDown > 0)
        {
            jumpCoolDown -= Time.deltaTime;
        }

        if (jumpCoolDown < 0)
        {
            jumpCoolDown = 0;
        }
        ////////////////////////////////////////////////////////////

        // If Crash can jump, he jumps //
        if (Input.GetButtonDown("Jump") && jumpCoolDown == 0 && numberOfJumps < 2)
        {
            anim.SetBool("isJumping", true);
            jump();
            jumpCoolDown = coolDown;
        }
        ////////////////////////////////////

        if (controller.transform.position.y - currentGroundLevel >= flippableBarrier)
        {
            anim.SetBool("flippable", false);
        }
        else
        {
            anim.SetBool("flippable", true);
        }

        if ((Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) && timeCompare && controller.isGrounded)
        {
            anim.SetBool("isRunning", true);
            anim.SetBool("isIdle", false);
        }
        else
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isIdle", true);
        }

        previousRunningFrame = currentRunningFrame;
    }

    private void FixedUpdate()
    {
        velocityY += Time.deltaTime * gravity;

        Vector3 velocity = inputVector * speed + Vector3.up * velocityY;

        controller.Move(velocity * Time.deltaTime);

        if (controller.isGrounded)
        {
            velocityY = 0;
            currentGroundLevel = transform.position.y;
            numberOfJumps = 0;
        }
    }

    void jump()
    {
        float jumpVelocity = Mathf.Sqrt(-2 * gravity * jumpHeight);
        velocityY = jumpVelocity;
        numberOfJumps++;
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "wumpa")
        {
            collectSound.Play();
            ScoringSystem.theScore += 1;
            Destroy(col.gameObject);
        }

        if (col.tag == "jumperTop")
        {
            enteredJumper = true;
            anim.SetBool("isJumping", true);
            jump();
            jumpCoolDown = coolDown;

            
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if(col.tag == "jumperTop")
        {
            enteredJumper = false;
        }
    }
}

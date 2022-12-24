using UnityEngine;

public class AnimationAndMovementController : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 30f;
    public float horizontalSpeed = 20f;
    public float runSpeed = 65f;
    public float gravity = -9.81f;
    Animator animator;
    public ParticleSystem particle;
   public AudioSource audioSource;
    public HandController handController;
    public RightHandController RigthandController;
    private HealZombie healZombie;
    float currentSpeed;
    Vector3 velocity;
    bool isMovementPressed;
    bool isRunPressed;
    bool isHorizontalPressed;
    bool isLeftPressed;
    bool isRightPressed;
    private void Start()
    {
        animator = GetComponent<Animator>();
        healZombie=GetComponent<HealZombie>();
        audioSource=GetComponent<AudioSource>();
        particle.Stop();
    }
    void handleGravity()
    {
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
    void handleAnimation()
    {
        bool isWalking = animator.GetBool("isWalking");
        bool isRunning = animator.GetBool("isRunning");
        bool isAttack = animator.GetBool("isAttack");
        bool isAttack2 = animator.GetBool("isAttack2");
        bool isHorizontal = animator.GetBool("isHorizontal");
        if (isLeftPressed && !isAttack)
        {
            animator.SetBool("isAttack", true);
        }
        else if (!isLeftPressed && isAttack)
        {
            animator.SetBool("isAttack", false);
        }
        if (isRightPressed && !isAttack2)
        {
            animator.SetBool("isAttack2", true);
        }
        else if (!isRightPressed && isAttack2)
        {
            animator.SetBool("isAttack2", false);
        }
        if (isHorizontalPressed && !isHorizontal)
        {
            animator.SetBool("isHorizontal", true);
        }
        else if (!isHorizontalPressed && isHorizontal)
        {
            animator.SetBool("isHorizontal", false);
        }
        if (isMovementPressed && !isWalking)
        {
            animator.SetBool("isWalking", true);
        }
        else if (!isMovementPressed && isWalking)
        {
            animator.SetBool("isWalking", false);
        }
        if (isMovementPressed && isRunPressed && !isRunning)
        {
            animator.SetBool("isRunning", true);
        }
        else if ((!isMovementPressed || !isRunPressed) && isRunning)
        {
            animator.SetBool("isRunning", false);
        }
        if(!isWalking&&!isRunning)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
            if (particle.isStopped)
            {
                particle.Play();
            }
            healZombie.HealHP();
        }
        if(isRunning|| isWalking)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            particle.Stop();
        }
    }


    // Update is called once per frame
    void Update()
    {
        handleGravity();
        handleAnimation();
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        if (Input.GetMouseButtonUp(0))
        {
            isLeftPressed = true;
        }
        else
        {
            isLeftPressed = false;
        }
        if (Input.GetMouseButtonUp(1))
        {
            isRightPressed = true;
        }
        else
        {
            isRightPressed = false;
        }
        if (x != 0 || z != 0)
        {
            //Play your sideways animation
            if (z != 0)
            {
                isMovementPressed = true;
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                isRunPressed = true;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                isRunPressed = false;
            }
            if (x != 0 && z == 0)
            {
                isHorizontalPressed = true;
                isMovementPressed = false;
            }
        }
        else
        {
            isMovementPressed = false;
            isHorizontalPressed = false;
        }
        if (isHorizontalPressed && !isMovementPressed)
        {
            currentSpeed = horizontalSpeed;
        }
        else
        {
            currentSpeed = isRunPressed ? runSpeed : speed;
        }
        if (!isLeftPressed)
        {
            Vector3 move = transform.right * x + transform.forward * z;
            characterController.Move(move * currentSpeed * Time.deltaTime);
        }

    }
    public void StopAtack()
    {
        isLeftPressed = false;
    }
    public void attack()
    {
        handController.Attack();
    }
    public void attackStop()
    {
        handController.StopAttack();
    }
    public void right_attack()
    {
        RigthandController.Attack();
    }
    public void right_attackStop()
    {
        RigthandController.StopAttack();
    }
}

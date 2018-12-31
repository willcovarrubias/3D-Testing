using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerExample : MonoBehaviour {

    public GameObject platformParent;
    public GameObject cleanIcon;
    public GameObject cleaningEffects;
    public Transform bubbleSpawnPoint;
    public Transform sparksSpawnPoint;
    public bool isCurrentlyColliding;

    public bool onTheGround;
    public bool touchingFrontWall;
    public float moveSpeed;
    public float jumpPower;
    public float deathTimer = 0;
    private float adjustedJumpPower;


    public Joystick joystick;
    float step;
    Rigidbody rb;
    Animator anim;
    Collider collider;
    public float distanceToGround;
    bool canJump;
    bool isCrushed;
    bool isFried;

    GameMaster gameMaster;
    private bool isCleaningButtonDown;
    //public Button yourButton;


    AudioManager audioManager;
    AudioSource audioSource;

    bool playRocketSound = false;

    public GameObject boom;
    bool boomIsGoing = false;
    public float punchTimer = 0;
    public float maxTimeTilPunch;
    public GameObject punchRecastBar;


    //For debug purposes only
    public Vector3 velocity;
    //public float speed;



    private void Awake()
    {
        
    }

    private void Start()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        canJump = true;

        distanceToGround = collider.bounds.extents.y;

        boom.gameObject.SetActive(false);

        //Button btn = yourButton.GetComponent<Button>();
        //btn.onClick.AddListener(HitCleaningButton);

        cleanIcon.SetActive(false);
        //GameMaster.gameMaster.playerIsDead = false;
        CalculatePlayerMass();
        ShowPlayerUnlocks();

        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.LogError("NO AUDIO MANAGER FOUND!");
        }

        audioSource = GetComponent<AudioSource>();
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(20, 10, 100, 40), "Mass: " + (float)rb.mass);
        //GUI.Label(new Rect(140, 10, 100, 40), "Ranged EXP: " + GameMaster.gameMaster.allArmorExp[(int)GameMaster.gameMaster.char01Ranged + 5]);
        //GUI.Label(new Rect(260, 10, 100, 40), "Character 03 unlocked: " + chars_Unlocked[2]);
    }

    void ShowPlayerUnlocks()
    {
        Debug.Log("Player unlocks: Speed - " + GameMaster.gameMaster.characterSpeeds[0] +
                    "\nMass - " + GameMaster.gameMaster.characterMass[0] +
                    "\nLuck - " + GameMaster.gameMaster.characterJumpHeight[0] +
                    "\nPlatforms - " + GameMaster.gameMaster.characterPunchCooldown[0] +
                    "\nNumber of unlocks: " + GameMaster.gameMaster.numberOfUnlocks[0]);
    }

    void CalculatePlayerMass()
    {

            rb.mass = gameMaster.characterMass[0];
            adjustedJumpPower = jumpPower * rb.mass;
            Debug.Log("Character's adjusted jump power is: " + adjustedJumpPower);
            
        
    }

    void Update () 
	{
        if (!gameMaster.isPaused)
        {
            if (!isCrushed && !isFried && transform.position.y >= .3)
            {


                
                    Vector3 moveVector = ((transform.right * joystick.Horizontal) / 2 + transform.forward * joystick.Vertical);
                    Vector3 vectorForBackwardMovement = (transform.forward * -joystick.Vertical * (moveSpeed - 3));
                    transform.Translate(moveVector * (moveSpeed - vectorForBackwardMovement.z) * Time.deltaTime);

                    float targetVelocity = moveVector.x;
                    // anim.SetFloat("VelocityX", joystick.Horizontal);
                    // anim.SetFloat("VelocityZ", Mathf.Abs(joystick.Vertical));
                    anim.SetFloat("VelocityX", moveVector.x);
                    anim.SetFloat("VelocityZ", moveVector.z);
                




                if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
                {
                    anim.SetBool("Jumping", true);
                    //transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), step);
                    //transform.Translate(transform.up * jumpPower * Time.deltaTime);


                    Jump();
                }

                if (Input.GetKeyDown(KeyCode.Tab))
                {
                    Boom();
                }

                if (IsGrounded())
                {
                    anim.SetBool("Jumping", false);
                    onTheGround = true;
                    deathTimer = 0;
                    playRocketSound = false;
                    
                }
                else
                {
                    
                    anim.SetBool("Jumping", true);
                    deathTimer += Time.deltaTime;
                    onTheGround = false;

                    if (!playRocketSound)
                    {
                        playRocketSound = true;
                        audioManager.PlaySound("Jump");
                    }

                }

                

                if (deathTimer >= 10)
                {
                    PlayerIsDead();
                }
                //Testing purposes only: DELETE THIS AFTER
                var x = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
                //var y = velocity.y;
                var z = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

                //transform.Rotate(0, x, 0);
                transform.Translate(x / 2, 0, z);

                //Raycast for detection front collisions.
                RaycastHit frontHit;
                RaycastHit leftHit;
                RaycastHit rightHit;

                // Does the ray intersect any objects excluding the player layer
                if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y - .25f, transform.position.z), transform.TransformDirection(Vector3.forward), out frontHit, .5f))
                {
                    Debug.DrawRay(new Vector3(transform.position.x, transform.position.y - .25f, transform.position.z), transform.TransformDirection(Vector3.forward) * frontHit.distance, Color.red);
                    anim.Play("HoboPushing");
                }
                else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out leftHit, .5f))
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * leftHit.distance, Color.yellow);
                    anim.Play("HoboHitLeftWall");
                }
                else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out rightHit, .5f))
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * rightHit.distance, Color.yellow);
                    anim.Play("HoboHitRightWall");
                }



            }

            if (punchTimer < maxTimeTilPunch)
            {
                punchTimer += Time.deltaTime;
            }

            float calculatedTimeTilAbleToPunch = punchTimer / maxTimeTilPunch;
            SetPunchBar(calculatedTimeTilAbleToPunch);   
            
            if (transform.position.y <= -10 || transform.position.y >= 40)
            {
                PlayerIsDead();
            }

            if (gameMaster.acidIconIsOn == false)
            {
                cleanIcon.SetActive(false);
            }

            
            isCleaningButtonDown = false;

            if (Input.GetKeyDown(KeyCode.P))
            {
                GameMaster.gameMaster.boltsCollected++;
            }
        }
    }


    public void SetPunchBar(float timeTilPunch)
    {
        punchRecastBar.transform.localScale = new Vector3(timeTilPunch, punchRecastBar.transform.localScale.y, punchRecastBar.transform.localScale.z);
        punchRecastBar.transform.localScale = new Vector3(Mathf.Clamp(timeTilPunch, 0f, 1f), punchRecastBar.transform.localScale.y, punchRecastBar.transform.localScale.z);

    }

    public void Jump()
    {
        if (IsGrounded() && !isFried)
        {
            audioManager.PlaySound("Jump");
            rb.AddForce(transform.up * adjustedJumpPower, ForceMode.Impulse);
        }

    }

   

    public void Boom()
    {
        if (boomIsGoing == false && punchTimer >= maxTimeTilPunch && !isFried)
        {
            rb.mass = 10000;
            rb.constraints = RigidbodyConstraints.FreezePosition;
            boom.SetActive(true);
            punchTimer = 0;
            anim.Play("Cleaning");
            audioManager.PlaySound("Punch");
            StartCoroutine(KeepTimeForBeingBoomEffect());
            Debug.Log("Punch button is working but maybe not the punching logic?");

        }

    }
    public void PlayerIsDead()
    {
        //GameMaster.gameMaster.playerIsDead = true;
        audioManager.FadeOutSound("Phase1and2Song");
        audioManager.FadeOutSound("Phase3and4Song");
        audioManager.FadeOutSound("Phase5and6Song");
        audioManager.FadeOutSound("Phase7and8Song");
        audioManager.FadeOutSound("Phase9and10Song");
        audioManager.FadeInSound("DeathSong");
        Application.LoadLevel("DeathSCene");
    }

    IEnumerator KeepTimeForBeingCrushed()
    {
        yield return new WaitForSeconds(2);
        isCrushed = false;
        
    }

    IEnumerator KeepTimeForBeingFried()
    {
        yield return new WaitForSeconds(2);
        isFried = false;

    }

    IEnumerator KeepTimeForBeingBoomEffect()
    {
        boomIsGoing = false;
        yield return new WaitForSeconds(.25f);
        boom.SetActive(false);
        rb.mass = gameMaster.characterMass[0];
        rb.constraints = RigidbodyConstraints.None;
        
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        transform.rotation = Quaternion.Euler(0, 0, 0);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Crusher")
        {
            anim.Play("RoboCrushed");
            isCrushed = true;
            StartCoroutine(KeepTimeForBeingCrushed());
        }
        

        


    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Acid")
        {
            gameMaster.acidIconIsOn = true;
            cleanIcon.SetActive(true);

            if (Input.GetKeyDown(KeyCode.C))
            {
                //Do stuff.
                gameMaster.acidWasCleaned = true;
                
            }

        }

        if (other.gameObject.tag == "Bounce")
        {
            if (IsGrounded() && !isCrushed && !isFried)
            {
                //rb.AddForce(transform.up * adjustedJumpPower);
                if (rb.velocity.y > 10)
                {
                    rb.AddForce(transform.up * (adjustedJumpPower), ForceMode.Impulse);
                    Debug.Log("Jump1");
                }
                else
                {
                    rb.AddForce(transform.up * (adjustedJumpPower) * 1.25f, ForceMode.Impulse);
                    Debug.Log("Jump2");
                }


                audioManager.PlaySound("Jump");
            }
        }



    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            
            audioManager.PlaySound("Hit");
            rb.AddForce(-transform.forward * 300, ForceMode.Impulse);
            GameObject sparks = Instantiate(Resources.Load("Misc/SparksEmitter"), new Vector3(sparksSpawnPoint.position.x, sparksSpawnPoint.position.y, sparksSpawnPoint.position.z), Quaternion.Euler(0, -45, 0)) as GameObject;


        }

        if (collision.gameObject.tag == "Projectile2")
        {

            audioManager.PlaySound("Hit");
            GameObject sparks = Instantiate(Resources.Load("Misc/SparksEmitter"), new Vector3(sparksSpawnPoint.position.x, sparksSpawnPoint.position.y, sparksSpawnPoint.position.z), Quaternion.Euler(0, -45, 0)) as GameObject;


        }

        if (collision.gameObject.tag == "Laser")
        {
            isFried = true;
            anim.Play("RoboFried");
            audioManager.PlaySound("Zap");
            GameObject sparks = Instantiate(Resources.Load("Misc/SparksEmitter"), new Vector3(sparksSpawnPoint.position.x, sparksSpawnPoint.position.y, sparksSpawnPoint.position.z), Quaternion.Euler(0, -45, 0)) as GameObject;
            GameObject sparks2 = Instantiate(Resources.Load("Misc/SparksEmitter"), new Vector3(sparksSpawnPoint.position.x, sparksSpawnPoint.position.y, sparksSpawnPoint.position.z), Quaternion.Euler(0, -45, 0)) as GameObject;
            
            rb.AddForce(-transform.forward * adjustedJumpPower, ForceMode.Impulse);
            StartCoroutine(KeepTimeForBeingFried());
        }


        if (collision.gameObject.tag == "Bolt")
        {
            anim.Play("RobotCelebration");
        }

        if (collision.gameObject.tag == "KillPlayer")
        {
            PlayerIsDead();
        }

    }




    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Acid")
        {
            gameMaster.acidIconIsOn = false;
            cleanIcon.SetActive(false);
        }
    }

  


    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distanceToGround + 1);
        
    }

    public void Punching()
    {
        if (!isCrushed)
        {
            gameMaster.acidWasCleaned = true;
            cleanIcon.SetActive(false);
            anim.Play("Cleaning");
            audioManager.PlaySound("Clean");
            //Instantiate(cleaningEffects, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            GameObject bubbles = Instantiate(Resources.Load("Misc/CleaningEffects"), new Vector3(bubbleSpawnPoint.position.x, bubbleSpawnPoint.position.y, bubbleSpawnPoint.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
            bubbles.transform.parent = platformParent.transform;
            Debug.Log("THE CLEANING BUTTON WORKS!");
            /*RaycastHit hitInfo;
            GameObject target = null;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.Log(ray);
            if (Physics.Raycast(ray.origin, ray.direction * 10, out hitInfo))
            {
                target = hitInfo.collider.gameObject;
                if (target.gameObject.tag == "CleanIcon")
                {
                    GameMaster.gameMaster.acidWasCleaned = true;
                    cleanIcon.SetActive(false);
                    anim.Play("Cleaning");
                    //Instantiate(cleaningEffects, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                    GameObject bubbles = Instantiate(Resources.Load("Misc/CleaningEffects"), new Vector3(bubbleSpawnPoint.position.x, bubbleSpawnPoint.position.y, bubbleSpawnPoint.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
                    bubbles.transform.parent = platformParent.transform;
                    Debug.Log("THE CLEANING BUTTON WORKS!");
                }
            }*/
        }
    }
}
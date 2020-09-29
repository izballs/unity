using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections;

using Photon.Pun;
using Photon.Realtime;

public class PlayerScript : MonoBehaviourPunCallbacks, IPunObservable
{

    public GameObject playerUIPrefab;
    public bool multiplayerMode;
    public string playerName;
    public static GameObject LocalPlayerInstance;
    public BulletScript projektile;
    public BulletScript chargeGreen;
    public BulletScript chargePurple;
    public float moveSpeed;
    public float slideSpeed;
    public bool shopOpen = false;
    public float maxFallSpeed = 5f;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private bool grounded;
    private bool jump;
    private bool charging = false;
    private float chargingStarted = 0f;
    private float tjump;
    private bool djump;
    private ParticleSystem[] particleSystems;
    public GameObject multiplayerUI;
    public bool wallJumpEnabled;
    public bool airSlideEnabled;
    public bool doubleJumpEnabled;
    private bool pjump = false;
    private bool sjump = false;
    private bool pdjump = false;
    private bool ppjump = false;
    private bool ppdjump = false;
    private bool wjump = false;
    private bool wpjump = false;
    private bool sliding = false;
    public int damage;
    public int maxHP;
    public int currentHP;
    public int maxSlowTime;
    public Vector2 wallJumpStrength = new Vector2(-20f, 20f);
    public int slowTimeMeter;
    public float maxSpeed = 5.0f;
    private bool direction = false;
    private float tsliding = 0;
    private int slidesLeft = 1;
    private bool startLerp = false;
    private bool startLerpb = false;
    private bool stopLerp = false;
    private bool stopLerpb = false;
    public bool airSlide = false;
    public bool shooting = false;
    public Vector2 movement;
    public float timeStartedLerping;
    public float timeStartedLerpingb;
    public float lastShot;
    public int maxSlides = 1;
    private float fromLerp;
    static float t = 0.0f;
    private float x = 0.0f;
    private float y = 0.0f;
    private Animator animator;
    private Animator loadingSprite;
    private CircleCollider2D col;
    private Vector2 zero = Vector2.zero;
    [SerializeField]
    private LayerMask terrain;
    private float wallSlidingTimer = -5f;
    private bool wallJumping = false;
    public int chips = 0;
    public bool dialogOpen = false;
    public float jumpStrength = 5f;
    private IEnumerator hold;
    private Vector2 move = new Vector2(0f, 0f);
    PlayerControls inputAction;
    private bool hitDirectionRight;

    private bool slowMotion = false;
    private bool canMove = true;
    private bool canTakeDamage = true;
    private bool left = false;
    private bool right = false;
    private int chargeLevel = 0;

    private Material mat;

    private GameObject interactable;

    private int jumpCount = 0;
    private bool slideJump = false;

    public Color FirstCharge, SecondCharge, ThirdCharge, NoCharge;

    


    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

        if (stream.IsWriting)
        {
            stream.SendNext(currentHP);
            stream.SendNext(sr.flipX);
            stream.SendNext(movement);
            stream.SendNext(left);
            stream.SendNext(right);
            stream.SendNext(pjump);
            stream.SendNext(pdjump);
            stream.SendNext(wpjump);
            stream.SendNext(sliding);
            stream.SendNext(animator.GetLayerWeight(1));
        }
        else
        {
            currentHP = (int)stream.ReceiveNext();
            sr.flipX = (bool)stream.ReceiveNext();
            movement = (Vector2)stream.ReceiveNext();
            left = (bool)stream.ReceiveNext();
            right = (bool)stream.ReceiveNext();
            pjump = (bool)stream.ReceiveNext();
            pdjump = (bool)stream.ReceiveNext();
            wpjump = (bool)stream.ReceiveNext();
            sliding = (bool)stream.ReceiveNext();
            animator.SetLayerWeight(1, (float)stream.ReceiveNext());
            
        }

    }


    void Awake()
    {
	Physics2D.IgnoreLayerCollision(10,11, true);
        if (photonView.IsMine)
            PlayerScript.LocalPlayerInstance = this.gameObject;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        mat = Instantiate(sr.material);
        sr.material = mat;
        Animator[] anims = GetComponentsInChildren<Animator>();
	animator = anims[0];
	loadingSprite = anims[1];
	hold = StartCharging();
        DontDestroyOnLoad(this.gameObject);
    }

    [PunRPC]
    public void SetUIElement(string name){
        if(multiplayerUI == null)
            multiplayerUI = PhotonNetwork.Instantiate(this.playerUIPrefab.name, new Vector3(0,0,0), Quaternion.identity, 0);
        GameObject playerList = FindObjectOfType<PlayerUI>().gameObject;
        multiplayerUI.transform.parent = playerList.GetComponentInChildren<GridLayoutGroup>().transform;        
        multiplayerUI.GetComponentsInChildren<Text>()[0].text = name;
        multiplayerUI.GetComponentsInChildren<Text>()[1].text = currentHP.ToString();
        
    }

    [PunRPC]
    public void UpdateHP(){
        multiplayerUI.GetComponentsInChildren<Text>()[1].text = currentHP.ToString();
    }


    [PunRPC]
    public void SpawnBullet(Vector3 pos, int dir, BulletScript type)
    {
        FindObjectOfType<SoundManager>().PlaySound("basicShoot");
        BulletScript projektiletemp = Instantiate(type, pos, new Quaternion(0f, 0f, 0f, 0f));
        projektiletemp.direction = dir;
        projektiletemp.shooterID = photonView.ViewID;
    }

    [PunRPC]
    public void AnimationMachinePlay(string animationName)
    {
        animator.Play(animationName);
    }

    [PunRPC]
    public void AnimationMachineSetBool(string boolName, bool value)
    {
        animator.SetBool(boolName, value);
    }

    [PunRPC]
    public void AnimationMachineSetTrigger(string triggerName, bool value)
    {
        if(value){
            animator.SetTrigger(triggerName);
        }
        else
            animator.ResetTrigger(triggerName);
    }
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<CircleCollider2D>();
        particleSystems = GetComponentsInChildren<ParticleSystem>();
        CameraWork _cameraWork = this.gameObject.GetComponent<CameraWork>();

	


        foreach(Player p in PhotonNetwork.PlayerList){
            if(photonView.Owner.ActorNumber == p.ActorNumber){
                ExitGames.Client.Photon.Hashtable h = p.CustomProperties;
                //Debug.Log(h["PlayerColorRed"]);
                mat.SetFloat("RED", (float)h["PlayerColorRed"]);
                mat.SetFloat("GREEN", (float)h["PlayerColorGreen"]);
                mat.SetFloat("BLUE", (float)h["PlayerColorBlue"]);
                mat.SetInt("HardMix", (int)h["PlayerColorHardMix"]);
            }
        }


        if (_cameraWork != null)
        {
            if (photonView.IsMine)
            {
                photonView.RPC("SetUIElement", RpcTarget.All, (string)PlayerPrefs.GetString("PlayerName"));
                _cameraWork.OnStartFollowing();
            }
        }
        else
        {
            //Debug.LogError("<Color=Red><a>Missing</a></Color> CameraWork Component on playerPrefab.", this);

        }

    }


    void LerpToSlow()
    {
        if (!startLerpb)
        {
            fromLerp = Time.timeScale;
            timeStartedLerping = Time.realtimeSinceStartup;
            timeStartedLerpingb = Time.realtimeSinceStartup;
            startLerpb = true;
            stopLerpb = false;
        }
        float timeSinceStartedb = Time.realtimeSinceStartup - timeStartedLerping;
        t = timeSinceStartedb / 0.5f;
        Time.timeScale = Mathf.Lerp(fromLerp, 0.5f, t);
    }

    void LerpToFast()
    {
        if (!stopLerpb)
        {
            fromLerp = Time.timeScale;
            timeStartedLerping = Time.realtimeSinceStartup;

            startLerpb = false;
            stopLerpb = true;
        }
        float timeSinceStartedb = Time.realtimeSinceStartup - timeStartedLerping;
        t = timeSinceStartedb / 0.5f;
        Time.timeScale = Mathf.Lerp(fromLerp, 1f, t);

    }

    // Update is called once per frame
    void Update()
    {
        if(multiplayerMode)
        if(multiplayerUI == null){
            photonView.RPC("SetUIElement", RpcTarget.All, (string)photonView.Owner.NickName);
            
        }
        animator.speed = 0.25f;

        if (currentHP <= 0)
        {
            GameManager.Instance.LeaveRoom();
        }

        if (!shopOpen)
        {
            //x = Input.GetAxisRaw("Horizontal");
            //y = Input.GetAxisRaw("Vertical");

            if (movement.x > 0)
                sr.flipX = false;
            else if (movement.x < 0)
                sr.flipX = true;


            //Debug.Log("rb.velocity.magnitude);" +rb.velocity.magnitude);
            //Debug.Log("rb.velocity);" +rb.velocity);
            double tm;
            if(multiplayerMode)
                tm = PhotonNetwork.Time;
            else
                tm = Time.realtimeSinceStartup;
            if (tm - lastShot > 0.3f)
            {
                animator.SetBool("shooting", false);
                animator.SetLayerWeight(1, 0);
            }

            if (IsGrounded())
            {
                //Debug.LogWarning("IsGrounded");
                grounded = true;
                if (tm - tjump > 0.1f)
                {
                    pjump = false;
                    pdjump = false;
                    ppjump = false;
                    ppdjump = false;
                    sjump = false;
                }
                slidesLeft = maxSlides;
                moveSpeed = 3;

                animator.SetBool("grounded", true);
            }
            else
            {
                //Debug.LogWarning("NotGrounded");
                grounded = false;
                animator.SetBool("grounded", false);
            }
            if (AlmostGrounded())
            {
                animator.SetTrigger("AlmostGround");
            }
            else
            {
                animator.ResetTrigger("AlmostGround");
            }


            if (startLerp)
                LerpToSlow();
            else if (stopLerp)
                LerpToFast();

        }
    }
    void FixedUpdate()
    {

	if(charging)
	{
		if(Time.realtimeSinceStartup - chargingStarted <= 1.5f)
		{
			loadingSprite.SetBool("Charging", charging);
			mat.SetColor("_LoadingColor", FirstCharge);
		}
		else if(Time.realtimeSinceStartup - chargingStarted > 1.5f && Time.realtimeSinceStartup - chargingStarted <= 3.0f)
		{
			mat.SetColor("_LoadingColor", SecondCharge);
			chargeLevel = 1;
		}
		else if(Time.realtimeSinceStartup - chargingStarted > 3.0f && Time.realtimeSinceStartup - chargingStarted <= 4.5f)
		{
			loadingSprite.SetBool("Charging", false);
			mat.SetColor("_LoadingColor", ThirdCharge);
			chargeLevel = 2;
		}
	}
	else
	{
			mat.SetColor("_LoadingColor", NoCharge);
			loadingSprite.SetBool("Charging", charging);
			loadingSprite.SetTrigger("LoadingInterupted");
	}

        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        if (sliding)
        {
            Slide();
            CheckSlidingJump();
        }
        else if (wpjump)
        {
            if (!wallJumping)
                WallJump();
        }
        else
        {
            WallSliding();
            CheckIdle();
            CheckFacing();
            MoveCharacter(movement);
            CheckAnimationSpeed();
            SlowMotion();
            CheckJump();

            //Debug.LogWarning("movement=" + movement);
        }
        CheckFallingSpeed();
    }

    void CheckAnimationSpeed()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("running"))
        {
            float ammount = 0.6f;
            if (movement.x < 0)
                ammount = -ammount;
            animator.speed = Mathf.Abs(movement.x + ammount);

        }
        else
            animator.speed = 1.6f;
    }

    private void CheckFacing()
    {
        if (movement.x > 0)
	{
            sr.flipX = false;
	    loadingSprite.gameObject.transform.localPosition = new Vector3(0.03f, 0.25f, 0f);
	}
	if (movement.x < 0)
	{
		sr.flipX = true;
	    loadingSprite.gameObject.transform.localPosition = new Vector3(-0.05f, 0.25f, 0f);
	}    
    
    }

    private void CheckIdle()
    {
        if (movement.x == 0)
        {
            animator.SetBool("idle", true);
        }
        else
        {
            animator.SetBool("idle", false);
        }

    }
    private void CheckFallingSpeed()
    {

        if (rb.velocity.y < maxFallSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, maxFallSpeed);
        }

    }

    private void Slide()
    {
        if (!animator.GetBool("sliding"))
        {
            FindObjectOfType<SoundManager>().PlaySound("dash");
            animator.SetTrigger("StartSliding");
            canMove = false;
            particleSystems[0].Play();
            animator.SetBool("sliding", true);
            //photonView.RPC("AnimationMachinePlay", RpcTarget.All, (string)"startSliding");
            //animator.Play("startSliding");
        }

        float ammount = 0;
        if (sr.flipX)
        {
            ammount = -1 * slideSpeed;
        }
        else
        {
            ammount = 1 * slideSpeed;
        }
        if (slideJump)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            moveSpeed = slideSpeed;
            jumpCount = 2;
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        }
        rb.velocity = new Vector2(ammount, rb.velocity.y);

        if (Time.time - tsliding > 0.4f)
        {
            canMove = true;
            sliding = false;
            slideJump = false;
            animator.SetBool("sliding", false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (photonView.IsMine || !multiplayerMode)
        {
            if (other.gameObject.tag == "Drops")
            {
                if (other.gameObject.GetComponent<ChipScript>() != null)
                {
                    //Debug.LogError("Hit a Chip");
                    chips += other.gameObject.GetComponent<ChipScript>().chips;
                    PhotonView.Destroy(other.gameObject);
                }
            }
            if (other.gameObject.tag == "NPC")
            {
                interactable = other.gameObject;
            }
            }
            if (other.gameObject.tag == "PlayerProjectile")
            {
                if(canTakeDamage){
                    if(other.gameObject.GetComponent<BulletScript>().shooterID != photonView.ViewID)
                    {
                        if(other.gameObject.transform.position.x < transform.position.x)
                            hitDirectionRight =false;
                        else
                            hitDirectionRight = true;
                        //Debug.Log("Hitted Other Player");
                        TakeDamage(other.gameObject.GetComponent<BulletScript>().GetDamage());
                        Destroy(other.gameObject);
                    }
                }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == interactable)
        {
            interactable = null;
        }
    }

    public void MoveCharacter(Vector2 direction)
    {
        if (canMove)
        {
            Vector2 targetVelocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);
            rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref zero, .05f);
        }
    }

    private bool IsGrounded()
    {
        float extraHeight = 0.0125f;
        Color rayColor;
        RaycastHit2D BottomResult = Physics2D.BoxCast(col.bounds.center, col.bounds.size - new Vector3(0.1f, 0f), 0, Vector2.down, extraHeight, terrain);
        if (BottomResult.collider != null)
        {
            rayColor = Color.green;
        }
        else
            rayColor = Color.red;
        //Debug.Log(BottomResult.collider);

        //Debug.DrawRay(col.bounds.center, Vector2.down * extraHeight, rayColor);
        return BottomResult.collider != null;
    }

    private bool AlmostGrounded()
    {
        float extraHeight = 0.25f;
        RaycastHit2D BottomResult = Physics2D.BoxCast(col.bounds.center, new Vector2(col.bounds.size.x - 0.05f, col.bounds.size.y), 0, Vector2.down, extraHeight, terrain);
        return BottomResult.collider != null;

    }

    private bool CheckLeftWall()
    {
        RaycastHit2D LeftWall = Physics2D.Raycast(new Vector2(transform.position.x, col.bounds.center.y), new Vector2(-0.2f, 0f), 0.16f, terrain);
        Color rayColor = Color.red;
        if (LeftWall.collider != null)
            rayColor = Color.green;

        //Debug.DrawRay(new Vector2(transform.position.x, col.bounds.center.y), new Vector2(-0.2f, 0f), rayColor);
        return LeftWall.collider != null;

    }
    private bool CheckRightWall()
    {
        RaycastHit2D RightWall = Physics2D.Raycast(new Vector2(transform.position.x, col.bounds.center.y), new Vector2(0.2f, 0f), 0.16f, terrain);
        Color rayColor = Color.red;
        if (RightWall.collider != null)
            rayColor = Color.green;

        //Debug.DrawRay(new Vector2(transform.position.x, col.bounds.center.y), new Vector2(0.2f, 0f), rayColor);
        return RightWall.collider != null;

    }

    private void WallSliding()
    {
        left = CheckLeftWall();
        right = CheckRightWall();


        double tm;
            if(multiplayerMode)
                tm = PhotonNetwork.Time;
            else
                tm = Time.realtimeSinceStartup;
        if (!AlmostGrounded() && !wallJumping && left && movement.x < -0.1)
        {
            pdjump = false;
            if (!animator.GetBool("wallSliding"))
            {
                animator.SetBool("wallSliding", true);
                animator.SetTrigger("StartWallSliding");
                //photonView.RPC("AnimationMachinePlay", RpcTarget.All, (string)"startWallSliding");
                //animator.Play("startWallSliding");
            }
            wallSlidingTimer = (float)tm;
        }
        else if (!AlmostGrounded() && !wallJumping && right && movement.x > 0.1f)
        {
            pdjump = false;
            if (!animator.GetBool("wallSliding"))
            {
                animator.SetBool("wallSliding", true);
                animator.SetTrigger("StartWallSliding");
                //photonView.RPC("AnimationMachinePlay", RpcTarget.All, (string)"startWallSliding");
                //animator.Play("startWallSliding");
            }
            wallSlidingTimer = (float)tm;

        }
        else
        {
            animator.SetBool("wallSliding", false);
        }
        if (tm - wallSlidingTimer < 0.2f && !wallJumping)
            rb.velocity = new Vector2(rb.velocity.x, -0.5f);
    }

    private void WallJump()
    {
        canMove = false;
        float ammount = wallJumpStrength.x;
        animator.SetBool("wallSliding", false);
        if (sr.flipX)
            ammount = -ammount;
        StartCoroutine(EnableWallJump(0.2f));
        animator.SetTrigger("WallJump"); 
        //photonView.RPC("AnimationMachinePlay", RpcTarget.All, (string)"wallJump");
        //animator.Play("wallJump");
        wallJumping = true;
        wpjump = false;
        FindObjectOfType<SoundManager>().PlaySound("jump");
        rb.velocity = new Vector2(ammount, wallJumpStrength.y);
    }


    public void TakeDamage(int dmg)
    {
        if(canTakeDamage){
            FindObjectOfType<SoundManager>().PlaySound("takeDamage");
            StartCoroutine(TakeDamageVoice());

        canMove = false;
        animator.SetTrigger("DamageTaken");
        currentHP -= dmg;
        float xForce;
        if(hitDirectionRight)
            xForce = -0.3f;
        else
            xForce = 0.3f;
        canTakeDamage = false;
        rb.velocity = new Vector2(xForce, 0.2f);
        StartCoroutine(EnableMoving(0.3f));
        StartCoroutine(EnableDamage(1f));
        photonView.RPC("UpdateHP", RpcTarget.All);
        
        if (currentHP <= 0)
            Die();
        }
    }
    public void Die()
    {
        FindObjectOfType<SoundManager>().PlaySound("dead");
        Destroy(gameObject);
    }

    void SlowMotion()
    {
        if (slowTimeMeter > 5 && slowMotion)
        {
            //Debug.LogError(Time.realtimeSinceStartup - timeStartedLerpingb);
            if (Time.realtimeSinceStartup - timeStartedLerpingb >= 0.1f)
            {
                slowTimeMeter -= 5;
                timeStartedLerpingb = Time.realtimeSinceStartup;
            }
            startLerp = true;
            stopLerp = false;
        }
        else
        {
            startLerp = false;
            stopLerp = true;
        }
    }

    IEnumerator EnableWallJump(float waitTime)
    {
        yield return new WaitForSecondsRealtime(waitTime);
        canMove = true;
        wallJumping = false;
    }
    IEnumerator EnableDamage(float waitTime)
    {
        for(int x = 0; x < 10; x++){
            sr.enabled = false;
            yield return new WaitForSecondsRealtime(waitTime/20);
            sr.enabled = true;
            yield return new WaitForSecondsRealtime(waitTime/20);
        }
        canTakeDamage = true;
    }
    IEnumerator EnableMoving(float waitTime)
    {
        yield return new WaitForSecondsRealtime(waitTime);
        canMove = true;
    }

    void SlowMotionPressed(InputAction.CallbackContext context)
    {
        slowMotion = !slowMotion;
    }

    void RegenSlowPressed(InputAction.CallbackContext context)
    {
        slowTimeMeter = 100;
    }

    void TakeDamagePressed(InputAction.CallbackContext context)
    {
        currentHP -= 10;
        if (currentHP < 0)
            currentHP = 0;
    }
    void RegenHPPressed(InputAction.CallbackContext context)
    {
        currentHP += 10;
        if (currentHP > maxHP)
            currentHP = maxHP;
    }
    void SlidePressed(InputAction.CallbackContext context)
    {
        //Debug.LogWarning("LolWTG");
        if ((!sliding && slidesLeft > 0) && (airSlide || grounded))
        {
            //Debug.LogWarning("Lol WHY ITS NOT WORKING");
            sliding = true;
            tsliding = Time.time;
            slidesLeft -= 1;
        }
    }

    void CheckJump(){
        if(pjump){
            if(!ppjump)
            {
                //Debug.Log("ppjump = " + ppjump);
                animator.SetTrigger("Jump");
                particleSystems[0].Play();
            }
            ppjump = true;
        }
        if(pdjump){
            if(!ppdjump)
            {
                //Debug.Log("ppdjump = " + ppdjump);
                animator.SetTrigger("Jump");
                particleSystems[0].Play();
            }
            ppdjump = true;
            
        }
    }
    void CheckSlidingJump(){
        if(pjump && pdjump && !ppdjump)
        {
            ppjump = true;
            ppdjump = true;
            if(!sjump)
            {
                //Debug.Log("sjump = " + sjump);
                animator.SetTrigger("Jump");
                particleSystems[0].Play();

            }
            slidesLeft -= 1;
            sjump = true;

        }
    }



    void JumpPressed(InputAction.CallbackContext context)
    {
        double tm;
        if(multiplayerMode)
            tm = PhotonNetwork.Time;
        else
            tm = Time.realtimeSinceStartup;
        if (interactable != null)
        {
            interactable.GetComponent<NPCScript>().Interact(inputAction);
        }
        else
        {
            if (tm - wallSlidingTimer < 0.2f)
            {
                wpjump = true;
                pjump = true;

            }
            else if (sliding && !pdjump)
            {
                tjump = (float)tm;
                slideJump = true;
                FindObjectOfType<SoundManager>().PlaySound("jump");
                rb.velocity = new Vector2(rb.velocity.x, jumpStrength);
                //photonView.RPC("AnimationMachinePlay", RpcTarget.All, (string)"Jumping");
                //animator.Play("Jumping");
                canMove = true;
                pdjump = true;
                pjump = true;
            }
            else
            {
                if (!pjump)
                {
                    tjump = (float)tm;
                    canMove = true;
                    //photonView.RPC("AnimationMachinePlay", RpcTarget.All, (string)"Jumping");
                    //animator.Play("Jumping");
                    FindObjectOfType<SoundManager>().PlaySound("jump");
                    rb.velocity = new Vector2(rb.velocity.x, jumpStrength);
                    pjump = true;
                }
                else if (!pdjump)
                {
                    //Debug.LogWarning("Pdjump");

                    canMove = true;
                    //photonView.RPC("AnimationMachinePlay", RpcTarget.All, (string)"Jumping");
                    //animator.Play("Jumping");
                    FindObjectOfType<SoundManager>().PlaySound("jump");
                    rb.velocity = new Vector2(rb.velocity.x, jumpStrength);
                    pdjump = true;
                }
            }
        }
    }

    IEnumerator StartCharging(){
    	yield return new WaitForSeconds(0.5f);
	    chargingStarted = Time.realtimeSinceStartup;
	    charging = true;
    }

    void ChargeStopped(InputAction.CallbackContext context)
    {
	    StopCoroutine(hold);
	    hold = StartCharging();
	    charging = false;
	    //Debug.LogError(context.duration);
	    //Debug.LogError("holdingStopped");
	    if(chargeLevel != 0){
        	double tm;
        	if(multiplayerMode)
            	tm = PhotonNetwork.Time;
        	else
            	tm = Time.realtimeSinceStartup;
        	lastShot = (float)tm;
            animator.SetLayerWeight(1, 1);
            Transform psTran = particleSystems[1].transform;
            Vector3 pos = new Vector3();
	    int dir = 0;
            if (sr.flipX)
            {
            	psTran.localPosition = new Vector3(-0.243f, 0.315f, 0f);
            	dir = -1;
            	if (animator.GetBool("grounded"))
            	{
                	if (!animator.GetBool("idle"))
                    	psTran.localPosition = new Vector3(-0.273f, 0.315f, 0f);

            	}
            	if (animator.GetBool("wallSliding"))
            	{
                	psTran.localPosition = new Vector3(0.265f, 0.315f, 0f);
                	dir = 1;
            	}
            	pos = new Vector3(transform.position.x + psTran.localPosition.x, transform.position.y + psTran.localPosition.y, transform.position.z + psTran.localPosition.z);

	    }
            else
            {
            	animator.SetBool("shooting", true);
            	dir = 1;
            	psTran.localPosition = new Vector3(0.235f, 0.315f, 0f);
            	if (animator.GetBool("grounded"))
            	{
                	if (!animator.GetBool("idle"))
                    	psTran.localPosition = new Vector3(0.265f, 0.315f, 0f);
            	}
            	if (animator.GetBool("wallSliding"))
            	{
                	psTran.localPosition = new Vector3(-0.243f, 0.315f, 0f);
                	dir = -1;
            	}
            	pos = new Vector3(transform.position.x + psTran.localPosition.x, transform.position.y + psTran.localPosition.y, transform.position.z + psTran.localPosition.z);
	    }
	
	BulletScript temp = projektile;
	if(chargeLevel == 1)
		temp = chargeGreen;
	else if(chargeLevel == 2)
		temp = chargePurple;
	
        if(multiplayerMode)
            photonView.RPC("SpawnBullet", RpcTarget.All, (Vector3)pos, (int)dir, (BulletScript)temp);
        else
            SpawnBullet(pos, dir, temp);
	chargeLevel = 0;
	}
    }

 
    void ChargePressed(InputAction.CallbackContext context)
    {
	    StartCoroutine(hold);
    }

    void FirePressed(InputAction.CallbackContext context)
    {
        double tm;
        if(multiplayerMode)
            tm = PhotonNetwork.Time;
        else
            tm = Time.realtimeSinceStartup;
        int dir = 0;
        animator.SetLayerWeight(1, 1);
        lastShot = (float)tm;
        Transform psTran = particleSystems[1].transform;
        Vector3 pos = new Vector3();
        if (sr.flipX)
        {
            psTran.localPosition = new Vector3(-0.243f, 0.315f, 0f);
            dir = -1;
            if (animator.GetBool("grounded"))
            {
                if (!animator.GetBool("idle"))
                    psTran.localPosition = new Vector3(-0.273f, 0.315f, 0f);

            }
            if (animator.GetBool("wallSliding"))
            {
                psTran.localPosition = new Vector3(0.265f, 0.315f, 0f);
                dir = 1;

            }
            pos = new Vector3(transform.position.x + psTran.localPosition.x, transform.position.y + psTran.localPosition.y, transform.position.z + psTran.localPosition.z);

        }
        else
        {
            animator.SetBool("shooting", true);
            lastShot = (float)tm;
            dir = 1;
            psTran.localPosition = new Vector3(0.235f, 0.315f, 0f);
            if (animator.GetBool("grounded"))
            {
                if (!animator.GetBool("idle"))
                    psTran.localPosition = new Vector3(0.265f, 0.315f, 0f);
            }
            if (animator.GetBool("wallSliding"))
            {
                psTran.localPosition = new Vector3(-0.243f, 0.315f, 0f);
                dir = -1;
            }
            pos = new Vector3(transform.position.x + psTran.localPosition.x, transform.position.y + psTran.localPosition.y, transform.position.z + psTran.localPosition.z);
        }
        
        if(multiplayerMode)
            photonView.RPC("SpawnBullet", RpcTarget.All, (Vector3)pos, (int)dir, (BulletScript) projektile);
        else
            SpawnBullet(pos, dir, projektile);
        //particleSystems[1].Play();
    }



    public override void OnEnable()
    {
        base.OnEnable();

        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true && multiplayerMode)
        {
            return;
        }
        inputAction = FindObjectOfType<SettingsObjectScript>().inputActions;
        inputAction.Enable();
        inputAction.PlayerControl.Movement.performed += ctx => movement = ctx.ReadValue<Vector2>();
        inputAction.PlayerControl.Fire.performed += FirePressed;
        inputAction.PlayerControl.Charge.started += ChargePressed;
        inputAction.PlayerControl.Charge.canceled += ChargeStopped;
        inputAction.PlayerControl.Jump.performed += JumpPressed;
        inputAction.PlayerControl.Slide.performed += SlidePressed;
        inputAction.PlayerControl.SlowMotion.performed += SlowMotionPressed;
        inputAction.PlayerControl.RegenSlow.performed += RegenSlowPressed;
        inputAction.PlayerControl.TakeDamage.performed += TakeDamagePressed;
        inputAction.PlayerControl.RegenHp.performed += RegenHPPressed;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true && multiplayerMode)
        {
            return;
        }
        inputAction.Disable();
        inputAction.PlayerControl.Movement.performed -= ctx => movement = ctx.ReadValue<Vector2>();
        inputAction.PlayerControl.Fire.performed -= FirePressed;
        inputAction.PlayerControl.Charge.started -= ChargePressed;
        inputAction.PlayerControl.Charge.canceled -= ChargeStopped;
        inputAction.PlayerControl.Jump.performed -= JumpPressed;
        inputAction.PlayerControl.Slide.performed -= SlidePressed;
        inputAction.PlayerControl.SlowMotion.performed -= SlowMotionPressed;
        inputAction.PlayerControl.RegenSlow.performed -= RegenSlowPressed;
        inputAction.PlayerControl.TakeDamage.performed -= TakeDamagePressed;
        inputAction.PlayerControl.RegenHp.performed -= RegenHPPressed;
    }

    IEnumerator TakeDamageVoice(){
        yield return new WaitForSeconds(0.3f);
        FindObjectOfType<SoundManager>().PlaySound("takeDamageVoice");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboRabbit : EnemyScript
{

    public PlayerDetector pd;
    private bool canAttack = true, canJump = true;
    public float attackDelay = 4;
    public float jumpDelay = 4;
    private bool falling = false;
    public float jumpNowDelay = 0.5f;

    // Start is called before the first frame update
    public override void Start()
    {
	    base.Start();
	    rb = GetComponentsInParent<Rigidbody2D>()[0];
    }

    public override void Attack()
    {
	    canAttack = false;
	    animator.SetTrigger("Shoot");
	    StartCoroutine(EnableAttack());

    }

    public void Jump(){
    	canJump = false;
	animator.SetTrigger("Jump");
	StartCoroutine(JumpNow());
	StartCoroutine(EnableJump());
    
    }
    // Update is called once per frame
    void Update()
    {
	    if(pd.target != null)
	    {
		
		    float horizontalDistance = pd.target.transform.position.y - transform.position.y;
		    float distance = Vector2.Distance(pd.target.transform.position, transform.position);
		    if(distance < 2.5f && horizontalDistance > -1 && horizontalDistance < 1){
		    	if(canAttack)
			    Attack();
		    }
		    else
		    {
			    if(canJump && 
				!animator.GetCurrentAnimatorStateInfo(0).IsName("Shoot"))
			    Jump();
		    }
	    }

	    Debug.Log(rb.velocity.y);
	    if(!falling && rb.velocity.y < 0)
	    {
		    falling = true;
	    }
	    else if(rb.velocity.y == 0 && falling)
	    {
		    	animator.SetTrigger("Land");
	    	    	falling = false;
	    }
	    if(animator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
	    {
	    if(pd.target.transform.position.x < transform.position.x)
		    transform.rotation = new Quaternion(0, 0, 0, 0);
	    else
		    transform.rotation = new Quaternion(0, 180, 0, 0);
	    }
        
    }
    IEnumerator JumpNow(){
	    float x = 0;
	    if(pd.target.transform.position.x < transform.position.x)
		    x = -2;
	    else
		    x = 2;
    	yield return new WaitForSeconds(jumpNowDelay);
	rb.AddForce(new Vector2(x, 4), ForceMode2D.Impulse);
    }
    IEnumerator EnableAttack(){
    	yield return new WaitForSeconds(attackDelay);
	canAttack = true;
    	
    }

    IEnumerator EnableJump(){
    	yield return new WaitForSeconds(jumpDelay);
	canJump = true;
    }
}

using System.Collections;
using UnityEngine;

public class BatScript : EnemyScript
{

    private bool targetLocked;
    public float movementSpeed;
    public float wait;
    private PlayerDetector pd;
    private bool canAttack;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        chips = 10;
        targetLocked = false;
        pd = transform.parent.GetComponentInChildren<PlayerDetector>();
        canAttack = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pd.playerDetected && !targetLocked)
        {
            targetLocked = true;
            StartCoroutine(waitBeforeAttack());
            animator.SetTrigger("playerSeen");
        }
        if(canAttack)
            Attack();
    }

   public override void  OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerScript player = other.gameObject.GetComponent<PlayerScript>();
            player.TakeDamage(damage);
        }
        else if (other.gameObject.tag == "PlayerProjectile")
        {
            
            BulletScript bullet = other.gameObject.GetComponent<BulletScript>();
            Debug.Log("Bat Hitted by projektile");
            Debug.Log("Bullet damage = " + damage);

            TakeDamage(bullet.GetDamage());
            Destroy(bullet.gameObject);
        }
    }

    public override void Attack() 
    {
        transform.position = Vector2.MoveTowards(transform.position, pd.target.transform.position, movementSpeed * Time.deltaTime);
    }

    IEnumerator waitBeforeAttack()
    {
        yield return new WaitForSeconds(wait);
        canAttack = true;
    }
}

using UnityEngine;

public class WoodCutter : EnemyScript
{

    public bool PlayerOnRange;
    public float attackDelay = 3f;
    public PlayerDetector pd;
    public CuttingWoodStage cws;
    private bool canAttack = true;
    private float lastAttack = 0f;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    override public void Attack(){
        lastAttack = Time.time;
        animator.SetTrigger("spin");
        canAttack = false;

    }

    public override void Die(){
        Vector3 pos = gameObject.transform.position;
        GameObject temp = Instantiate(drop, pos, new Quaternion());
        temp.GetComponent<ChipScript>().chips = chips;
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Time.time - lastAttack > attackDelay)
            canAttack = true;
        if(pd.playerDetected){
            if(cws.ready)
            {
                if(canAttack)
                    Attack();
        }}
        
    }
/*   public override void  OnTriggerEnter2D(Collider2D other)
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
*/

}

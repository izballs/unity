using System.Collections;
using UnityEngine;

public abstract class EnemyScript : MonoBehaviour
{

    [SerializeField]
    protected int hp;
    [SerializeField]
    protected int damage;
    [SerializeField]
    protected bool isProjectile;
    protected Animator animator;
    protected SpriteRenderer sr;
    protected Rigidbody2D rb;
    [SerializeField]
    protected int chips;
    [SerializeField]
    protected GameObject explodeAnimation;
    public GameObject drop;

    public virtual void TakeDamage(int dmg)
    {
        StartCoroutine(Flash());
        hp -= dmg;
        if (hp <= 0)
            Die();
    }

    public abstract void Attack();

    public virtual void Die()
    {
        Vector3 pos = gameObject.transform.position;

    
        if(drop != null){
            GameObject temp = Instantiate(drop, pos, new Quaternion());
            temp.GetComponent<ChipScript>().chips = chips;
        }
        if(explodeAnimation != null){
            Instantiate(explodeAnimation, pos, new Quaternion());
        }
        if(isProjectile)
            Destroy(gameObject);
        
        else
            Destroy(gameObject.transform.parent.gameObject);
    }

    // Start is called before the first frame update
    public virtual void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerScript player = other.gameObject.GetComponent<PlayerScript>();
            player.TakeDamage(damage);
            if(isProjectile)
                Die();
        }
        if(other.gameObject.tag == "PlayerProjectile")
        {
            BulletScript bullet = other.gameObject.GetComponent<BulletScript>();
            TakeDamage(bullet.GetDamage());
            Destroy(bullet.gameObject);
        }

    }
    public int GetDamage(){
    	return damage;
    }
    public virtual IEnumerator Flash(){
        sr.enabled = false;
        yield return new WaitForSeconds(0.05f);
        sr.enabled = true;
        yield return new WaitForSeconds(0.05f);
        sr.enabled = false;
        yield return new WaitForSeconds(0.05f);
        sr.enabled = true;
        yield return new WaitForSeconds(0.05f);
        sr.enabled = false;
        yield return new WaitForSeconds(0.05f);
        sr.enabled = true;
    }
}

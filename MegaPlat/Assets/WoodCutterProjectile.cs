using System.Collections;
using UnityEngine;

public class WoodCutterProjectile : MonoBehaviour
{
    public bool direction;
    public bool triggered;
    public float speed = 1f;
    public bool firstRise = true;
    public int health = 40;
    public int damage = 10;
    private Rigidbody2D rb;
    public Sprite triggeredSprite;
    private SpriteRenderer sr;
    private AudioSource asrc;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        asrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if(triggered)
        {
            float step = speed * Time.deltaTime;
            if(direction)
            transform.position = Vector3.MoveTowards(transform.position, transform.right, step);
            else
            {
            transform.position = Vector3.MoveTowards(transform.position, transform.right, -step);
            }

        }
        
    }

    void TakeDamage(int dmg){
        health -= dmg;
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.name == "WoodCutterTrigger"){
            asrc.Play();
            if(other.transform.position.x > transform.position.x)
                direction = false;
            else
                direction = true;
            transform.parent = null;
            triggered = true;
            rb.bodyType = RigidbodyType2D.Kinematic;
            sr.sprite = triggeredSprite;

        }
        if(other.gameObject.tag == "PlayerProjectile")
        {
            TakeDamage(other.gameObject.GetComponent<BulletScript>().GetDamage());
            Destroy(other.gameObject);
            StartCoroutine(Flash());
        }
        if(other.gameObject.tag == "Player" && triggered)
        {
            other.gameObject.GetComponent<PlayerScript>().TakeDamage(damage);
        }
    }

    void OnCollisionEnter2D(Collision2D other){

    }
    
    void OnCollisionStay2D(Collision2D other){

    }

    IEnumerator Flash(){
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

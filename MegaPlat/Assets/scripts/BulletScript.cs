using System.Collections;
using UnityEngine;
using Photon.Pun;

public class BulletScript : MonoBehaviourPunCallbacks, IPunObservable
{
    
    // Start is called before the first frame update
    public float aliveTime;
    public float speed;
    public int direction;
    [SerializeField]
    private int damage;
    private SpriteRenderer sr;
    public int shooterID;
    

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
    if(stream.IsWriting){
        stream.SendNext(direction);
    }
    else
    {
        this.direction = (int)stream.ReceiveNext();
    }
    }
    void Start()
    {
        StartCoroutine(KillBullet());
        sr = GetComponent<SpriteRenderer>();
        if (direction < 0)
            sr.flipX = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (direction < 0)
            sr.flipX = true;
        transform.position += new Vector3(direction * speed * Time.deltaTime, 0f, 0f);
    }

    void OnTriggerEnter2D(Collider2D other){
        //Debug.LogError(other.gameObject.tag);
    }

    IEnumerator KillBullet() 
    {
        yield return new WaitForSeconds(aliveTime);
        Destroy(gameObject);
    }


    public int GetDamage()
    {
        return damage;
    }
}

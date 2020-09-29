using UnityEngine;

public class GrabHand : MonoBehaviour
{

    private GrabberBot basebot;
    // Start is called before the first frame update
    void Start()
    {
	    basebot = GetComponentsInParent<GrabberBot>()[0];
	    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
	    if(other.gameObject.tag == "Player")
		    other.GetComponent<PlayerScript>().TakeDamage(basebot.GetDamage());
	    if(other.gameObject.tag == "PlayerProjectile")
		    Destroy(other.gameObject);
    }
}

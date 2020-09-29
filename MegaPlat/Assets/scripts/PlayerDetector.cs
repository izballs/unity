using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public bool playerDetected;
    public GameObject target = null;

    // Start is called before the first frame update
    void Start()
    {
        playerDetected = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerDetected = true;
            target = other.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            playerDetected = false;
    }
}

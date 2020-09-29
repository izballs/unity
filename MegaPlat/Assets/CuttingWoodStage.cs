using System.Collections;
using UnityEngine;

public class CuttingWoodStage : MonoBehaviour
{
    public GameObject cuttingWood;
    public Transform[] children;
    private bool makingChild = false;
    public int maxWood = 6;
    public float raseTime = 1f;
    public float delay = 4f;
    public bool startRasing = false;
    public bool rasing = false;
    public bool ready = false;
    private float startTime;
    private Vector3[] nextPos; 
    private float[] distances;
    private int raseIndex;
    // Start is called before the first frame update
    void Start()
    {
        nextPos = new Vector3[maxWood+1];
        distances = new float[maxWood+1];
        children = GetComponentsInChildren<Transform>();


    }

    // Update is called once per frame
    void Update()
    {
        children = GetComponentsInChildren<Transform>();
        if(!makingChild)
            if(children.Length < maxWood+1){
               MakeChild() ;
            }
        if(startRasing)
            RaseChildren();
        if(!rasing && !startRasing && children.Length > 1)
            ready = true;
        else
            ready = false;

        
    }

    void MakeChild(){
        makingChild = true;
        GameObject temp = Instantiate(cuttingWood, this.transform.position, new Quaternion(0f,0f,0f,0f), this.transform);
        startRasing = true;
        children = GetComponentsInChildren<Transform>();
    }
    void RaseChildren(){
        if(!rasing)
        {
            startTime = Time.time;
            rasing = true;
            for(int x = 1; x < children.Length; x++){
                nextPos[x] = new Vector3(children[x].localPosition.x, children[x].localPosition.y + 0.16f, children[x].localPosition.z); 
                distances[x] = Vector3.Distance(children[x].localPosition, nextPos[x]);
                if(children[x].localPosition.y == 0f){
                    raseIndex = x;
                    
                }
                if(children[x].localPosition.y >= 0.157f)
                {
                    children[x].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
                }
                
            }
        }
            float distCovered = (Time.time - startTime) * raseTime;
            float fractionOfJourney = distCovered / distances[raseIndex];
            if(children.Length - 1 >= raseIndex){
            children[raseIndex].localPosition = Vector3.Lerp(children[raseIndex].localPosition, nextPos[raseIndex], fractionOfJourney);
        if(Vector3.Distance(children[raseIndex].localPosition, nextPos[raseIndex]) == 0.0f){
            startRasing = false;
            rasing = false;
            StartCoroutine(StartChildMaking());
        }
            }
            else
            {
            startRasing = false;
            rasing = false;
            StartCoroutine(StartChildMaking());
                return;
            }
    }

    IEnumerator StartChildMaking(){
        yield return new WaitForSecondsRealtime(delay);
        makingChild = false;

    }
}

using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public float camFollowSpeed;
    private PlayerScript playerScript;
    private CanvasController canvasController;
    private Camera cam;
    private Vector3 camVelocity = Vector3.zero;
    public Text rFpsLabel;
    public Text fFpsLabel;
    private float timer, rtimer;
    private Vector3 lastCamPos;
    public GameObject parralaxLayer;
    private Transform[] parralaxLayers;
    
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GetComponentInChildren<PlayerScript>();
        canvasController = GetComponentInChildren<CanvasController>();
        cam = GetComponentInChildren<Camera>();
        timer = 0.5f;
	parralaxLayers = parralaxLayer.GetComponentsInChildren<Transform>();
	lastCamPos = cam.transform.position;
    }

    void Update(){
        if (Time.unscaledTime > rtimer)
        {
        rFpsLabel.text = (1f / Time.unscaledDeltaTime).ToString();
        rtimer = Time.unscaledTime + 0.5f;

        }
    
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        CameraFollow();
        if (Time.unscaledTime > timer)
        {
        fFpsLabel.text = (1f / Time.unscaledDeltaTime).ToString();
        timer = Time.unscaledTime + 0.5f;

        }
    	foreach(Transform obj in parralaxLayers){
		float parralaxSpeed = 1 - Mathf.Clamp01(Mathf.Abs(cam.transform.position.z / obj.localPosition.z));
		float difference = cam.transform.position.x - lastCamPos.x;
		obj.Translate(Vector3.right * difference * parralaxSpeed);
	}
	lastCamPos = cam.transform.position;
    }

    void CameraFollow(){
        Vector3 targetPosition = playerScript.transform.TransformPoint(0, 0.4f, -3);
        cam.transform.position = Vector3.SmoothDamp(cam.transform.position, targetPosition, ref camVelocity,  camFollowSpeed);
    }

    public string GetVariableString(string wanted){
        string[] exploted = wanted.Split('.');
        
        switch(exploted[0]){
            case "Player":
                switch(exploted[1]){
                    case "maxHP":
                        return playerScript.maxHP.ToString();
                    case "damage":
                        return playerScript.damage.ToString();
                    case "airSlide":
                        return playerScript.airSlideEnabled.ToString();
                    case "wallJump":
                        return playerScript.wallJumpEnabled.ToString();
                    case "doubleJump":
                        return playerScript.doubleJumpEnabled.ToString();
                }
                break;
            case "Inventory":
                return "WIP";

        }
        return "NULL";
    }
}

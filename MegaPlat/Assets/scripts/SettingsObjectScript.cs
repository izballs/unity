using UnityEngine;

public class SettingsObjectScript : MonoBehaviour
{
    
    public PlayerControls inputActions;


    void Awake(){
        inputActions = new PlayerControls();
    
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

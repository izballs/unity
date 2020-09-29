using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{


    public void Singleplayer(){
        SceneManager.LoadScene(1);
    }

    public void Multiplayer(){
        SceneManager.LoadScene(2);
    }

    public void Quit(){
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

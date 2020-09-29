
using UnityEngine;
using UnityEngine.SceneManagement;

using Photon.Pun;
using Photon.Realtime;


public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager Instance;

    public GameObject playerPrefab;
    public GameObject playerUIPrefab;

    public GameObject playerList;

    
    private Vector3[] spawnpoints = new Vector3[4];


    public override void OnLeftRoom(){
        SceneManager.LoadScene(0);
    }




    public void LeaveRoom(){
        PhotonNetwork.LeaveRoom();
    }


    public override void OnPlayerEnteredRoom(Player other){
        Debug.LogFormat("nPLayerEnteredRoom() {0}", other.NickName);


        if(PhotonNetwork.IsMasterClient){
            Debug.LogFormat("OnPLayerEnteredRoom IsMasterCliuent {0}", PhotonNetwork.IsMasterClient);

            LoadArena();
        }
    }

    public override void OnPlayerLeftRoom(Player other){
        Debug.LogFormat("OnPLayerLeftRoom() {0}", other.NickName);

        if(PhotonNetwork.IsMasterClient){
            Debug.LogFormat("OnPLayerLeftRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient);

            LoadArena();
        }
    }

    void LoadArena(){
        if(!PhotonNetwork.IsMasterClient){
            Debug.LogError("PhotonNetwork : Trying to load a  level but we are not the master CLient");
        }
        Debug.LogFormat("PhotonNetwork: Loading Level : {0}", PhotonNetwork.CurrentRoom.PlayerCount);
        PhotonNetwork.LoadLevel("MultiplayerVS");
    }

    // Start is called before the first frame update
    void Start()

    {
        playerList = FindObjectOfType<PlayerUI>().gameObject;
        spawnpoints[0] = new Vector3(-470.647f,-246.54f,0f);
        spawnpoints[1] = new Vector3(-457.24f,-246.52f,0f);
        spawnpoints[2] = new Vector3(-468.4f,-241.11f,0f);
        spawnpoints[3] = new Vector3(-458.88f,-241.11f,0f);
        Instance = this;
        int point = Random.Range(0,3);
        if(PlayerScript.LocalPlayerInstance == null)
        {
            GameObject player = PhotonNetwork.Instantiate(this.playerPrefab.name, spawnpoints[point], Quaternion.identity, 0);

        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}

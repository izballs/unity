using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class NetworkManagerScript : MonoBehaviourPunCallbacks
{
    bool isConnecting;

    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    void Start()
    {
    }

    public void Connect()
    {
        isConnecting = PhotonNetwork.ConnectUsingSettings();
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = "1";
        }
    }

    // Update is called once per frame
    void Update()
    {
    }


    public override void OnConnectedToMaster()
    {
        Debug.Log("PUN BAsics launcher: OnConnectedToMaster() was called by PUN");
        if (isConnecting)
        {
            Debug.Log("IsConnecting");
            PhotonNetwork.JoinRandomRoom();
            isConnecting = false;
        }
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarningFormat("PUN Launcher: OnDisconnected/( was called by Pun with reason {0}", cause);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("PUN Launcher: OnJoinRandomFailed() was called by Pun. No RAndom Room available so we create one");
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 8;
        
        PhotonNetwork.CreateRoom(null, roomOptions);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Pun Launcher: OnJoinedRoom() called by PUN. Now this client is in a room");
        
        


        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            Debug.Log("Loading MultiplayerVS");

            PhotonNetwork.LoadLevel("MultiplayerVS");
        }
    }

}

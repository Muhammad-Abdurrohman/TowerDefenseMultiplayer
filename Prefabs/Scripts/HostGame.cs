using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class HostGame : MonoBehaviour
{

    [SerializeField]
    private uint roomSize = 3;

    [SerializeField]
    private string roomName;
    
    private NetworkManager networkManager;

    public InputField inputField;

    void Start()
    {
        networkManager = NetworkManager.singleton;
        if (networkManager.matchMaker == null)
        {
            networkManager.StartMatchMaker();
        }
    }

    public void SetRoomName()
    {
        roomName = inputField.text;
        Debug.Log(roomName);
    }

    public void CreateRoom()
    {
        if (roomName != "" && roomName != null)
        {
            Debug.Log("Creating Room:" + roomName + " with room for " + roomSize + " players.");
            networkManager.matchMaker.CreateMatch(roomName, roomSize, true, "", "", "", 0, 0, networkManager.OnMatchCreate);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NM : NetworkManager
{
    void Start()
    {
       

        string serveur = GameObject.Find("Configuration").GetComponent<Configuration>().configuration.serveur;

        switch (serveur)
        {
            case "serveur":
                Debug.Log("Starting server...");
                StartServer();
                Debug.Log("Starting local client...");
                NetworkClient myClient = ClientScene.ConnectLocalServer ();
                StartClient();
                break;
            default:
                Debug.Log("Starting client...");
                NetworkClient c = StartClient();
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

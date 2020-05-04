using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;
using Mirror;
using UnityEngine.SceneManagement;

public class Configuration : NetworkBehaviour
{
    CameraSwitch cs;
    /*
     * Gestion de l'ecran et du network (serveur ou client)
    */

    public ConfigurationFile configuration;
    private int x;
    private string y;
    private bool changementPosition1 = false;
    private bool changementPosition2 = false;
    private bool changementPosition3 = false;
    private NetworkManager NM;
    [SyncVar] bool connectionFinish = false;
    //[SyncVar] string serveurScene;
    //[SyncVar] string clientScene;

    // Use this for initialization
    void Awake()
    {
        //DontDestroyOnLoad(this);
        configuration = DeserializeConfigurationFile();
        if (configuration == null)
        {
            Debug.LogError("SCREEN CONFIGURATION NOT FOUND!");
        }
        else
        {
            Debug.LogWarning("Screen configuration found: " + configuration.position + ", " + configuration.serveur);
            x = int.Parse(configuration.position);
            y = configuration.serveur;


            NM = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();

            if (SceneManager.GetActiveScene().name == "Starting server")
            {
                if ((y == "serveur"))
                {
                    NM.StartHost();
                }

            }

            /*GameObject go = GameObject.Find("Multi Cameras");
            
            CameraSwitch other = (CameraSwitch)go.GetComponent(typeof(CameraSwitch));
            other.cameraPositionChange(x);*/

        }

    }

    void Update()
    {
        if (y == "client" && NetworkClient.active != true)
        {
            NM.StartClient();
        }

        if (NM.numPlayers == 2 && SceneManager.GetActiveScene().name == "Starting server" && connectionFinish == false)
        {
            connectionFinish = true;
            if (y == "serveur")
            {
                NetworkManager.singleton.ServerChangeScene("Start scene");

                //Spawn door
                /*GameObject door = GameObject.Find("Pass MS");
                foreach (GameObject player in GameObject.FindGameObjectsWithTag("PlayerClone"))
                {
                    NetworkServer.Spawn(door, player);
                }*/


                if (!changementPosition3)
                {
                    foreach (GameObject player in GameObject.FindGameObjectsWithTag("PlayerClone"))
                    {
                        player.transform.position = new Vector3(70.75992f, 24f, 47.96997f);
                    }
                    changementPosition3 = true;
                }
            }
        }

        //onServeurSceneChanged
        /* if(y =="serveur")
         {
             serveurScene = NetworkManager.networkSceneName;
         }
         if (y=="client")
         {
             clientScene = NetworkManager.networkSceneName;
         }

         if (serveurScene != clientScene)
         {

             Debug.Log("changescene :" + serveurScene + clientScene);
             if (y=="serveur")
             {
                 NetworkManager.singleton.ServerChangeScene(clientScene);
             }
         }*/

        //Suppression du joystick pour les clients
        GameObject joystick = GameObject.Find("Fixed Joystick");
        if (y == "client" && joystick != null)
        {
            joystick.SetActive(false);
            //Destroy(joystick);
        }

        GameObject go = GameObject.Find("Multi Cameras");

        if (go != null)
        {
            CameraSwitch other = (CameraSwitch)go.GetComponent(typeof(CameraSwitch));
            other.cameraPositionChange(x);

           
            //Association caméra inventaire au Canvas
            /*Canvas inventoryCanvas = GameObject.Find("InventoryCanvas").GetComponent<Canvas>();
            Camera inventoryCamera = GameObject.Find("Camera (5)").GetComponent<Camera>();
            Debug.Log(inventoryCanvas);
            Debug.Log(inventoryCamera);
            if (inventoryCamera != null && inventoryCanvas != null)
            {
                Debug.Log("passage");
                inventoryCanvas.worldCamera = inventoryCamera.GetComponent<Camera>();
            }*/

        }

        GameObject playerObj = GameObject.Find("Player(Clone)");
        if (playerObj != null)
        {
            if (SceneManager.GetActiveScene().name == "the last revelation 1")
            {
                if (!changementPosition1)
                {
                    foreach (GameObject player in GameObject.FindGameObjectsWithTag("PlayerClone"))
                    {
                        player.transform.position = new Vector3(0.01f, 2.16f, -3.51f);
                    }
                    changementPosition1 = true;
                }

            }
            else if (SceneManager.GetActiveScene().name == "Start scene")
            {
                if (!changementPosition2)
                {
                    foreach (GameObject player in GameObject.FindGameObjectsWithTag("PlayerClone"))
                    {
                        player.transform.position = new Vector3(70.75992f, 24f, 47.96997f);
                    }
                    changementPosition2 = true;
                }
            }
        }

    }
    
    void OnLevelWasLoaded()
    {
        if (configuration == null) Debug.LogError("SCREEN CONFIGURATION NOT FOUND!");
    }

    ConfigurationFile DeserializeConfigurationFile()
    {
        XmlSerializer xs = new XmlSerializer(typeof(ConfigurationFile));
        using (StreamReader rd = new StreamReader("Configuration.xml"))
        {
            ConfigurationFile spos = xs.Deserialize(rd) as ConfigurationFile;

            return spos;
        }
    }

    void SerializeConfigurationFile()
    {
        XmlSerializer xs = new XmlSerializer(typeof(ConfigurationFile));
        using (StreamWriter wr = new StreamWriter("Configuration.xml"))
        {
            ConfigurationFile cf = new ConfigurationFile();
            cf.position = "CG";
            cf.serveur = "serveur";

            xs.Serialize(wr, cf);
        }
    }
}
public class ConfigurationFile
{
    //Position de l'ecran : G, CG, CD, D
    public string position;

    //Network : serveur, client
    public string serveur;
}
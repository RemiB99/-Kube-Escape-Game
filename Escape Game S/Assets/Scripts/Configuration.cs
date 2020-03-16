using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

public class Configuration : MonoBehaviour
{
    CameraSwitch cs;
    /*
     * Gestion de l'ecran et du network (serveur ou client)
    */

    public ConfigurationFile configuration;
    private int x;

    // Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(this);
        configuration = DeserializeConfigurationFile();
        if (configuration == null)  {
            Debug.LogError("SCREEN CONFIGURATION NOT FOUND!");
        }
        else {
            Debug.LogWarning("Screen configuration found: " + configuration.position + ", " + configuration.serveur);
            x = int.Parse(configuration.position);

            /*GameObject go = GameObject.Find("Multi Cameras");
            
                CameraSwitch other = (CameraSwitch)go.GetComponent(typeof(CameraSwitch));
                other.cameraPositionChange(x);*/
            
            
        }
    }

    void Update()
    {
        GameObject go = GameObject.Find("Multi Cameras");
        
        if(go != null) {
            CameraSwitch other = (CameraSwitch)go.GetComponent(typeof(CameraSwitch));
            other.cameraPositionChange(x);
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
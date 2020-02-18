using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

public class Configuration : MonoBehaviour
{
    /*
     * Gestion de l'ecran et du network (serveur ou client)
    */

    public ConfigurationFile configuration;

    // Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(this);
        configuration = DeserializeConfigurationFile();
        if (configuration == null) Debug.LogError("SCREEN CONFIGURATION NOT FOUND!");
        else Debug.LogWarning("Screen configuration found: " + configuration.position + ", " + configuration.serveur);
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
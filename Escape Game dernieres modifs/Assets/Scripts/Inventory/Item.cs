//script projet

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public int id;
    public string type;
    public string description;
    public string use;
    public Sprite icon;
    public bool playersObject;
    public Text descriptionText;
    public Text usingText;

    private GameObject AO;
    private Image ActiveObject;

    [HideInInspector] public bool occupied;
    [HideInInspector] public bool pickedUp;
    [HideInInspector] public bool equipped;
    [HideInInspector] public GameObject livre;
    [HideInInspector] public GameObject livre1;
    [HideInInspector] public GameObject itemManager;
    [HideInInspector] public GameObject itemManagerCanvas;
    

    void Start()
    {
        AO = GameObject.Find("Active Object");
        ActiveObject = AO.GetComponent<Image>();
    
    }

    void Update()
    { 
        itemManager = GameObject.FindWithTag("ItemManager"); 
        itemManagerCanvas = GameObject.Find("ItemManagerCanvas");
        
        if (!playersObject)
        {
            
            int allItems = itemManager.transform.childCount;
            for (int i = 0; i < allItems; i++)
            {
                if (itemManager.transform.GetChild(i).gameObject.GetComponent<Item>().id == id)
                {
                    livre = itemManager.transform.GetChild(i).gameObject;
                    
                }
            }
            
            int allItemsCanvas = itemManagerCanvas.transform.childCount;
            for (int i = 0; i < allItemsCanvas; i++)
            {
                if (itemManagerCanvas.transform.GetChild(i).gameObject.GetComponent<Item>().id == id)
                {
                    livre = itemManagerCanvas.transform.GetChild(i).gameObject;
                    
                }
            }
        }
    }


    public void ItemUsage()
    {
        //c'est la où nous allons gérer les type

        if (type == "Livre")
        {           
            usageObgetNormal();
        }
        else if (type == "ObjetEnigme")
        {           
            usageObjetEnigme();   
        }
    }


    public void usageObgetNormal()
    {
        for (int i = 0; i < itemManager.transform.childCount; i++)
        {
            if (itemManager.transform.GetChild(i).gameObject.GetComponent<Item>().equipped)
            {
                occupied = true;
            }
        }

        if (!livre.GetComponent<Item>().equipped && !occupied)
        {
            livre.SetActive(true);
            livre.GetComponent<Item>().equipped = true;
            descriptionText.text = livre.GetComponent<Item>().description;
            usingText.text = livre.GetComponent<Item>().use;
            ActiveObject.color = new Color(255, 255, 255, 255);
            ActiveObject.sprite = livre.GetComponent<Item>().icon;
        }
        else
        {
            descriptionText.text = "Vous avez les mains libres, vous pouvez prendre un objet de votre inventaire";
            usingText.text = "";
            ActiveObject.color = new Color(255, 255, 255, 0);

            if (occupied && !livre.GetComponent<Item>().equipped)
            {
                descriptionText.text = "Vous portez déjà un objet !";
                ActiveObject.color = new Color(255, 255, 255, 255);
            }
            livre.SetActive(false);
            livre.GetComponent<Item>().equipped = false;
            occupied = false;
        }
    }

    public void usageObjetEnigme()
    {
        
        for (int i = 0; i < itemManagerCanvas.transform.childCount; i++)
        {
            if (itemManagerCanvas.transform.GetChild(i).gameObject.GetComponent<Item>().equipped)
            {
                occupied = true;
            }
        }

        if (!livre.GetComponent<Item>().equipped && !occupied)
        { 
			GameObject.Find("Canvas").GetComponent<Inventory>().inventoryEnabled =false;
            livre.SetActive(true);
            livre.GetComponent<Item>().equipped = true;
        }
    }

    public void close()
    {
        livre.SetActive(false);
        livre.GetComponent<Item>().equipped = false;
        occupied = false;  
    }  
}
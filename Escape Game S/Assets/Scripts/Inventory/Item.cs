using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public int id;
    public string type;
    public string description;
    public Sprite icon;
    public bool playersObject;
    public Text descriptionText;

    [HideInInspector] public bool occupied;
    [HideInInspector] public bool pickedUp;
    [HideInInspector] public bool equipped;
    [HideInInspector] public GameObject livre;
    [HideInInspector] public GameObject livre1;
    [HideInInspector] public GameObject itemManager;

    void Update()
    {
        
        itemManager = GameObject.FindWithTag("ItemManager");
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
        }
    }


    public void ItemUsage()
    {
        //c'est la où nous allons gérer les type

        if(type == "Livre")
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
            }
            else 
            {     
                descriptionText.text = "vous avez les mains libres, vous pouvez prendre un objet de votre inventaire";
                
                if(occupied && !livre.GetComponent<Item>().equipped)
                {
                    descriptionText.text = "vous portez déjà un objet !";
                }

                livre.SetActive(false);
                livre.GetComponent<Item>().equipped = false;
                occupied = false;

            }
            
        }
    }
}

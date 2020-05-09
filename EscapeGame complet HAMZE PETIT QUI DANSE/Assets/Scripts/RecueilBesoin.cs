using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RecueilBesoin : MonoBehaviour
{

    public GameObject enigme;
    private bool[] buttonsBool = new bool[25];
    private GameObject[] buttons = new GameObject[25];
    private bool gagner;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 25; i++)
        {
            buttonsBool[i] = false;
            buttons[i] = enigme.transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 25; i++)
        {
            if (Input.GetMouseButtonDown(0) && EventSystem.current.currentSelectedGameObject == buttons[i])
            {
                if (buttons[i].name != "Fini" && buttons[i].name != "Retour")
                {
                    buttonClicked(i); 
                }
                else if (buttons[i].name == "Fini")
                {
                    verifierChoix();
                    buttonFini();
                }
            }
        }
    }

    public void buttonClicked(int indice)
    {
        buttonsBool[indice] = !buttonsBool[indice];
        if (buttonsBool[indice])
        {
            buttons[indice].GetComponent<Image>().color = Color.green;
        }
        else
        {
            buttons[indice].GetComponent<Image>().color = Color.white;
        }
    }

    public void verifierChoix()
    {
         if ( buttonsBool[2] && buttonsBool[3] && buttonsBool[4] && buttonsBool[5] && buttonsBool[6] &&
              buttonsBool[7] && buttonsBool[8] && buttonsBool[9] && buttonsBool[10] && buttonsBool[11])
         {
            gagner = true;
         }
         else
         {
            gagner = false;
         }
    }

    public void buttonFini()
    {
        if (gagner)
        {
            GameObject inv = GameObject.Find("Canvas");
            GameObject backLog = GameObject.Find("BackLog");
            GameObject slotHolder = GameObject.Find("Slot Holder");
            GameObject slot, panel;

            Item item = backLog.GetComponent<Item>();
            inv.GetComponent<Inventory>().AddItem(backLog, item.id, item.type, item.description, item.icon, item.use);

            for (int j = 0; j < slotHolder.transform.childCount; j++)
            {
                slot = slotHolder.transform.GetChild(j).gameObject;
                panel = slot.transform.GetChild(0).gameObject;

                if (enigme.GetComponent<Item>().icon == panel.GetComponent<Image>().sprite)
                {
                    slot.GetComponent<Slot>().empty = true;
                    panel.GetComponent<Image>().sprite = null;
                    slot.SetActive(false);
                }
            }
            Destroy(enigme);
            Debug.Log("vous avez gagné");
        }
        else
        {
            Debug.Log("vous avez perdu");
        }
        
    }
}

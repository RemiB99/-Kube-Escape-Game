using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlanningPoker : MonoBehaviour
{
    public GameObject enigme;
    private int nbButtons = 10;
    private int nbCartes = 5;
    private int nbUserStories = 10;

    private bool[] buttonsBool;
    private GameObject[] carts;
    private bool[] cartsBool;
    private GameObject[] buttons;
    private int[] cartsValeur;
    private int somme;
    private bool gagner;
    
    // Start is called before the first frame update
    void Start()
    {
        buttons = new GameObject[nbButtons];
        buttonsBool = new bool[nbButtons];
        carts = new GameObject[nbCartes];
        cartsBool = new bool[nbCartes];
        cartsValeur = new int[nbCartes];
        somme = 0;
        gagner = false;
        

        for (int i = 0; i < nbButtons; i++)
        { 
            buttons[i] = enigme.transform.GetChild(i).gameObject;
        }
        initCarts();       
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < nbButtons; i++)
        {
            if (Input.GetMouseButtonDown(0) && EventSystem.current.currentSelectedGameObject == buttons[i])
            {
                if (buttons[i].name != "FiniPP" && buttons[i].name != "RetourPP")
                {
                    buttonClicked(i);
                }
                else if (buttons[i].name == "FiniPP")
                {
                    verifierChoix();
                    buttonFini();
                }
            }
        }
    }

    public void initCarts()
    {
        
        for (int i = 0; i < nbButtons; i++)
        {
            
            if (buttons[i].name == "Carte1")
            {
                //buttons[i].gameObject.GetComponent<Image>().color = Color.red;
                carts[0] = buttons[i].gameObject;
                cartsValeur[0] = 1;
            }
            else if (buttons[i].name == "Carte2")
            {
                //buttons[i].gameObject.GetComponent<Image>().color = Color.green;
                carts[1] = buttons[i].gameObject;
                cartsValeur[1] = 3;
            }
            else if (buttons[i].name == "Carte3")
            {
                //buttons[i].gameObject.GetComponent<Image>().color = Color.yellow;
                carts[2] = buttons[i].gameObject;
                cartsValeur[2] = 5;
            }
            else if (buttons[i].name == "Carte4")
            {
                //buttons[i].gameObject.GetComponent<Image>().color = Color.cyan;
                carts[3] = buttons[i].gameObject;
                cartsValeur[3] = 8;
            }
            else if (buttons[i].name == "Carte5")
            {
                //buttons[i].gameObject.GetComponent<Image>().color = Color.magenta;
                carts[4] = buttons[i].gameObject;
                cartsValeur[4] = 13;
            }
        }
    }

    public bool estCarte(int i)
    {
        return (buttons[i].name == "Carte1" || buttons[i].name == "Carte2" ||
                buttons[i].name == "Carte3" || buttons[i].name == "Carte4" ||
                buttons[i].name == "Carte5");
    }

    public int getIndexCart(int i)
    {
        if (buttons[i].name == "Carte1") return 0;
        else if (buttons[i].name == "Carte2") return 1;
        else if (buttons[i].name == "Carte3") return 2;
        else if (buttons[i].name == "Carte4") return 3;
        else if (buttons[i].name == "Carte5") return 4;
        else return -1;
    }
    public void buttonClicked(int i)
    {
        if (estCarte(i))
        {
            for(int m = 0; m < nbButtons; m++)
            {
                if (estCarte(m) && getIndexCart(m) != -1)
                {
                    int index = getIndexCart(m);
                    cartsBool[index] = false;
                }
            }
             cartsBool[getIndexCart(i)] = true;
        }
        else
        {
            for(int j = 0; j < nbCartes; j++)
            {
                if (cartsBool[j])
                {
                    buttons[i].GetComponent<Image>().sprite = carts[j].GetComponent<Image>().sprite;
                }
            }
        }
    }

    public bool estUserStory(int i)
    {
        return (!estCarte(i) && buttons[i].name != "FiniPP" && buttons[i].name != "RetourPP");
    }

    public void verifierChoix()
    {
        for(int i = 0; i < nbButtons; i++)
        {
            if (estUserStory(i))
            {
                Sprite image = buttons[i].GetComponent<Image>().sprite;

                if      (image.name == "carte1")    somme += cartsValeur[0];
                else if (image.name == "carte3")    somme += cartsValeur[1];
                else if (image.name == "carte5")    somme += cartsValeur[2];
                else if (image.name == "carte8")    somme += cartsValeur[3];
                else if (image.name == "carte13")   somme += cartsValeur[4];  
            }
        }
        if(somme <= 100 )
        {
            gagner = true;
        }
    }

    public void buttonFini()
    {
        if (gagner)
        {
            
            GameObject inv = GameObject.Find("Canvas");
            GameObject userStories = GameObject.Find("UserStoriesEvalues");
            GameObject slotHolder = GameObject.Find("Slot Holder");
            GameObject slot, panel;

            Item item = userStories.GetComponent<Item>();
            inv.GetComponent<Inventory>().AddItem(userStories, item.id, item.type, item.description, item.icon, item.use);

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

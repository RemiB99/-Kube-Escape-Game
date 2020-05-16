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
    private Bouches bouches;
    private bool estPasse;


    // Start is called before the first frame update
    void Start()
    {
        estPasse = false;
        bouches = GameObject.Find("Bouches").GetComponent<Bouches>();
        for (int i = 0; i < 25; i++)
        {
            buttonsBool[i] = false;
            buttons[i] = enigme.transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enigme.activeSelf && !estPasse)
        {
            estPasse = true;
            StartCoroutine(expEnigmeBackLog());
        }

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
              buttonsBool[7] && buttonsBool[8] && buttonsBool[9] && buttonsBool[10] && buttonsBool[11] && estBon())
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
            GameObject backLog = GameObject.Find("BackLogFinal");
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
            bouches.animBoucheContente();
            bouches.setText(" Vous avez trouvé les 10 tâches à réaliser, ça fait peut-être beaucoup non ? Donner le backlog à l’assistant.");
        }
        else
        {
            Debug.Log("vous avez perdu");
            bouches.animBoucheFache();
            bouches.setText(" Ce n’est pas vraiment ce que la cliente souhaite... Réessayez.");
        }
        
    }

    public bool estBon()
    {
        return (!buttonsBool[12] && !buttonsBool[13] && !buttonsBool[14] && !buttonsBool[15] && !buttonsBool[16] &&
                !buttonsBool[17] && !buttonsBool[18] && !buttonsBool[19] && !buttonsBool[20] && !buttonsBool[21] &&
                !buttonsBool[22] && !buttonsBool[23] && !buttonsBool[24]);
    }

    IEnumerator expEnigmeBackLog()
    {
        bouches.animBoucheFache();
        bouches.setText("L’assistant n’a pas bien fait son travail… Ses notes sont complètement en désordre et ne retranscrivent pas le besoin de la cliente !");

        yield return new WaitForSeconds(5);
        bouches.animBoucheReflechi();
        bouches.setText("Essayons de remettre un peu d’ordre dans ces notes en sélectionnant 10 tâches que la cliente nous a demandé d’effectuer");
    }

}

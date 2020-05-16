using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Wanted : MonoBehaviour
{
    public GameObject enigme;
    private GameObject[] buttons;
    private bool[] buttonsBool;
    private int nbButtons;
    private bool gagner;
    private GameObject noticBoard;
    void Start()
    {
        nbButtons = 7;
        buttons = new GameObject[nbButtons];
        buttonsBool = new bool[nbButtons];
        GameObject en = enigme.transform.GetChild(0).gameObject;
        noticBoard = GameObject.Find("WantedPosters");

        for (int i = 0; i < nbButtons; i++)
        {
            buttonsBool[i] = true;
            buttons[i] = en.transform.GetChild(i).gameObject;
            if (i != 6 && i != 5)
            {
                buttons[i].transform.GetChild(0).gameObject.SetActive(false);
            }
            
        }
        gagner = false;
    }

    
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0) && hit.transform.name == "NoticeBoard")
            {
                enigme.SetActive(true);
            }
        }

        for (int i = 0; i < nbButtons; i++)
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
        if (buttonsBool[indice])
        {
            buttonsBool[indice] = false;
            buttons[indice].transform.GetChild(0).gameObject.SetActive(true);
            noticBoard.transform.GetChild(indice).gameObject.SetActive(false);

        }
        else
        {
            buttonsBool[indice] = true;
            buttons[indice].transform.GetChild(0).gameObject.SetActive(false);
            noticBoard.transform.GetChild(indice).gameObject.SetActive(true);
        }
    }

    public void verifierChoix()
    {
        if (buttonsBool[4] &&(!buttonsBool[0] && !buttonsBool[1] && !buttonsBool[2] && !buttonsBool[3] ))
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
            Debug.Log("vous avez gagné WANTEEED");
            GameObject client = GameObject.Find("Client");
            client.GetComponent<TextClient>().finEnigmeNom();
        }
        else
        {
            Debug.Log("vous avez perdu");
        }
    }


    public void close()
    {
        enigme.SetActive(false);
    }
}

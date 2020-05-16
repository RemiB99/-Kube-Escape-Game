using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Rebus : MonoBehaviour
{
    public GameObject book;
    private GameObject enigme;
    private GameObject[] buttons;
    private bool[] buttonsBool;
    private int nbButtons;
    private GameObject background;
    private bool gagner;

    // Start is called before the first frame update
    void Start()
    {
        nbButtons = 11;
        GameObject enigmePanel = GameObject.Find("EnigmePlaque");
        enigme = enigmePanel.transform.GetChild(0).gameObject;
        buttons = new GameObject[nbButtons];
        buttonsBool = new bool[nbButtons];
        background = enigme.transform.GetChild(0).gameObject;
        for (int i = 0; i < nbButtons; i++)
        {
            buttonsBool[i] = false;
            buttons[i] = background.transform.GetChild(i).gameObject;
        }
            
    }

    // Update is called once per frame
    void Update()
    {

        if (!enigme.activeSelf)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (Input.GetMouseButtonDown(0) && hit.transform.name == "BookEnigme")
                {
                    enigme.SetActive(true);
                }
            }
        }

        for (int i = 0; i < nbButtons; i++)
        {
            if (Input.GetMouseButtonDown(0) && EventSystem.current.currentSelectedGameObject == buttons[i])
            {
                if (buttons[i].name != "Fini")
                {
                    Debug.Log(buttons[i].name);
                    
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
        for(int i = 0; i < nbButtons; i++)
        {
            if (buttonsBool[i])
            {
                buttonsBool[i] = false;
                buttons[i].GetComponent<Image>().color = Color.white;
            }
        }
        buttonsBool[indice] = true;
        buttons[indice].GetComponent<Image>().color = Color.green;
    }

    public void verifierChoix()
    {
        if (buttonsBool[6])
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
            Debug.Log("vous avez gagné");
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

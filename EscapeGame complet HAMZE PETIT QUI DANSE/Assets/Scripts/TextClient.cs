using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class TextClient : MonoBehaviour
{
    public GameObject ZoneTextClient;
    public GameObject Client;
    private GameObject text;
    private bool zoneActive;
    private GameObject ampoule;
    private string[] texts;
    private int nbTexts = 25;
    private string textActuel;
    private GameObject[] objetChangemantText;
    private int nbObjets = 1;
    private bool estPassé;
    // Start is called before the first frame update
    void Start()
    {
        texts = new string[nbTexts];
        objetChangemantText = new GameObject[nbObjets];
        initTexts();
        findObjetChangementText();
        text = ZoneTextClient.transform.GetChild(0).gameObject;
        text.GetComponent<Text>().text =  texts[0];
        textActuel = texts[0];
        ampoule = GameObject.Find("Ampoule");
        ampoule.SetActive(false);
        zoneActive = false;
        estPassé = false;    
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit)) { 
            if (Input.GetMouseButtonDown(0))
            {
                if (hit.transform.name == "Client")
                {
                    changeZone();
                    ampoule.SetActive(false);
                }
                
                for(int i = 0; i < nbObjets; i++)
                {
                    if((objetChangemantText[i].transform.name == hit.transform.name) )
                    {
                        Debug.Log("1");
                        changeText();
                    }
                    if (objetChangemantText[i].transform.name == "index2" && objetChangemantText[i].activeSelf && !estPassé )
                    {
                        estPassé = true;
                        changeText();
                    }

                }
            }  
        }

        if (textHasChanged())
        {
            ampoule.SetActive(true);
        }
    }

    public void changeZone()
    {
        zoneActive = !zoneActive;
        ZoneTextClient.SetActive(zoneActive);
    }
    
    public void changeText()
    {
        for(int i = 0; i < nbTexts-1 ; i++)
        {
            if(textActuel == texts[i])
            {
                text.GetComponent<Text>().text = texts[i + 1];
            }
        }
    }

    public bool textHasChanged()
    {
        if (text.GetComponent<Text>().text != textActuel)
        {
            textActuel = text.GetComponent<Text>().text;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void initTexts()
    {
        texts[0] = " hello 1";
        texts[1] = " hello 2";
        texts[2] = " hello 3";
        texts[3] = " hello 4";
        texts[4] = " hello 5";
        texts[5] = " hello 6";
        texts[6] = " hello 7";
        texts[7] = " hello 8";
        texts[8] = " hello 9";
        texts[9] = " hello 10";
        texts[10] = " hello 11";
        texts[11] = " hello 12";
        texts[12] = " hello yolo";
        texts[13] = " hello 13";
        texts[14] = " hello 14";
        texts[15] = " hello 15";
        texts[16] = " hello 16";
        texts[17] = " hello 17";
        texts[18] = " hello 18";
        texts[19] = " hello 19";
        texts[20] = " hello 20";
        texts[21] = " hello 21";
        texts[22] = " hello 22";
        texts[23] = " hello 23";
        texts[24] = " hello 24";
    }

    public void findObjetChangementText()
    {
        GameObject hints = GameObject.Find("Hints");
        GameObject hint = hints.transform.GetChild(1).gameObject;
        objetChangemantText[0] = hint;
    }
}

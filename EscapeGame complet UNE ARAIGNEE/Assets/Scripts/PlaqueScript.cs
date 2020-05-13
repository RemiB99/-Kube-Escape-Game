using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlaqueScript : MonoBehaviour
{
    private bool isRayed = false;
    public GameObject[] textsPlaques = new GameObject[8];
    private bool[] boolPlaques = new bool[8];
    private bool fin = false;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Player Score", 2);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {   
                if (Input.GetMouseButtonDown(0) && hit.transform.tag == "TextPlaque")
                {   
                    Debug.Log(hit.transform.name);
                    if(!isRayed)
                        hit.transform.GetChild(0).gameObject.SetActive(true);
                    else
                        hit.transform.GetChild(0).gameObject.SetActive(false);
                    
                    isRayed = !isRayed;
                }
            }
        }

        if(finEnigme() && !fin){
            actionsFinEnigme();
            fin = true;
        }
    }

    public void actionsFinEnigme(){
        GameObject client = GameObject.Find("Client");
        client.GetComponent<TextClient>().finEnigmePlaque();
    }

    public bool finEnigme(){
        bool res = true;
        for(int i =0;i<textsPlaques.Length-1;i++){
            if(!textsPlaques[i].transform.GetChild(0).gameObject.activeSelf)
                res = false;
        }
        return res;
        /*GameObject bonnePlaque = GameObject.Find("TextPrepa");
        if(bonnePlaque.transform.GetChild(0).gameObject.activeSelf)
            return true;
        return false;*/
    }
}

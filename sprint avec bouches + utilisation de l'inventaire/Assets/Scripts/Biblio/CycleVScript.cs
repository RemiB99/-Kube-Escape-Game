using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CycleVScript : MonoBehaviour
{
    public GameObject[] bookTemp = new GameObject[5];
    public GameObject[] bookTab = new GameObject[5];
    public GameObject[] textBook = new GameObject[5];
    public GameObject[] objetsARecup = new GameObject[5];

    public GameObject inventaire;

    private string[] goodAnswer = new string[5];
    // Start is called before the first frame update
    void Start()
    {
        goodAnswer[0] = "Recueil des besoins";
        goodAnswer[1] = "Conception";
        goodAnswer[2] = "Réalisation";
        goodAnswer[3] = "Tests";
        goodAnswer[4] = "Maintenance";
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetMouseButtonDown(0)))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if ((Physics.Raycast(ray, out hit)))
            {
                GameObject contour = hit.transform.gameObject;
                //Debug.Log(contour);

                GameObject itemManager = GameObject.FindWithTag("ItemManager");
                int allItems = itemManager.transform.childCount;
                for (int i = 0; i < allItems; i++)
                {
                    GameObject objCourant = itemManager.transform.GetChild(i).gameObject;
                    Item scriptObjCourant = objCourant.GetComponent<Item>();

                    if (contour.tag =="Contour" && scriptObjCourant.equipped && scriptObjCourant.type == "LivreCycle" )
                    {
                        
                        // Met le livre "objet" correspondant a celui en main à l'endroit du clic
                        /*GameObject bookMove = livreInventaire(objCourant);
                        bookMove.GetComponent<Transform>().position = GameObject.Find(contour.name).GetComponent<Transform>().position;
                        bookMove.GetComponent<Transform>().Rotate(0,0,90);
                        bookMove.SetActive(true);*/
                        

                        GameObject book = contour.transform.GetChild(0).gameObject;
                        book.SetActive(true);
                        book.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = objCourant.transform.GetChild(0).GetComponent<TextMeshPro>().text;
                        
                        /*contour.GetComponent<LinkObjects>().destroyImage();
                        objCourant.SetActive(false);*/
                        
                        
                        //hit.transform.gameObject.tag =="LinkObject"
                        
                        if(estValide()){

                            GameObject potionJaune = GameObject.Find("PotionJaune");
                            Animator potion = potionJaune.GetComponent<Animator>();
                            potion.SetTrigger("PotionJaune");

                            
                        }
                        /*else if(livresPosés()){
                            GameObject canvas = GameObject.Find("Canvas");
                            for(int i=0;i<5;i++){
                                canvas.GetComponent<Inventory>().AddItem(objetsARecup[i],
                                                                        objetsARecup[i].id,
                                                                        objetsARecup[i].type,
                                                                        objetsARecup[i].description,
                                                                        objetsARecup[i].icon,
                                                                        objetsARecup[i].use);
                            }
                        }*/
                    }
                }
            }

        }
    }

    public bool estValide(){
        /*int i=0;
        foreach(var text in textBook){
            if(textBook[i].GetComponent<TextMeshPro>().text != goodAnswer[i])
                return false;
            i++;
        }
        return true;*/
        string recueil = bookTemp[0].transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text;
        string conception = bookTemp[1].transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text;
        string real = bookTemp[2].transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text;
        string test = bookTemp[3].transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text;
        string maintenance = bookTemp[4].transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text;

        if(goodAnswer[0]== recueil && goodAnswer[1]== conception && goodAnswer[2]== real && goodAnswer[3]== test && goodAnswer[4]== maintenance){
            
            return true;
        }
        else
            return false;
    }

    public bool livresPosés(){
        return bookTemp[0].activeSelf && bookTemp[1].activeSelf && bookTemp[2].activeSelf && bookTemp[3].activeSelf && bookTemp[4].activeSelf;
        
    }

    public GameObject livreInventaire(GameObject livreCourant){
        int idCourant = livreCourant.GetComponent<Item>().id;
        foreach(var book in bookTab){
            if(book.GetComponent<Item>().id == idCourant)
                return book;
        }
        return null;
    }
}


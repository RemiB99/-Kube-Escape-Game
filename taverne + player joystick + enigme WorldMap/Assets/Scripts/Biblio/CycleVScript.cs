using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CycleVScript : MonoBehaviour
{
    public GameObject[] textsWall = new GameObject[5];
    public GameObject[] bookPlacés = new GameObject[5];
    private GameObject bouche;


    private string[] goodAnswer = new string[5];
    private bool hasPassed = false;
    // Start is called before the first frame update
    void Start()
    {
        goodAnswer[0] = "Recueil des besoins";
        goodAnswer[1] = "Conception";
        goodAnswer[2] = "Réalisation";
        goodAnswer[3] = "Tests";
        goodAnswer[4] = "Maintenance";

        bouche = GameObject.Find("Bouches");
    }

    // Update is called once per frame
    void Update()
    {
        /*if ((Input.GetMouseButtonDown(0)))
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
                        GameObject bookMove = livreInventaire(objCourant);
                        bookMove.GetComponent<Transform>().position = GameObject.Find(contour.name).GetComponent<Transform>().position;
                        bookMove.GetComponent<Transform>().Rotate(0,0,90);
                        bookMove.SetActive(true);
                        

                        GameObject book = contour.transform.GetChild(0).gameObject;
                        book.SetActive(true);
                        book.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = objCourant.transform.GetChild(0).GetComponent<TextMeshPro>().text;
                        
                        contour.GetComponent<LinkObjects>().destroyImage();
                        objCourant.SetActive(false);
                        
                        
                        //hit.transform.gameObject.tag =="LinkObject"*/
                        
                        if(estValide() && !hasPassed){

                            
                            animBiblio();
                            bouche.GetComponent<Bouches>().animBoucheContente();
                            bouche.GetComponent<Bouches>().setText("Bien joué ! Ce sont bien les 5 étapes du cycle en V " +
                                                                    " Voyons maintenant comment vous allez gérer un projet " +
                                                                    " Et si vous alliez voir ce miroir de plus près...");

                            
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

    public bool estValide(){
        
        bool bienPlace = false;

        foreach(var book in bookPlacés){
            if(book.activeSelf)
                bienPlace = true;
            else
                bienPlace = false;
        }
        string recueil = textsWall[0].GetComponent<TextMeshPro>().text;
        string conception = textsWall[1].GetComponent<TextMeshPro>().text;
        string real = textsWall[2].GetComponent<TextMeshPro>().text;
        string test = textsWall[3].GetComponent<TextMeshPro>().text;
        string maintenance = textsWall[4].GetComponent<TextMeshPro>().text;

        return bienPlace && goodAnswer[0]== recueil && goodAnswer[1]== conception && goodAnswer[2]== real && goodAnswer[3]== test && goodAnswer[4]== maintenance;
    }

    void animBiblio(){

        GameObject potionJaune = GameObject.Find("PotionJaune");
                            Animator potion = potionJaune.GetComponent<Animator>();
                            potion.SetTrigger("PotionJaune");
                            hasPassed = true;

        GameObject bookCase = GameObject.Find("bookCaseMoveLeft");
        GameObject bookCase3 = GameObject.Find("bookCaseMove");
        
        Animator bookcaseReveal = bookCase.GetComponent<Animator>();

        Animator bookcaseReveal3 = bookCase3.GetComponent<Animator>();
        bookcaseReveal.SetTrigger("BookCaseLeftMove");

        bookcaseReveal3.SetTrigger("MoveBookCase");

        GameObject contour = GameObject.Find("ContourLivre");
        contour.GetComponent<Outline>().enabled = true;

        
        bookCase.GetComponent<AudioSource>().Play();
    }

    /*public bool livresPosés(){
        return bookTemp[0].activeSelf && bookTemp[1].activeSelf && bookTemp[2].activeSelf && bookTemp[3].activeSelf && bookTemp[4].activeSelf;
        
    }

    public GameObject livreInventaire(GameObject livreCourant){
        int idCourant = livreCourant.GetComponent<Item>().id;
        foreach(var book in bookTab){
            if(book.GetComponent<Item>().id == idCourant)
                return book;
        }
        return null;
    }*/
}


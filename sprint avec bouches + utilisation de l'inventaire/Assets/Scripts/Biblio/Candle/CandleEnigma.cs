using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CandleEnigma : MonoBehaviour
{
    public GameObject candle;
    public GameObject bookConcerned;
    private bool hasMoved = false;
    private bool[] candlesAnswer = new bool[13];
    private bool[] candlesScene = new bool[13];
    private CandleEnigma scriptWall;

    private string[] textesBouche = new string[20];
    private GameObject bouche;
    // Start is called before the first frame update
    void Start()
    {
        initializeTab();
        GameObject globalCandle = GameObject.Find("CandleWall13");
        scriptWall = globalCandle.GetComponent<CandleEnigma>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetMouseButtonDown(0)))
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if( (Physics.Raycast(ray, out hit))){

                GameObject clic = hit.transform.gameObject;
                GameObject itemManager = GameObject.FindWithTag("ItemManager");
                int allItems = itemManager.transform.childCount;
                for (int i = 0; i < allItems; i++){
                    GameObject objCourant = itemManager.transform.GetChild(i).gameObject;
                    Item scriptObjCourant = objCourant.GetComponent<Item>();
                
                    if (bookConcerned == objCourant && scriptObjCourant.equipped && clic.name == "TableauBougie"){
                    
                        
                        lightOffCandle(candle);
                        objCourant.SetActive(false);
                        //enelever de l'inventaire
                    
                        if(codeBon() && !hasMoved){
                        
                            animBiblio();
                            revealBooks();
                            GameObject bouche = GameObject.Find("Bouches");
                            bouche.GetComponent<Bouches>().animBoucheContente();
                            bouche.GetComponent<Bouches>().setText("Bien joué ! Allons voir ce que ces bibliothèques nous cachaient...");
                        
                        }
                    }

                    else if(bookConcerned == null && scriptObjCourant.equipped && clic.name == "TableauBougie"){


                    }
                
                
                }
            }
        }
    
    }

    void initializeTab(){
        for(int i=0;i<candlesAnswer.Length;i++){
            candlesAnswer[i] = false;
            candlesScene[i] = false;
        }
        candlesAnswer[0] = true;
        candlesAnswer[2] = true;
        candlesAnswer[6] = true;
        candlesAnswer[8] = true;
        candlesAnswer[10] = true;

    }
    void lightOffCandle(GameObject candle){
        
        
        
        if(candle.name != "CandleWall13"){

        //modif tableau bougies
        string str = candle.transform.name;
        int number = int.Parse(str.Substring(str.Length - 2));
        scriptWall.candlesScene[number-1] = !(scriptWall.candlesScene[number-1]);

        Light light = candle.GetComponentInChildren<Light>();
        MeshRenderer mesh = candle.GetComponentInChildren<MeshRenderer>();
        light.enabled = !light.enabled;
        mesh.enabled = !mesh.enabled;
        candle.GetComponent<AudioSource>().Play();
        candle.transform.GetChild(3).gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    bool codeBon(){
        for(int i=0;i<candlesAnswer.Length-1;i++){
            if(candlesAnswer[i] != scriptWall.candlesScene[i])
                return false;
        }
        return true;
    }
    
    void testTab(bool[] test){
        for(int i=0;i<test.Length-1;i++){
            Debug.Log(test[i]);
        }
    }

    void animBiblio(){
        GameObject bookCase = GameObject.Find("bookCaseMoveLeft");
        GameObject bookCase2 = GameObject.Find("bookCaseMoveRight");
        GameObject bookCase3 = GameObject.Find("bookCaseMove");
        
        Animator bookcaseReveal = bookCase.GetComponent<Animator>();
        Animator bookcaseReveal2 = bookCase2.GetComponent<Animator>();
        Animator bookcaseReveal3 = bookCase3.GetComponent<Animator>();
        bookcaseReveal.SetTrigger("BookCaseLeftMove");
        bookcaseReveal2.SetTrigger("BookCaseRightMove");
        bookcaseReveal3.SetTrigger("MoveBookCase");

        //GameObject contour = GameObject.Find("ContourLivre");
        //contour.GetComponent<Outline>().enabled = true;

        
        bookCase.GetComponent<AudioSource>().Play();
        

        hasMoved = true;

    }

    void revealBooks(){


        GameObject.Find("PotionVerte").GetComponent<Outline>().enabled = true;
        GameObject.Find("PotionViolette").GetComponent<Outline>().enabled = true;
        GameObject.Find("PotionBleue").GetComponent<Outline>().enabled = true;
        GameObject.Find("ContourRecueil").GetComponent<Outline>().enabled = true;
        GameObject.Find("ContourConception").GetComponent<Outline>().enabled = true;
        GameObject.Find("ContourRealisation").GetComponent<Outline>().enabled = true;
        GameObject.Find("ContourTests").GetComponent<Outline>().enabled = true;
        GameObject.Find("ContourMaintenance").GetComponent<Outline>().enabled = true;

    }
    void animCandleWall(GameObject candle){
        Animator moveCandle = candle.GetComponent<Animator>();
        moveCandle.SetTrigger("MoveCandleWall");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleEnigma : MonoBehaviour
{
    public GameObject candle;
    public GameObject book1;
    public GameObject book2;
    public GameObject book3;
    public GameObject book4;
    public GameObject book5;
    private bool hasMoved = false;
    private bool[] candlesAnswer = new bool[13];
    private bool[] candlesScene = new bool[13];
    private CandleEnigma scriptWall;
    // Start is called before the first frame update
    void Start()
    {
        initializeTab();
        GameObject globalCandle = GameObject.Find("CandleWall13");
        scriptWall = globalCandle.GetComponent<CandleEnigma>();
        
        book1 = GameObject.Find("BookRecueil");
        book2 = GameObject.Find("BookConception");
        book3 = GameObject.Find("BookCode");
        book4 = GameObject.Find("BookTests");
        book5 = GameObject.Find("BookMaintenance");
        
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetMouseButtonDown(0)))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if( (Physics.Raycast(ray, out hit)))
                if (hit.transform.name == candle.transform.name){
                    
                    
                    lightOffCandle(candle);
                    
                    if(codeBon() && !hasMoved){
                        
                        animBiblio();
                        revealBooks();
                        GameObject bouche = GameObject.Find("Bouches");
                        bouche.GetComponent<Bouches>().animBoucheContente();
                        bouche.GetComponent<Bouches>().setText("Bien joué ! Allons voir ce que ces bibliothèques nous cachaient...");
                        
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
        book1.GetComponent<MeshRenderer>().enabled = true;
        book1.GetComponent<BoxCollider>().enabled = true;
        book1.GetComponent<Outline>().enabled = true;

        book2.GetComponent<MeshRenderer>().enabled = true;
        book2.GetComponent<BoxCollider>().enabled = true;
        book2.GetComponent<Outline>().enabled = true;

        book3.GetComponent<MeshRenderer>().enabled = true;
        book3.GetComponent<BoxCollider>().enabled = true;
        book3.GetComponent<Outline>().enabled = true;

        book4.GetComponent<MeshRenderer>().enabled = true;
        book4.GetComponent<BoxCollider>().enabled = true;
        book4.GetComponent<Outline>().enabled = true;

        book5.GetComponent<MeshRenderer>().enabled = true;
        book5.GetComponent<BoxCollider>().enabled = true;
        book5.GetComponent<Outline>().enabled = true;

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

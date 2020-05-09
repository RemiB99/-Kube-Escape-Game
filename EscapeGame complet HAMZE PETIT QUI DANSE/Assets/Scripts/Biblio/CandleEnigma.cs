using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CandleEnigma : MonoBehaviour
{
    public GameObject candle;
    public GameObject bookConcerned;
    public bool isAlive = false;
    private bool hasMoved = false;
    //private bool[] candlesAnswer = new bool[5];
    private bool[] candlesScene = new bool[5];
    private CandleEnigma scriptWall;
    private bool hasPlayedBouche = false;

    private string[] textesBouche = new string[20];
    private GameObject bouche;
    // Start is called before the first frame update
    void Start()
    {
        initializeTab();
        GameObject globalCandle = GameObject.Find("CandleWall13");
        scriptWall = globalCandle.GetComponent<CandleEnigma>();
        bouche = GameObject.Find("Bouches");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasPlayedBouche){
            StartCoroutine(blablaBouche());
            hasPlayedBouche = true;
        }

        /*if((Input.GetMouseButtonDown(0)))
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
                        //enelever de l'inventaire*/
                    
        if(codeBon() && !hasMoved){
            StartCoroutine(animFinActivite());
        }
    }
                
                
                
            
        
    
    
    IEnumerator blablaBouche(){
        bouche.GetComponent<Bouches>().animBoucheContente();
        bouche.GetComponent<Bouches>().setText("Ah, nous voila dans un tout autre décor, c'est ici que notre aventure commence !"
                                                + "");
        yield return new WaitForSeconds(5);
        bouche.GetComponent<Bouches>().animBoucheContente();
        bouche.GetComponent<Bouches>().setText("Nous allons d'abord aborder certaines bases dans la gestion d'un projet"
                                                +"Essayez de voir si vous pouvez trouver des choses intéressantes");
        
    }
    void initializeTab(){
        for(int i=0;i<candlesScene.Length;i++){
            candlesScene[i] = false;
        }
        /*candlesAnswer[0] = true;
        candlesAnswer[2] = true;
        candlesAnswer[6] = true;
        candlesAnswer[8] = true;
        candlesAnswer[10] = true;*/

    }
    public void lightOffCandle(GameObject candle){
        
        Light light = candle.GetComponentInChildren<Light>();
        MeshRenderer mesh = candle.GetComponentInChildren<MeshRenderer>();

        if(candle.name != "CandleWall13"){

            if(!isAlive){
                //modif tableau bougies
                string str = candle.transform.name;
                int number = int.Parse(str.Substring(str.Length - 2));
                scriptWall.candlesScene[number-1] = !(scriptWall.candlesScene[number-1]);

                
                light.enabled = !light.enabled;
                mesh.enabled = !mesh.enabled;
                candle.GetComponent<AudioSource>().Play();
                candle.transform.GetChild(3).gameObject.GetComponent<MeshRenderer>().enabled = true;
                isAlive = true;
            }
        }
    }

    bool codeBon(){
        for(int i=0;i<candlesScene.Length;i++){
            if(!candlesScene[i])
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
        //GameObject bookCase = GameObject.Find("bookCaseMoveLeft");
        GameObject bookCase2 = GameObject.Find("bookCaseMoveRight");
        //GameObject bookCase3 = GameObject.Find("bookCaseMove");
        
        //Animator bookcaseReveal = bookCase.GetComponent<Animator>();
        Animator bookcaseReveal2 = bookCase2.GetComponent<Animator>();
        //Animator bookcaseReveal3 = bookCase3.GetComponent<Animator>();
        //bookcaseReveal.SetTrigger("BookCaseLeftMove");
        bookcaseReveal2.SetTrigger("BookCaseRightMove");
        //bookcaseReveal3.SetTrigger("MoveBookCase");

        //GameObject contour = GameObject.Find("ContourLivre");
        //contour.GetComponent<Outline>().enabled = true;

        
        bookCase2.GetComponent<AudioSource>().Play();

        GameObject.Find("ContourRecueil").GetComponent<Outline>().enabled = true;
        GameObject.Find("ContourConception").GetComponent<Outline>().enabled = true;
        GameObject.Find("ContourRealisation").GetComponent<Outline>().enabled = true;
        GameObject.Find("ContourTests").GetComponent<Outline>().enabled = true;
        GameObject.Find("ContourMaintenance").GetComponent<Outline>().enabled = true;
        

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

    public void destroyBooks(){
        GameObject itemManag = GameObject.Find("ItemManager");
        GameObject objInv = GameObject.Find("ObjetsInventaire");
        for (int i = 0; i < itemManag.transform.childCount; i++)
        {
        GameObject objCourant = itemManag.transform.GetChild(i).gameObject;
            if (objCourant.GetComponent<Item>().id == 11 || objCourant.GetComponent<Item>().id == 12 || objCourant.GetComponent<Item>().id == 13                    || objCourant.GetComponent<Item>().id == 14 || objCourant.GetComponent<Item>().id == 15){
                Destroy(objCourant);
            }
        }
        for (int j = 0; j < objInv.transform.childCount; j++)
        {
        GameObject objCourant = objInv.transform.GetChild(j).gameObject;
            if (objCourant.GetComponent<Item>().id == 11 || objCourant.GetComponent<Item>().id == 12 || objCourant.GetComponent<Item>().id == 13                    || objCourant.GetComponent<Item>().id == 14 || objCourant.GetComponent<Item>().id == 15){
                Destroy(objCourant);
            }
        }    GameObject SlotHolder = GameObject.Find("Slot Holder");
        for (int j = 0; j < SlotHolder.transform.childCount; j++)
        {
        GameObject Slot = SlotHolder.transform.GetChild(j).gameObject;
        GameObject panel = Slot.transform.GetChild(0).gameObject;
            if (Slot.GetComponent<Slot>().id == 11 || Slot.GetComponent<Slot>().id == 12 || Slot.GetComponent<Slot>().id == 13                    || Slot.GetComponent<Slot>().id == 14 || Slot.GetComponent<Slot>().id == 15){
            Slot.GetComponent<Slot>().empty = true;
            panel.GetComponent<Image>().sprite = null;
            Slot.SetActive(false);
            }
        }
    }
    IEnumerator animFinActivite(){
        animBiblio();
        bouche.GetComponent<Bouches>().animBoucheContente();
        bouche.GetComponent<Bouches>().setText("Bien joué ! Allons voir ce que cette bibliothèque nous cachait...");
        destroyBooks();
        yield return new WaitForSeconds(5);
        bouche.GetComponent<Bouches>().animBoucheReflechi();
        bouche.GetComponent<Bouches>().setText("Cette forme me rapelle une ancienne méthode qu'utilisaient les sorciers de l'informatique..."
                                                    +"Ils appelaient ça 'Cycle en V' je crois... ");
    }
        
    
}

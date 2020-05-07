﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LinkObjects : MonoBehaviour
{
    private GameObject itemManager;
    public int id;
    private GameObject listeObjetsInventaires;
    private GameObject objMain;
    private GameObject objRecuperable;
    private GameObject SlotHolder;
    private GameObject Description;
    private GameObject Use;
    private GameObject Slot;
    private GameObject panel;
    private GameObject objetCliqué;

    private string[] textesBouche = new string[20];
    private GameObject bouche;


    void Start(){

        textesBouche[1] = " : Hmmmm...Croyez vous vraiment que cela représente une étape clé du cycle de vie d'un logiciel";
        textesBouche[2] = " : Très bon choix ! C'est une étape importante dans le cycle de vie d'un logiciel ! Bien joué !";
        textesBouche[3] = "Très bon choix... Espérons que cela continue !";
        textesBouche[4] = "Félicitations ! Utilisez la à bon escient, les conséquences pourraient être fatales";

        bouche = GameObject.Find("Bouches");

        listeObjetsInventaires = GameObject.Find("ObjetsInventaire");


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
                
                objetCliqué = hit.transform.gameObject;
                if (hit.transform.gameObject.tag =="LinkObject")
                {
                    
                    itemManager = GameObject.FindWithTag("ItemManager");
                    int allItems = itemManager.transform.childCount;
                    for (int i = 0; i < allItems; i++)
                    {
                        
                        
                        objMain = itemManager.transform.GetChild(i).gameObject;  
                        SlotHolder = GameObject.Find("Slot Holder");
                        Description = GameObject.Find("Description");
                        Use = GameObject.Find("Use");

                        
                        
                        if (objMain.GetComponent<Item>().id == objetCliqué.GetComponent<LinkObjects>().id 
                            && objMain.GetComponent<Item>().equipped
                            )
                        {
                            startAction(true);
                        }

                        else if(objetCliqué.GetComponent<LinkObjects>().id == 56 && testObjetMainLivresCycle() && objMain.GetComponent<Item>().equipped)
                        { // cas des livres sur mur Cycle en V
                            startAction(true);
                            PlaceLivreMurCycle();
                        }

                        else if(objetCliqué.GetComponent<LinkObjects>().id == 50 && testObjetMainLivresCycle() && objMain.GetComponent<Item>().equipped)
                        { // cas des bons livres sur la validation (Activité 1)
                            startAction(false);
                            
                        }
                        
                        
                        else if(objetCliqué.GetComponent<LinkObjects>().id == 50 && testObjetMainLivresMauvais() && objMain.GetComponent<Item>().equipped)
                        { // cas des mauvais livres sur la validation (Activité 1)
                            destroyObjMainAndScene();
                            
                            bouche.GetComponent<Bouches>().animBoucheFache();
                            string nomLivre = objMain.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text;
                            bouche.GetComponent<Bouches>().setText(nomLivre + textesBouche[1]);
                        }
                    }
                }
            }
        }
    }

    public void activeAction()
    {
        if (objMain.name == "CubeInventaire(1)")
        {
            Debug.Log("YEEEEES ça marche !!!");
        }

        if (objMain.name == "BookRecueilMain")
        {
            string nomLivre = objMain.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text;
            GameObject candle = GameObject.Find("CandleTest04");
            if(!candle.GetComponent<CandleEnigma>().isAlive){
                candle.GetComponent<CandleEnigma>().lightOffCandle(candle);
                bouche.GetComponent<Bouches>().animBoucheContente();
                bouche.GetComponent<Bouches>().setText(nomLivre + textesBouche[2]);
            }
        
        }

        if (objMain.name == "BookConceptionMain")
        {
            string nomLivre = objMain.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text;
            GameObject candle = GameObject.Find("CandleTest03");
            if(!candle.GetComponent<CandleEnigma>().isAlive){
                candle.GetComponent<CandleEnigma>().lightOffCandle(candle);
                bouche.GetComponent<Bouches>().animBoucheContente();
                bouche.GetComponent<Bouches>().setText(nomLivre + textesBouche[2]);
            }
        }

        if (objMain.name == "BookCodeMain")
        {
            string nomLivre = objMain.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text;
            GameObject candle = GameObject.Find("CandleTest05");
            if(!candle.GetComponent<CandleEnigma>().isAlive){
                candle.GetComponent<CandleEnigma>().lightOffCandle(candle);
                bouche.GetComponent<Bouches>().animBoucheContente();
                bouche.GetComponent<Bouches>().setText(nomLivre + textesBouche[2]);
            }
        }

        if (objMain.name == "BookTestsMain")
        {
            string nomLivre = objMain.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text;
            GameObject candle = GameObject.Find("CandleTest02");
            if(!candle.GetComponent<CandleEnigma>().isAlive){
                candle.GetComponent<CandleEnigma>().lightOffCandle(candle);
                bouche.GetComponent<Bouches>().animBoucheContente();
                bouche.GetComponent<Bouches>().setText(nomLivre + textesBouche[2]);
            }
        }

        if (objMain.name == "BookMaintenanceMain")
        {
            string nomLivre = objMain.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text;
            GameObject candle = GameObject.Find("CandleTest01");
            if(!candle.GetComponent<CandleEnigma>().isAlive){
                candle.GetComponent<CandleEnigma>().lightOffCandle(candle);
                bouche.GetComponent<Bouches>().animBoucheContente();
                bouche.GetComponent<Bouches>().setText(nomLivre + textesBouche[2]);
            }
        }

        if (objMain.name == "PotionRougeMain")
        {
            Animator blueOrange = objetCliqué.GetComponent<Animator>();
            objetCliqué.GetComponent<AudioSource>().Play();
            blueOrange.SetTrigger("PotionBleue1");
            //objetCliqué.GetComponent<LinkObjects>().id = 2;    
        }

        if (objMain.name == "PotionJauneMain")
        {
            Animator OrangeWhite = objetCliqué.GetComponent<Animator>();
            objetCliqué.GetComponent<AudioSource>().Play();
            OrangeWhite.SetTrigger("PotionBleue2");

            bouche.GetComponent<Bouches>().animBoucheContente();
            bouche.GetComponent<Bouches>().setText(textesBouche[4]);
            Invoke("waitPotion",2);
            
        }

        if (objMain.name == "PotionBleueMain")
        {

            Animator Bramble = objetCliqué.GetComponent<Animator>();
            objetCliqué.GetComponent<AudioSource>().Play();
            Bramble.SetTrigger("Bramble");
            Invoke("destroyBramble",2);
            
        }
    }

    

    public void destroyImage(){

        for (int j = 0; j < SlotHolder.transform.childCount; j++)
        {
            Slot = SlotHolder.transform.GetChild(j).gameObject;
            panel = Slot.transform.GetChild(0).gameObject;

            GameObject Text = Description.transform.GetChild(1).gameObject;
            Text.GetComponent<Text>().text = null;

            GameObject Image = GameObject.Find("Active Object");
            Image.GetComponent<Image>().sprite = null;

            GameObject use = Use.transform.GetChild(1).gameObject;
            use.GetComponent<Text>().text = null;

            if (objMain.GetComponent<Item>().icon == panel.GetComponent<Image>().sprite)
            {
                Slot.GetComponent<Slot>().empty = true;
                panel.GetComponent<Image>().sprite = null;
                Slot.SetActive(false);
                //Destroy(Slot);
            }
            Image.GetComponent<Image>().color = new Color(95,84,80, 255);

            
        }
    }

    /*public void waitPotion(){
        objetCliqué.tag = "Item";
        objetCliqué.GetComponent<Outline>().enabled=true;
    }

    public void destroyBramble(){
        GameObject bramble = GameObject.Find("StrangeFlower");
        if(bramble!=null)
            bramble.SetActive(false);
    }*/

    public bool testObjetMainLivresCycle(){
        return objMain.GetComponent<Item>().id == 6 
            || objMain.GetComponent<Item>().id == 7
            || objMain.GetComponent<Item>().id == 8
            || objMain.GetComponent<Item>().id == 9
            || objMain.GetComponent<Item>().id == 10;
    }

    public bool testObjetMainLivresMauvais(){
        return objMain.GetComponent<Item>().id == 11 
            || objMain.GetComponent<Item>().id == 12
            || objMain.GetComponent<Item>().id == 13
            || objMain.GetComponent<Item>().id == 14
            || objMain.GetComponent<Item>().id == 15;
    }

    public void startAction(bool destroyObjInventaire){
        // detruit l'objet dans l'inventaire, met a false celui de la main et a true celui recuperable


        if(destroyObjInventaire)
            destroyImage();
        activeAction();
                            
        objMain.GetComponent<Item>().equipped = false;
        objMain.GetComponent<Item>().occupied = false;
                            
                            
        int allItems2 = listeObjetsInventaires.transform.childCount;
        for (int j = 0; j < allItems2; j++)
        {
            objRecuperable = listeObjetsInventaires.transform.GetChild(j).gameObject;
            if(objRecuperable.GetComponent<Item>().id == objMain.GetComponent<Item>().id) {
                objRecuperable.SetActive(true);
                objMain.SetActive(false);
                return;
            }
        }
        
    }

    public void destroyObjMainAndScene(){
        // detruit l'objet dans l'inventaire, l'objet dans la main et celui recuperable
        destroyImage();
        activeAction();
                            
        objMain.GetComponent<Item>().equipped = false;
        objMain.GetComponent<Item>().occupied = false;
                            
                            
        int allItems2 = listeObjetsInventaires.transform.childCount;
        for (int j = 0; j < allItems2; j++)
        {
            objRecuperable = listeObjetsInventaires.transform.GetChild(j).gameObject;
            if(objRecuperable.GetComponent<Item>().id == objMain.GetComponent<Item>().id) {
                Destroy(objRecuperable);
                Destroy(objMain);
                return;
            }
        }
        
    }

    public void PlaceLivreMurCycle(){
        // replace livre sur mur cycle en V à l'endroit cliqué
        
        
        objRecuperable.GetComponent<Transform>().position = objetCliqué.GetComponent<Transform>().position;
        objetCliqué.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = objMain.transform.GetChild(0).GetComponent<TextMeshPro>().text;
        //objetCliqué.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = true;
        //objRecuperable.GetComponent<Transform>().Rotate(0,0,90);
        //objRecuperable.SetActive(true);
        
    }
}

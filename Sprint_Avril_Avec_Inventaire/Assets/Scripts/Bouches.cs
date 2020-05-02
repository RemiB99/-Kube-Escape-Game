using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bouches : MonoBehaviour
{
    public GameObject inventaire;
    public GameObject boucheContente;
    public GameObject boucheTriste;
    public GameObject boucheReflechi;
    public GameObject boucheFache;
    public GameObject textBouche;

    public Button boutonBouche;

    private bool content;
    private bool triste;
    private bool reflechi;
    private bool fache;

    private bool textVisible = false;
    // Start is called before the first frame update
    void Start()
    {
        desactiveBouche();
        //textBouche.SetActive(false);

        content = false;
        triste = false;
        reflechi = false;
        fache = false;


    }

    // Update is called once per frame
    void Update()
    { 
        if(inventaire.transform.localScale == new Vector3(0, 0, 0)){
            if(!reflechi){
                textBouche.SetActive(true);
                setText("Cette fumée rose ne me dit rien qui vaille... Ces plantes semblent bien protéger le contenu de ce coffre...");
                animBoucheReflechi();
                reflechi = true;

            }
        //textBouche.SetActive(true);
        }
        else{
            desactiveBouche();
            //textBouche.SetActive(false);
        }
        
    }

    public void desactiveBouche(){
        boucheContente.SetActive(false);
        boucheTriste.SetActive(false);
        boucheReflechi.SetActive(false);
        boucheFache.SetActive(false);
        textBouche.SetActive(false);
    }

    public void animBoucheContente(){
        desactiveBouche();
        boucheContente.SetActive(true);
        textBouche.SetActive(true);
        //textBouche.GetComponent<Animator>().SetTrigger("Text");
        Animator animateur = boucheContente.GetComponent<Animator>();
        animateur.SetTrigger("Content");
    }

    public void animBoucheTriste(){
        desactiveBouche();
        boucheTriste.SetActive(true);
        textBouche.SetActive(true);
        //textBouche.GetComponent<Animator>().SetTrigger("Text");
        Animator animateur = boucheTriste.GetComponent<Animator>();
        animateur.SetTrigger("Triste");
    }

    public void animBoucheReflechi(){
        desactiveBouche();
        boucheReflechi.SetActive(true);
        textBouche.SetActive(true);
        //textBouche.GetComponent<Animator>().SetTrigger("Text");
        Animator animateur = boucheReflechi.GetComponent<Animator>();
        animateur.SetTrigger("Reflechi");
    }

    public void animBoucheFache(){
        desactiveBouche();
        boucheFache.SetActive(true);
        textBouche.SetActive(true);
        //textBouche.GetComponent<Animator>().SetTrigger("Text");
        Animator animateur = boucheFache.GetComponent<Animator>();
        animateur.SetTrigger("Fache");
    }

    public void modifText(){
        if(textVisible){
            textBouche.SetActive(false);
        }
        else
        {
            textBouche.SetActive(true);
        }
        textVisible = !textVisible;
    }
    

    public void setText(string textChoisi){
        textBouche.GetComponent<Text>().text = textChoisi;
    }
}

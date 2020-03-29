using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BookAction : MonoBehaviour
{
    public GameObject bookConcerned;
    
    
    
    void Start()
    {
        //DistinctBook2 = GameObject.Find("DistinctBook2");
        //DistinctBook2.SetActive(false);
        GameObject cam = GameObject.Find("Main Camera");
        AudioSource back = cam.GetComponent<AudioSource>();
        back.volume = 0.1f;
        back.Play();
        //Invoke("genie",1);
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetMouseButtonDown(0)))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if( (Physics.Raycast(ray, out hit)))
            
                /*if (Input.GetMouseButtonDown(0))
                {*/
                    
                    if (hit.transform.name == bookConcerned.name)
                    {
                    Debug.Log(bookConcerned.name);
                    soundTouchBook();
                    //Invoke("genie",1);
                    Invoke("bookFading",1);
                    Invoke("destroyBook",7);

                    
                }
            }
        }

    // Actions sur le livre chimie
    void soundTouchBook(){
        ParticleSystem anim = bookConcerned.GetComponentInChildren<ParticleSystem>();
        anim.GetComponent<AudioSource>().Play();
        anim.Play();

        
    }

    void bookFading(){

        GameObject textGenie;
        if(bookConcerned.name == "EnigmaChimie"){
            textGenie = GameObject.Find("TextBonChoix");
        }
        else{
            textGenie = GameObject.Find("TextPeuUtile");
        }


        Animator fonduLivre = bookConcerned.GetComponentInChildren<Animator>();
        fonduLivre.SetTrigger("Active");
        bookConcerned.GetComponent<AudioSource>().Play();

        Animator fonduText = textGenie.GetComponent<Animator>();
        fonduText.SetTrigger("Active");
        
        
    }

    void destroyBook(){
        bookConcerned.SetActive(false);
        //Destroy(GameObject.Find("Enigma"));
    }

    /*void genie(){

        GameObject genie = GameObject.Find("Genie+Lamp+Light");
        Animator appear = genie.GetComponentInChildren<Animator>();
        ParticleSystem anim = genie.GetComponentInChildren<ParticleSystem>();

        Debug.Log(genie);
        Debug.Log("*****");
        Debug.Log(appear);
        Debug.Log("*****");
        Debug.Log(anim);
        anim.Play();
        appear.SetTrigger("Active");
        Debug.Log("apres");
        //bookConcerned.GetComponent<AudioSource>().Play();
    }*/
    
}
    

    

    
    

    

        
    


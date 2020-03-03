using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookAction : MonoBehaviour
{
    
    public GameObject book;
    public float speed = 5f;
    
    
    void Start()
    {
        GameObject cam = GameObject.Find("Main Camera");
        AudioSource back = cam.GetComponent<AudioSource>();
        back.volume = 0.1f;
        back.Play();
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
                
                    if (hit.transform.name == "Enigma")
                    {
                    book=hit.transform.gameObject;
                    soundTouchBook(book);
                    
                    Invoke("blablaGenie",3);
                    Invoke("discoverBook2",5);
                    Invoke("discoverBook3",6);
                    Invoke("discoverBook1",7);
                    Invoke("playAuraBook",16);
                    }
            }
        }
    

    void soundTouchBook(GameObject book){
        
            book.GetComponent<AudioSource>().Play();
            GameObject smoke = GameObject.Find("Smoke");
            
            if (smoke!=null){
                ParticleSystem anim = smoke.GetComponent<ParticleSystem>();
                anim.Play();
                
            }
    }

    void blablaGenie(){
        GameObject book = GameObject.Find("Enigma");
        Light choice = book.GetComponentInChildren<Light>();
        choice.GetComponent<AudioSource>().Play();
    }
    void discoverBook(string nameBook){
        GameObject distinctBook = GameObject.Find(nameBook);
        
        if(distinctBook != null){
            Light light = distinctBook.GetComponentInChildren<Light>();
            light.GetComponent<AudioSource>().Play();
            light.GetComponent<Light>().enabled = true;
        }
    }
    
    void playAuraBook(){
        GameObject obj = GameObject.Find("AuraBook");
        ParticleSystem anim = obj.GetComponent<ParticleSystem>();
        if (anim!=null){
                anim.Play();
        }
    }

    void discoverBook1(){
        discoverBook("DistinctBook1");
    }

    void discoverBook2(){
        discoverBook("DistinctBook2");
    }

    void discoverBook3(){
        discoverBook("DistinctBook3");
    }
    

    
}
        
    


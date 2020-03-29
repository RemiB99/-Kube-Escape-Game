using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookLibrary : MonoBehaviour
{
     public GameObject bookConcerned;
     public int delay;
    public Vector3 newPosition;
    float speed = 1.0f;
    bool hasAppeared = false;
    
    void Start()
    {
        
        /*GameObject cam = GameObject.Find("Main Camera");
        AudioSource back = cam.GetComponent<AudioSource>();
        back.volume = 0.1f;
        back.Play();*/
    }

    // Update is called once per frame
    void Update()
    {
        

        // Livre de chimie sur la table
        GameObject book = GameObject.Find("EnigmaChimie");
        
        if (book == null && !hasAppeared){
            
           
            Invoke("revealBook",delay);
            Invoke("playAuraBook",10);
            Invoke("startAnim",12);
            Invoke("exit",18);
            hasAppeared = true;
            
        }
                    

                    
                    
            
    }   

    
    void revealBook(){
        Light light = bookConcerned.GetComponentInChildren<Light>();
        light.GetComponent<AudioSource>().Play();
        light.GetComponent<Light>().enabled = true;

        float step =  speed * Time.deltaTime;
        bookConcerned.transform.position = newPosition;

    }

    void playAuraBook(){
        Debug.Log("aura");
        ParticleSystem anim = bookConcerned.GetComponentInChildren<ParticleSystem>();
        if (anim!=null)
            anim.Play();
    }

    void startAnim(){
        Debug.Log("fondu");
        GameObject obj = GameObject.Find("chandiler");
        obj.GetComponent<AudioSource>().Play();

        GameObject go = GameObject.Find("AnimationFinFondu");
        FinAnimation f = (FinAnimation)go.GetComponent(typeof(FinAnimation));
        f.LoadNextLevelAnimation();
        
    }
    void exit()
    {
        Debug.Log("exit");
        Application.Quit();
    }
}

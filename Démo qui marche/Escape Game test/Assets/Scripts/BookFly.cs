using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookFly : MonoBehaviour
{
    public float speed = 1.0f;
    public bool soundplayed = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Light light = this.GetComponentInChildren<Light>();
        if(light.GetComponent<Light>().enabled){
            Invoke("moveBook",5);
           /* if (soundplayed) {
                Invoke("flySound",5);
                soundplayed = false;
            }*/
            
        }
    }

    void moveBook(){
        
        float step =  speed * Time.deltaTime; 
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(-11.5f,4f,3f), step);
        
    }

    void flySound(){
        this.GetComponent<AudioSource>().Play();
        
    }

    
}


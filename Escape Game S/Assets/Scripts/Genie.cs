using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Genie : MonoBehaviour
{
    
    public bool hasAppeared = true;
    // Start is called before the first frame update
    void Start()
    {
        seeGenie(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject genie = GameObject.Find("Genius");
        GameObject smoke = GameObject.Find("Smoke");
        Debug.Log(smoke);
        if((smoke==null) && (hasAppeared)){
            seeGenie(true);
            hasAppeared = false;
        }
            
    }

    void seeGenie(bool isVisible){
        GameObject genieHaut = GameObject.Find("hautGenie");
        GameObject genieBas = GameObject.Find("basGenie");
        genieHaut.GetComponent<Renderer>().enabled = isVisible;
        genieBas.GetComponent<Renderer>().enabled = isVisible;
    }
    
    
}

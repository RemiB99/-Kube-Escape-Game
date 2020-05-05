using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffreScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0)) {
            if (Physics.Raycast(ray, out hit)){
                
                if (hit.transform.name == "Coffre") {
                    
                    this.GetComponent<Animator>().SetTrigger("Activate");
                    this.GetComponent<BoxCollider>().enabled = false;
                    Invoke("testDiams",2);
            

                    
                }
            } 
        }
    }

    void testDiams(){
        GameObject diams = GameObject.Find("Diamant");
        if(diams != null){
            diams.GetComponent<BoxCollider>().enabled = true;
        }
        
    }
}

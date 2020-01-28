using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickObject : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            
            Touch touch = Input.GetTouch(0) ;
<<<<<<< Updated upstream
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
=======
            Ray ray1 = Camera.main.ScreenPointToRay(touch.position);
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition );
            
>>>>>>> Stashed changes
            RaycastHit hit;
            
            
            if( (Physics.Raycast(ray, out hit)) || (Physics.Raycast(ray1, out hit)))
            {
                
<<<<<<< Updated upstream
                if (touch.tapCount == 2 /*&& hit.transform.name == "Pass MS"*/)
                {
                    /*Debug.Log(hit.transform.name);
                    SceneManager.LoadScene("the last revelation");*/
                    if (hit.transform.name == "Cube Test")
                    {
                        SceneManager.LoadScene("Terminal Hacker");
=======
                if (Input.GetMouseButtonDown(0) || touch.tapCount == 2 )
                {
                    
                    if (hit.transform.name == "Cube Test")
                    {
                        SceneManager.LoadScene("Terminal Hacker 1");
                    }
                    else if(hit.transform.name == "Pass MS")
                    {
                        SceneManager.LoadScene("the last revelation 1");
>>>>>>> Stashed changes
                    }
                    else if(hit.transform.name == "Pass MS")
                    {
                        SceneManager.LoadScene("the last revelation");
                    }
                    else if (hit.transform.name == "Pass Initial")
                    {
                        SceneManager.LoadScene("Start scene");
                    }

                }
            }
        }
    }
}

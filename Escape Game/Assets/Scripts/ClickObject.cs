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
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;
            
            
            if( Physics.Raycast(ray, out hit))
            {
                
                if (touch.tapCount == 2 /*&& hit.transform.name == "Pass MS"*/)
                {
                    /*Debug.Log(hit.transform.name);
                    SceneManager.LoadScene("the last revelation");*/
                    if (hit.transform.name == "Cube Test")
                    {
                        SceneManager.LoadScene("Terminal Hacker");
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

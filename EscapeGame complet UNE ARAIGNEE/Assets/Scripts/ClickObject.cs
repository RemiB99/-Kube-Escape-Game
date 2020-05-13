using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickObject : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(/*(Input.touchCount > 0)||*/ (Input.GetMouseButtonDown(0)))
        {
            
           // Touch touch = Input.GetTouch(0) ;
            //Ray rayTouch = Camera.main.ScreenPointToRay(touch.position);
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            RaycastHit hit;
            
            
            if( (Physics.Raycast(ray, out hit)) /*|| (Physics.Raycast(rayTouch, out hit))*/)
            {
                
                if (Input.GetMouseButtonDown(0) /*|| touch.tapCount == 2*/ )
                {
                
                    if (hit.transform.name == "Cube Test")
                    {
                        SceneManager.LoadScene("Terminal Hacker 1");
                    }
                    else if(hit.transform.name == "Pass MS")
                    {
                        hit.transform.GetComponent<AudioSource>().Play();
                        SceneManager.LoadScene("the last revelation 1");
                    }
                    else if(hit.transform.name == "PorteTaverne")
                    {
                        Debug.Log("bdsfljvkhbjclbdoshk bjqdv");
                        hit.transform.GetComponent<AudioSource>().Play();
                        SceneManager.LoadScene("PirateTavern");
                    }
                    else if (hit.transform.name == "Enigma")
                    {
                        //SceneManager.LoadScene("qcm");
                    }
                    else if (hit.transform.name == "Zone_crystal")
                    {
                        SceneManager.LoadScene("the last revelation 3");
                    }
                    else if (hit.transform.name == "door")
                    {
                        SceneManager.LoadScene("Start scene");
                    }
                    else if (hit.transform.name == "Black Cube")
                    {  
                        SceneManager.LoadScene("Starting video");
                    }
                    else if (hit.transform.name == "Hand")
                    {
                        Invoke("StartingVideo", 2);
                    }
                    else if (hit.transform.name == "rpgpp_lt_rock_01")
                    {
                        Application.Quit();
                    }

                }
            }
        }
    }

    void StartingVideo()
    {
        SceneManager.LoadScene("Starting video");
    }
}

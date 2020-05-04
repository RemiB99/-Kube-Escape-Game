using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickObject : NetworkBehaviour
{
    private Inventory inventory;
    private NetworkManager NM;
    [SyncVar] bool connectionFinish = false;
    //public Animator transition;

    private void Start()
    {
        NM = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(/*(Input.touchCount > 0)||*/ (Input.GetMouseButtonDown(0)))
        {
            
            //Touch touch = Input.GetTouch(0) ;
            //Ray rayTouch = Camera.main.ScreenPointToRay(touch.position);
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            RaycastHit hit;
            
            
            if( (Physics.Raycast(ray, out hit)) /*|| (Physics.Raycast(rayTouch, out hit))*/)
            {
                if (Input.GetMouseButtonDown(0) /*|| touch.tapCount == 2 */)
                {
                    Debug.Log("click");
                    connectionFinish = false;
                    if (hit.transform.name == "Cube Test")
                    {
                        SceneManager.LoadScene("Terminal Hacker 1");
                        
                    }
                    else if(hit.transform.name == "Pass MS")
                    {
                        if (connectionFinish == false)
                        {
                            connectionFinish = true;
                            CmdChangeScene("the last revelation 1");
                        }
                        //SceneManager.LoadScene("the last revelation 1");
                        //StartCoroutine(LoadScene("the last revelation 1"));   
                    }
                    else if (hit.transform.name == "Pass World Portal")
                    {
                        SceneManager.LoadScene("the last revelation 1");
                        //StartCoroutine(LoadScene("the last revelation 1"));   
                    }
                    else if (hit.transform.name == "Enigma")
                    {
                        SceneManager.LoadScene("qcm");
                        //StartCoroutine(LoadScene("qcm"));
                    }
                    else if (hit.transform.name == "Zone_crystal")
                    {
                        SceneManager.LoadScene("the last revelation 3");
                        //StartCoroutine(LoadScene("the last revelation 1"));
                    }
                    else if (hit.transform.name == "door")
                    {
                        if (connectionFinish == false)
                        {
                            connectionFinish = true;
                            CmdChangeScene("Start scene");
                        }
                        //SceneManager.LoadScene("Start scene");
                        //StartCoroutine(LoadScene("Start scene"));
                    }
                    else if (hit.transform.name == "Black Cube")
                    {   
                        SceneManager.LoadScene("Starting video");
                        //StartCoroutine(LoadScene("the last revelation 1"));
                    }
                    else if (hit.transform.name == "Quit")
                    {
                        Application.Quit();
                    }

                }
            }
        }
    }

    [Command]
    void CmdChangeScene(string name)
    {
        NetworkManager.singleton.ServerChangeScene(name);
    }



    /* IEnumerator LoadScene(string sceneName)
     {

         transition.SetTrigger("start");

         yield return new WaitForSeconds(1.5f);

         SceneManager.LoadScene(sceneName);

     }*/
}

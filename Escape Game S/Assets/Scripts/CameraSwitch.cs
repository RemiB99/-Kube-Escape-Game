using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{

    public GameObject cameraMain;
    public GameObject camera1;
    public GameObject camera2;
    public GameObject camera3;
    public GameObject camera4;
    public GameObject camera5;

    AudioListener cameraMainAudioLis;
    AudioListener camera1AudioLis;
    AudioListener camera2AudioLis;
    AudioListener camera3AudioLis;
    AudioListener camera4AudioLis;
    AudioListener camera5AudioLis;
    

    // Use this for initialization
    void Start()
    {

        //Get Camera Listeners
        cameraMainAudioLis = cameraMain.GetComponent<AudioListener>();
       /* camera1AudioLis = camera1.GetComponent<AudioListener>();
        camera2AudioLis = camera2.GetComponent<AudioListener>();
        camera3AudioLis = camera3.GetComponent<AudioListener>();
        camera4AudioLis = camera4.GetComponent<AudioListener>();
        camera5AudioLis = camera5.GetComponent<AudioListener>();*/
        

        //Camera Position Set
        cameraPositionChange(PlayerPrefs.GetInt("CameraPosition"));
    }

    // Update is called once per frame
    void Update()
    {
        //Change Camera Keyboard
        switchCamera();
    }

    //UI JoyStick Method
    public void cameraPositonM()
    {
        cameraChangeCounter();
    }

    //Change Camera Keyboard
    void switchCamera()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            cameraChangeCounter();
        }
    }

    //Camera Counter
    void cameraChangeCounter()
    {
        int cameraPositionCounter = PlayerPrefs.GetInt("CameraPosition");
        cameraPositionCounter++;
        cameraPositionChange(cameraPositionCounter);
    }

    //Camera change Logic
    public void cameraPositionChange(int camPosition)
    {
        if (camPosition > 5)
        {
            camPosition = 0;
        }

        //Set camera position database
        PlayerPrefs.SetInt("CameraPosition", camPosition);

        cameraMain.SetActive(false);
        camera1.SetActive(false);
        camera2.SetActive(false);
        camera3.SetActive(false);
        camera4.SetActive(false);
        camera5.SetActive(false);

        //Set camera position 0
        if (camPosition == 0)
        {
            cameraMain.SetActive(true);
            //cameraMainAudioLis.enabled = true;

            //camera1AudioLis.enabled = false;
           

            //camera5AudioLis.enabled = false;
            
        }

        //Set camera position 1
        if (camPosition == 1)
        {
            camera1.SetActive(true);
            // camera1AudioLis.enabled = true;
            
        }

        //Set camera position 2
        if (camPosition == 2)
        {
            camera2.SetActive(true);
            //camera2AudioLis.enabled = true;
            
            
        }

        //Set camera position 3
        if (camPosition == 3)
        {
            camera3.SetActive(true);
            // camera3AudioLis.enabled = true;
       
           
        }

        //Set camera position 4
        if (camPosition == 4)
        {
            camera4.SetActive(true);
            // camera4AudioLis.enabled = true;
          
        }

        //Set camera position 5
        if (camPosition == 5)
        {
            camera5.SetActive(true);
            // camera5AudioLis.enabled = true;
           
            
        }

    }
}

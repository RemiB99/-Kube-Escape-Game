using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    private bool camerasSet = false;
    private Camera cameraMain;
    private Camera camera1;
    private Camera camera2;
    private Camera camera3;
    private Camera camera4;
    private Camera camera5;

    AudioListener cameraMainAudioLis;
    AudioListener camera1AudioLis;
    AudioListener camera2AudioLis;
    AudioListener camera3AudioLis;
    AudioListener camera4AudioLis;
    AudioListener camera5AudioLis;
    

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this);
        //Get Camera Listeners
        //cameraMainAudioLis = cameraMain.GetComponent<AudioListener>();
        /* camera1AudioLis = camera1.GetComponent<AudioListener>();
         camera2AudioLis = camera2.GetComponent<AudioListener>();
         camera3AudioLis = camera3.GetComponent<AudioListener>();
         camera4AudioLis = camera4.GetComponent<AudioListener>();
         camera5AudioLis = camera5.GetComponent<AudioListener>();*/
        
      
        //Camera Position Set
        //cameraPositionChange(PlayerPrefs.GetInt("CameraPosition"));
    }

    // Update is called once per frame
    void Update()
    {
        if (!camerasSet) {
            GameObject cameraMainObj = GameObject.Find("Main Camera");
            GameObject camera1Obj = GameObject.Find("Camera (1)");
            GameObject camera2Obj = GameObject.Find("Camera (2)");
            GameObject camera3Obj = GameObject.Find("Camera (3)");
            GameObject camera4Obj = GameObject.Find("Camera (4)");
            GameObject camera5Obj = GameObject.Find("InventoryCamera");
            DontDestroyOnLoad(camera5Obj);

            if (cameraMainObj != null && camera1Obj != null && camera2Obj != null && 
                camera3Obj != null && camera4Obj != null && camera5Obj != null)
            {
                cameraMain = cameraMainObj.GetComponent<Camera>();
                camera1 = camera1Obj.GetComponent<Camera>();
                camera2 = camera2Obj.GetComponent<Camera>();
                camera3 = camera3Obj.GetComponent<Camera>();
                camera4 = camera4Obj.GetComponent<Camera>();
                camera5 = camera5Obj.GetComponent<Camera>();
                camerasSet = true;
            }
        }
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

        if (camerasSet)
        {
            if (camPosition > 5)
            {
                camPosition = 0;
            }

            //Set camera position database
            //PlayerPrefs.SetInt("CameraPosition", camPosition);

            cameraMain.enabled = false;
            camera1.enabled = false;
            camera2.enabled = false;
            camera3.enabled = false;
            camera4.enabled = false;
            camera5.enabled = false;

            //Set camera position 0
            if (camPosition == 0)
            {
                //cameraMain.SetActive(true);
                cameraMain.enabled = true;
                //cameraMainAudioLis.enabled = true;

                //camera1AudioLis.enabled = false;


                //camera5AudioLis.enabled = false;

            }

            //Set camera position 1
            if (camPosition == 1)
            {
                //cameraMain.SetActive(false);
                //camera1.SetActive(true);
                camera1.enabled = true;
                // camera1AudioLis.enabled = true;

            }

            //Set camera position 2
            if (camPosition == 2)
            {
                //cameraMain.SetActive(false);
                //camera2.SetActive(true);
                camera2.enabled = true;
                //camera2AudioLis.enabled = true;


            }

            //Set camera position 3
            if (camPosition == 3)
            {
                //cameraMain.SetActive(false);
                //camera3.SetActive(true);
                camera3.enabled = true;
                // camera3AudioLis.enabled = true;


            }

            //Set camera position 4
            if (camPosition == 4)
            {
                //cameraMain.SetActive(false);
                //camera4.SetActive(true);
                camera4.enabled = true;
                // camera4AudioLis.enabled = true;

            }

            //Set camera position 5
            if (camPosition == 5)
            {
                //cameraMain.SetActive(false);
                //camera5.SetActive(true);
                camera5.enabled = true;
                // camera5AudioLis.enabled = true;


            }
        }
        

    }
}

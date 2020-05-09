using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class StartingVideo : MonoBehaviour
{
    public VideoPlayer vid;
 
 
    void Start()
    {
        vid.loopPointReached += CheckOver;
    }
 
    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
         Debug.Log("Video Is Over");
         SceneManager.LoadScene("Start scene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

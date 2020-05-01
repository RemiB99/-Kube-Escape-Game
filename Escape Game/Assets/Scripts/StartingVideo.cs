using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartingVideo : MonoBehaviour
{
    public VideoPlayer video;
    // Start is called before the first frame update
    void Start()
    {
        video.loopPointReached += CheckOver;
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

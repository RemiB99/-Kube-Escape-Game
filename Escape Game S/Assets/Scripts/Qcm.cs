using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Qcm : MonoBehaviour
{
    
    //public GameObject goodAnswer;
    //public GameObject wrongAnswer;
    
    public void choiceGoodAnswer()
    {
        SceneManager.LoadScene("the last revelation 2");
    }

    public void choiceGoingBack()
    {
        SceneManager.LoadScene("the last revelation 1");
    }

    public void choiceBadAnswer()
    {
        SceneManager.LoadScene("Start scene");
    }

    
}

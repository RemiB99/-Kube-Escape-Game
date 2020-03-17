using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinAnimation : MonoBehaviour
{
  public Animator transition;
  public float transitionTime =500f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1)){
            
            LoadNextLevelAnimation();
        }
    }

    public void LoadNextLevelAnimation(){
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    IEnumerator LoadLevel(int levelIndex){
        
        transition.transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(transitionTime);
        transition.SetTrigger("StartFonduFin");
        
        //SceneManager.LoadScene(levelIndex);
    }
}

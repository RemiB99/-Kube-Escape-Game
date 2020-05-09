using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rebus : MonoBehaviour
{
    public GameObject book;
    private GameObject enigme;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject enigmePanel = GameObject.Find("EnigmePlaque");
        enigme = enigmePanel.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0) && hit.transform.name == "BookEnigme")
            {
                enigme.SetActive(true);
            }
        }
    }

    public void close()
    {
        enigme.SetActive(false);
    }
}

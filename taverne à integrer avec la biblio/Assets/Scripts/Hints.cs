using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hints : MonoBehaviour
{
    public GameObject hints;
    public GameObject papers;
    private GameObject[] hint;
    private GameObject[] paper;
    private int nbHints = 5; 
    private int nbPapers = 5;
    private int indice = 0;
    // Start is called before the first frame update
    void Start()
    {
        hint = new GameObject[5];
        paper = new GameObject[5];
        for (int i = 0; i < nbHints; i++)
        {
            hint[i] = hints.transform.GetChild(i).gameObject;   
        }
        for (int i = 0; i < nbPapers; i++)
        {
            paper[i] = papers.transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                for (int i = 0; i < nbPapers; i++)
                {
                    if(paper[i] != null)
                    {
                        if (hit.transform.name == paper[i].name)
                        {
                            paper[i] = null;
                            hint[indice].SetActive(true);
                            indice++;
                        }
                    }
                }        
            }
        }
    }

    public void close()
    {
        for (int i = 0; i < nbHints; i++)
        {
            if (hint[i].activeSelf)
            {
                hint[i].SetActive(false);
                //paper[i].GetComponent<Collider>().enabled = false;
            }
        }
    } 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlaqueScript : MonoBehaviour
{
    private bool isRayed = false;
    public GameObject[] textsPlaques = new GameObject[8];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {   
                if (Input.GetMouseButtonDown(0) && hit.transform.tag == "TextPlaque")
                {   
                    Debug.Log(hit.transform.name);
                    if(!isRayed)
                        hit.transform.GetChild(0).gameObject.SetActive(true);
                    else
                        hit.transform.GetChild(0).gameObject.SetActive(false);
                    
                    isRayed = !isRayed;
                }
            }
        }
    }
}

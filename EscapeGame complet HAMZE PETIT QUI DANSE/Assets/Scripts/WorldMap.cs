using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WorldMap : MonoBehaviour
{
    public GameObject enigme;
    private GameObject boutonTrouver;
    private GameObject fleche;
    private GameObject message;
    // Start is called before the first frame update

    void Start()
    {
        boutonTrouver = enigme.transform.GetChild(0).gameObject;
        fleche = enigme.transform.GetChild(1).gameObject;
        message = enigme.transform.GetChild(2).gameObject;
    }

    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if (Input.GetMouseButtonDown(0) && hit.transform.name == "WorldMap")
                {
                    enigme.SetActive(true);
                }
            }
               
        }
    }

    public void clicked()
    {
        boutonTrouver.GetComponent<Outline>().gameObject.SetActive(true);
        fleche.SetActive(true);
        message.SetActive(true);
    }

    public void closed()
    {
        enigme.SetActive(false);
    }
}

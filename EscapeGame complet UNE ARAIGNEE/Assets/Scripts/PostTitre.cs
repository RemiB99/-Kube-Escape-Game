using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PostTitre : MonoBehaviour
{
    public GameObject enigme;

    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0) && hit.transform.name == "PostTitre")
            {
                enigme.SetActive(true);
            }
        }
    }

    public void closed()
    {
        enigme.SetActive(false);
    }
}

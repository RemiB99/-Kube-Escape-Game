using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public GameObject textCoin;
    private Text text;
    private int nbCoin;

    void Start()
    {
        text = textCoin.GetComponent<Text>();
        nbCoin = 0;
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
                if (Input.GetMouseButtonDown(0) && hit.transform.tag == "Coin")
                {
                    nbCoin++;
                    text.text = "Nb Coin : " + nbCoin.ToString();
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }
}

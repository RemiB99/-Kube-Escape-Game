using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleEnigma : MonoBehaviour
{
    public GameObject candle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetMouseButtonDown(0)))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if( (Physics.Raycast(ray, out hit)))
            
                /*if (Input.GetMouseButtonDown(0))
                {*/
                
                    if (hit.transform.name == "CandleTest")
                    {
                       candle=hit.transform.gameObject;
                       
                       lightOffCandle(candle);
                       
                      
                       
                    }
        }
    }

    void lightOffCandle(GameObject candle){
        
        GameObject meche = GameObject.Find("mTest");
        GameObject light = GameObject.Find("LightTest");
        if(meche!=null && light!=null){
            meche.SetActive(false);
            light.SetActive(false);
            candle.GetComponent<AudioSource>().Play();


        }
    }
}

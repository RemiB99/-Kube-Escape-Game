﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleEnigma : MonoBehaviour
{
    public GameObject candle;
    public bool hasMoved = false;
    public bool[] candlesAnswer = new bool[14];
    public bool[] candlesScene = new bool[14];
    public CandleEnigma scriptWall;
    // Start is called before the first frame update
    void Start()
    {
        initializeTab();
        GameObject globalCandle = GameObject.Find("CandleWall14");
        scriptWall = globalCandle.GetComponent<CandleEnigma>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetMouseButtonDown(0)))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if( (Physics.Raycast(ray, out hit)))
                if (hit.transform.name == candle.transform.name){

                    lightOffCandle(candle);
                    
                    if(codeBon() && !hasMoved){
                        Debug.Log("********************");
                        GameObject bookCase = GameObject.Find("bookcaseMove");
                        Animator bookcaseReveal = bookCase.GetComponent<Animator>();
                        bookcaseReveal.SetTrigger("MoveBookCase");
                        //bookConcerned.GetComponent<AudioSource>().Play();
                        hasMoved = true;
                    }
                }
        }
    }

    void initializeTab(){
        for(int i=0;i<candlesAnswer.Length;i++){
            candlesAnswer[i] = false;
            candlesScene[i] = false;
        }
        candlesAnswer[0] = true;
        candlesAnswer[2] = true;
        candlesAnswer[6] = true;
        candlesAnswer[10] = true;

    }
    void lightOffCandle(GameObject candle){
        
        
        


        //modif tableau bougies
        string str = candle.transform.name;
        int number = int.Parse(str.Substring(str.Length - 2));
        scriptWall.candlesScene[number-1] = !(scriptWall.candlesScene[number-1]);


        
        // Actions visuelles/sonores
        if(candle.transform.name=="CandleWall14")
            animCandleWall(candle);

        Light light = candle.GetComponentInChildren<Light>();
        MeshRenderer mesh = candle.GetComponentInChildren<MeshRenderer>();
        light.enabled = !light.enabled;
        mesh.enabled = !mesh.enabled;
        candle.GetComponent<AudioSource>().Play();
        
    }

    bool codeBon(){
        for(int i=0;i<candlesAnswer.Length-1;i++){
            if(candlesAnswer[i] != scriptWall.candlesScene[i])
                return false;
        }
        return true;
    }
    
    void testTab(bool[] test){
        for(int i=0;i<test.Length-1;i++){
            Debug.Log(test[i]);
        }
    }

    void animCandleWall(GameObject candle){
        Animator moveCandle = candle.GetComponent<Animator>();
        moveCandle.SetTrigger("MoveCandleWall");
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faché : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Animator animateur = this.GetComponent<Animator>();
            animateur.SetTrigger("anim_faché");
        }
    }
}


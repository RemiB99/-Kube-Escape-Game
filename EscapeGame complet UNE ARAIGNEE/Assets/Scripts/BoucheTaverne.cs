using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BoucheTaverne : MonoBehaviour
{
    private Bouches bouches;
    private string[] textes;
    private int nbTextes;
    private bool premierPassage;
    void Start()
    {
        premierPassage = false;
        nbTextes = 20;
        textes = new string [nbTextes];
        GameObject b = GameObject.Find("Bouches");
        bouches = b.GetComponent<Bouches>();
        initTextes(); 
    }

    
    void Update()
    {

        if (!premierPassage)
        {
            StartCoroutine(blablaBouche());
            premierPassage = true;
        }
            
        
    }

    public void initTextes()
    {
        textes[0] = "Vous voici arrivé dans ce monde dont on m’a tant parlé …";
        textes[1] = "L’ampoule en haut à droite symbolise que le client souhaite vous parler. Allez le voir si vous avez un moment. ";
        textes[2] = " ";
        textes[3] = " ";
        textes[4] = " ";
        textes[5] = " ";
        textes[6] = " ";
        textes[7] = " ";
        textes[8] = " ";
        textes[9] = " ";
        textes[10] = " ";
        textes[11] = " ";
        textes[12] = " ";
        textes[13] = " ";
        textes[14] = " ";
        textes[15] = " ";
        textes[16] = " ";
        textes[17] = " ";
        textes[18] = " ";
        textes[19] = " ";
    }

    IEnumerator blablaBouche()
    {
        bouches.animBoucheReflechi();
        bouches.setText(textes[0]);
        
        yield return new WaitForSeconds(5);

        bouches.setText(textes[1]);

    }
}

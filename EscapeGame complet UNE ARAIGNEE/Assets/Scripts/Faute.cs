using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faute : MonoBehaviour
{
    private int nbFaute;
    private GameObject sans;
    private GameObject peu;
    private GameObject beaucoup;
    public GameObject fin;
    // Start is called before the first frame update
    void Start()
    {
        nbFaute = 0;
        sans = fin.transform.GetChild(0).gameObject;
        peu = fin.transform.GetChild(1).gameObject;
        beaucoup = fin.transform.GetChild(2).gameObject;
    }
    public void incrFaute()
    {
        nbFaute++;
    }

    public void resultat()
    {
        if (nbFaute == 0)
        {
            sans.SetActive(true);
        }
        else if(nbFaute <= 5 )
        {
            peu.SetActive(true);
        }
        else 
        {
            beaucoup.SetActive(true);
        }
    }
}

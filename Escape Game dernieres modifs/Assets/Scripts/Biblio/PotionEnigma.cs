using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionEnigma : MonoBehaviour
{

    public GameObject tabPotion;
    public GameObject feuVert;
    private ParticleSystem feu;
    public GameObject potionJaune;
    // Start is called before the first frame update
    void Start()
    {
        feu = feuVert.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        //feu = feuVert.GetComponent<ParticleSystem>();
        if(feu.isPlaying)
        {
            Animator potion = potionJaune.GetComponent<Animator>();
            potion.SetTrigger("PotionJaune");
        }
        
    }
}

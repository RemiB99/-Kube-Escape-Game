using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contexteScript : MonoBehaviour
{
    
    private int numPassage = 0;
    private int numFautes = 0;
    private GameObject bouche;
    private bool hasPassed = false;
    // Start is called before the first frame update
    void Awake()
    {
        bouche = GameObject.Find("Bouches");
        numPassage = 0;
        
        if(PlayerPrefs.GetInt("Player Score")!=null){
            numPassage = PlayerPrefs.GetInt("Player Score");
        }
        if(PlayerPrefs.GetInt("Fautes")!=null){
            numPassage = PlayerPrefs.GetInt("Fautes");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(numPassage == 0 && !hasPassed){
            StartCoroutine(blablaBouche1());
            hasPassed = true;
        }

        if(numPassage == 1 && !hasPassed){
            StartCoroutine(blablaBouche2());
            hasPassed = true;
        }

        if(numPassage == 2 && !hasPassed){
            StartCoroutine(blablaBouche3());
            hasPassed = true;
        }
    }

    IEnumerator blablaBouche1(){
        bouche.GetComponent<Bouches>().animBoucheContente();
        bouche.GetComponent<Bouches>().setText("Ah, vous voilà reveillé, je me suis inquiété..."
                                                + " Je suis Pierrot, je vais vous guider dans cette aventure ");
        yield return new WaitForSeconds(7);
        bouche.GetComponent<Bouches>().animBoucheReflechi();
        bouche.GetComponent<Bouches>().setText("On raconte que des sorciers à l'origine de nombreuses méthodes "
                                                +" de la gestion de projet vivaient ici il y a des années");
        yield return new WaitForSeconds(7);
        bouche.GetComponent<Bouches>().animBoucheReflechi();
        bouche.GetComponent<Bouches>().setText("Je vous propose de partir sur leurs traces pour acquérir leurs connaissances." +
                                                " Commençons par nous rendre dans la « Bibliothèque »");
        
    }

    IEnumerator blablaBouche2(){
        bouche.GetComponent<Bouches>().animBoucheTriste();
        bouche.GetComponent<Bouches>().setText("Bon, essayons de tirer les bonnes conclusions de notre échec." +
                                                " Je pense que nous aurions dû un peu plus réfléchir à ce que le client demandait…");
        yield return new WaitForSeconds(7);
        bouche.GetComponent<Bouches>().animBoucheReflechi();
        bouche.GetComponent<Bouches>().setText("Nous nous sommes précipités dans sa mission sans nous mettre d’accord." +
                                                " Peut-être qu’en ayant parlé plus au client plus régulièrement…");
        yield return new WaitForSeconds(7);
        bouche.GetComponent<Bouches>().animBoucheReflechi();
        bouche.GetComponent<Bouches>().setText("Enfin bref, tout cela me rappelle une autre méthode que ces sorciers ont inventé pour pallier ces problèmes.");

        yield return new WaitForSeconds(7);
        bouche.GetComponent<Bouches>().animBoucheReflechi();
        bouche.GetComponent<Bouches>().setText("Continuons notre aventure, nous avons pleins d’autres choses à découvrir." +
                                                " Allons vers la « Taverne », un peu de détente ne fera pas de mal.");
        /*yield return new WaitForSeconds(7);
        bouche.GetComponent<Bouches>().animBoucheContente();
        bouche.GetComponent<Bouches>().setText("Enfin bref, tout cela me rapelle une autre méthode que ces sorciers ont inventé"
                                                +"pour palier à ces problèmes...");
        yield return new WaitForSeconds(7);
        bouche.GetComponent<Bouches>().animBoucheContente();
        bouche.GetComponent<Bouches>().setText("Continuons notre aventure, nous avons pleins d'autres choses à découvrir"
                                                +"Allons vers cet autre bâtiment 'Taverne', un peu de détente ne fait pas de mal");*/
        
    }

    IEnumerator blablaBouche3(){
        bouche.GetComponent<Bouches>().animBoucheContente();
        bouche.GetComponent<Bouches>().setText("Ah, nous voilà de retour à l’extérieur." +
                                                " Il faut dire que cette mission n’était pas de tout repos… Faisons un bilan de ce que nous avons appris.");
        yield return new WaitForSeconds(7);
        bouche.GetComponent<Bouches>().animBoucheContente();
        bouche.GetComponent<Bouches>().setText("Déjà nous avons bien fait d’écouter en détails cette cliente." +
                                                " Il était important de bien comprendre ce dont elle avait besoin.");
        yield return new WaitForSeconds(7);
        bouche.GetComponent<Bouches>().animBoucheContente();
        bouche.GetComponent<Bouches>().setText("Je pense également que de rester en contact avec cette cliente régulièrement était une très bonne chose.");

        yield return new WaitForSeconds(7);
        bouche.GetComponent<Bouches>().animBoucheReflechi();
        bouche.GetComponent<Bouches>().setText("Nous avons pu être au courant de ses changements d’avis et être sûrs de faire ce qu’elle voulait au final.");

        yield return new WaitForSeconds(7);
        bouche.GetComponent<Bouches>().animBoucheContente();
        bouche.GetComponent<Bouches>().setText("Bon, le moment que je redoutais est arrivé. Je crois bien qu’il est temps pour nous de nous quitter :( ");

        yield return new WaitForSeconds(7);
        bouche.GetComponent<Bouches>().animBoucheContente();
        bouche.GetComponent<Bouches>().setText("Mais avant ça, j’ai une récompense pour vous ! J’ai pris note de vos performances, et vous ai attribué un score");

        yield return new WaitForSeconds(7);
        bouche.GetComponent<Bouches>().animBoucheContente();
        bouche.GetComponent<Bouches>().setText("Mais avant ça, j’ai une récompense pour vous ! J’ai pris note de vos performances, et vous ai attribué un score");

       /* yield return new WaitForSeconds(7);
        bouche.GetComponent<Bouches>().animBoucheTriste();
        bouche.GetComponent<Bouches>().setText("Bon , le moment que je redoutais est arrivé"
                                                + " Je crois bien qu'il est temps pour nous de nous quitter :( ");
        yield return new WaitForSeconds(7);
        bouche.GetComponent<Bouches>().animBoucheContente();
        bouche.GetComponent<Bouches>().setText("Mais avant ça, j'ai une récompense pour vous !"
                                                + "J'ai pris note de vos performances, et vous ai attribué un score");
        yield return new WaitForSeconds(7);
        bouche.GetComponent<Bouches>().animBoucheContente();
        bouche.GetComponent<Bouches>().setText("Votre trophée vous attend !"
                                                + "J'espère vous revoir bientôt, à la prochaine !!");*/
        // TRUC DE ROBIN WAGNER A METTRE ICI ET PAS A UN AUTRE ENDROIT C'EST COMPRIS ?????
        yield return new WaitForSeconds(7);
        GameObject Fin = GameObject.Find("Fin");
        Fin.GetComponent<Faute>().resultat();
    }
}

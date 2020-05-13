using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contexteScript : MonoBehaviour
{
    
    private int tina = 0;
    private GameObject bouche;
    private bool hasPassed = false;
    // Start is called before the first frame update
    void Awake()
    {
        bouche = GameObject.Find("Bouches");
        tina = 0;
        //tina++;
        Debug.Log(tina);
        if(PlayerPrefs.GetInt("Player Score")!=null){
            Debug.Log(PlayerPrefs.GetInt("Player Score"));
            tina = PlayerPrefs.GetInt("Player Score");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(tina == 0 && !hasPassed){
            StartCoroutine(blablaBouche1());
            hasPassed = true;
        }

        if(tina == 1 && !hasPassed){
            StartCoroutine(blablaBouche2());
            hasPassed = true;
        }

        if(tina == 2 && !hasPassed){
            StartCoroutine(blablaBouche3());
            hasPassed = true;
        }
    }

    IEnumerator blablaBouche1(){
        bouche.GetComponent<Bouches>().animBoucheContente();
        bouche.GetComponent<Bouches>().setText("Ah, vous voila reveillé, je me suis inquiété..."
                                                + " Je suis Pierrot, je vais vous guider dans cette aventure ");
        yield return new WaitForSeconds(7);
        bouche.GetComponent<Bouches>().animBoucheContente();
        bouche.GetComponent<Bouches>().setText("On raconte que des sorciers à l'origine de nombreuses méthodes "
                                                +" de la gestion de projet vivaient ici il y a des années");
        yield return new WaitForSeconds(7);
        bouche.GetComponent<Bouches>().animBoucheContente();
        bouche.GetComponent<Bouches>().setText("Je vous propose de partir sur leurs traces, pour acquiérir leurs connaissances. "
                                                + " Commençons par cette maison 'Bibliothèque', ce sera notre première étape");
        
    }

    IEnumerator blablaBouche2(){
        bouche.GetComponent<Bouches>().animBoucheTriste();
        bouche.GetComponent<Bouches>().setText("Bon, nous avons appris des choses mais nous finissons sur un échec."
                                                + "Essayons d'en tirer les bonnes conclusions");
        yield return new WaitForSeconds(7);
        bouche.GetComponent<Bouches>().animBoucheReflechi();
        bouche.GetComponent<Bouches>().setText("Je pense que nous aurions dû un peu plus réfléchir à ce que ce client demandait..."
                                                +"C'est la première erreur que nous avons faite");
        yield return new WaitForSeconds(7);
        bouche.GetComponent<Bouches>().animBoucheReflechi();
        bouche.GetComponent<Bouches>().setText("Nous nous sommes aussi très vite précipités dans sa mission sans nous mettre d'accord"
                                                +"J'avoue que je me suis un peu placé en chef sur le coup...");
        yield return new WaitForSeconds(7);
        bouche.GetComponent<Bouches>().animBoucheReflechi();
        bouche.GetComponent<Bouches>().setText("Et puis, il aurait peut-être  été judicieux de confirmer que nous étions sur la bonne voie"
                                                +"Peut-être qu'en  ayant parlé au client plus régulièrement...");
        yield return new WaitForSeconds(7);
        bouche.GetComponent<Bouches>().animBoucheContente();
        bouche.GetComponent<Bouches>().setText("Enfin bref, tout cela me rapelle une autre méthode que ces sorciers ont inventé"
                                                +"pour palier à ces problèmes...");
        yield return new WaitForSeconds(7);
        bouche.GetComponent<Bouches>().animBoucheContente();
        bouche.GetComponent<Bouches>().setText("Continuons notre aventure, nous avons pleins d'autres choses à découvrir"
                                                +"Allons vers cet autre bâtiment 'Taverne', un peu de détente ne fait pas de mal");
        
    }

    IEnumerator blablaBouche3(){
        bouche.GetComponent<Bouches>().animBoucheContente();
        bouche.GetComponent<Bouches>().setText("Ah, nous voila de retour à l'éxtérieur, il faut dire que cette "
                                                + " mission n'était pas de tout repos...");
        yield return new WaitForSeconds(7);
        bouche.GetComponent<Bouches>().animBoucheContente();
        bouche.GetComponent<Bouches>().setText("Mais au moins, elle aura été très instructive "
                                                +" Faisons un bilan de ce que nous avons appris...");
        yield return new WaitForSeconds(7);
        bouche.GetComponent<Bouches>().animBoucheContente();
        bouche.GetComponent<Bouches>().setText("Déja nous avons bien fait d'écouter en détails ce client"
                                                +"Il est important de bien savoir ce dont il a besoin");
        yield return new WaitForSeconds(7);
        bouche.GetComponent<Bouches>().animBoucheReflechi();
        bouche.GetComponent<Bouches>().setText("Ensuite, le choix des tâches qu'il nous à confiées était mieux organisé. "
                                                +" Il est bien d'avoir une idée à l'avance de l'importance des tâches à effectuer...");
        yield return new WaitForSeconds(7);
        bouche.GetComponent<Bouches>().animBoucheContente();
        bouche.GetComponent<Bouches>().setText("Et surtout que tout le monde soit d'accord !");
        yield return new WaitForSeconds(7);
        bouche.GetComponent<Bouches>().animBoucheContente();
        bouche.GetComponent<Bouches>().setText("Enfin, je pense que de rester en contact avec ce client régulièrement"
                                                + " était une très bonne chose.");
        yield return new WaitForSeconds(7);
        bouche.GetComponent<Bouches>().animBoucheContente();
        bouche.GetComponent<Bouches>().setText("Nous avons pû être au courant de ses changements d'avis et être"
                                                + " surs de faire ce qu'il voulait au final");
        yield return new WaitForSeconds(7);
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
                                                + "J'espère vous revoir bientôt, à la prochaine !!");
        // TRUC DE ROBIN WAGNER A METTRE ICI ET PAS A UN AUTRE ENDROIT C'EST COMPRIS ?????
        yield return new WaitForSeconds(7);
        GameObject Fin = GameObject.Find("Fin");
        Fin.GetComponent<Faute>().resultat();
    }
}

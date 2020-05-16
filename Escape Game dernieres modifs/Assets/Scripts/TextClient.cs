using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class TextClient : MonoBehaviour
{
    public GameObject ZoneTextClient;
    public GameObject Client;
    private GameObject text;
    private bool zoneActive;
    private GameObject ampoule;
    private string[] texts;
    private int nbTexts = 25;
    private string textActuel;
    private GameObject[] objetChangemantText;
    private int nbObjets = 1;
    private bool estPassé;
    private bool premierTexteClient;
    private bool enigmePays, enigmeNom, enigmePlaque, hasPassed,finifini;

    // varialbes déroulement du scénario//
    private GameObject map ;
    private GameObject BLB ;
    private GameObject BookCars;

    void Start()
    {
        texts = new string[nbTexts];
        objetChangemantText = new GameObject[nbObjets];
        initTexts();
        findObjetChangementText();
        text = ZoneTextClient.transform.GetChild(0).gameObject;
        text.GetComponent<Text>().text = texts[0];
        textActuel = texts[0];
        ampoule = GameObject.Find("Ampoule");
        //ampoule.SetActive(false);
        zoneActive = false;
        estPassé = false;
        enigmePays = false;
        enigmeNom = false;
        enigmePlaque = false;
        premierTexteClient = false;
        hasPassed = false;
        finifini = false;

        // initialisation des variables déroulement du scénario //
        map = GameObject.Find("WorldMap");
        BLB = GameObject.Find("BackLogBook");
        BookCars = GameObject.Find("BookEnigme");
        
        BLB.SetActive(false);
        map.GetComponent<BoxCollider>().enabled = true;
        BookCars.GetComponent<BoxCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(finTroisTaches() && !finifini){
            blablaFin();
            finifini = true;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit)) { 
            if (Input.GetMouseButtonDown(0))
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    if (hit.transform.name == "Client")
                    {
                        if (!premierTexteClient)
                        {
                            
                            StartCoroutine(blablaClient());
                            premierTexteClient = true;
                        }
                        else
                        {
                            changeZone();
                            ampoule.SetActive(false);
                        }

                    }
                    avancementScenario();

                    for (int i = 0; i < nbObjets; i++)
                    {
                        if ((objetChangemantText[i].transform.name == hit.transform.name))
                        {

                            changeText();
                        }
                        if (objetChangemantText[i].transform.name == "index2" && objetChangemantText[i].activeSelf && !estPassé)
                        {
                            estPassé = true;
                            chgmtEnigmeNom();
                        }
                    

                    }
                }
            }  
        }
        
        if (textHasChanged())
        {
            ampoule.SetActive(true);
        }

    }

    public void changeZone()
    {
        zoneActive = !zoneActive;
        ZoneTextClient.SetActive(zoneActive);
    }
    
    public void changeText()
    {
        for(int i = 0; i < nbTexts-1 ; i++)
        {
            if(textActuel == texts[i])
            {
                text.GetComponent<Text>().text = texts[i + 1];
            }
        }
    }

    public bool textHasChanged()
    {
        if (text.GetComponent<Text>().text != textActuel)
        {
            textActuel = text.GetComponent<Text>().text;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void initTexts()
    {
        texts[0] = "  Vous ne me serez surement d’aucune aide, comme toutes les personnes qui sont passées par ici avant vous… Mais bon, je peux toujours essayer.";
        texts[1] = "  Je vous propose de m’aider à trouver quelqu’un que je cherche depuis longtemps. Si vous réussissez, je vous donnerai évidemment une récompense.";
        texts[2] = "  Mon assistant vous fournira la liste des choses que j’attends de vous, mais vous feriez bien de m’écouter attentivement..";
        texts[3] = "  Il y a quelques mois, un voleur est entré dans la taverne et m’a volé un trésor d’une valeur inestimable…";
        texts[4] = "  Malheureusement je n’ai AUCUNE information sur l’identité de ce voleur.";
        texts[5] = "  Afin de le retrouver j’aurais besoin que vous trouviez pour moi plusieurs renseignements essentiels qui permettront de déterminer son identité comme son âge, son sexe, son métier, ou encore son nom.";
        texts[6] = "  Des éléments permettant de définir à quoi il ressemble physiquement comme sa taille, un accessoire caractéristique qu’il pourrait porter, ou encore la couleur de ses yeux et de ses cheveux pourraient également m’être utiles.";
        texts[7] = "  Attention !!! je n’ai pas besoin d’informations inutiles comme sa boisson, son plat, ou son film préféré…";
        texts[8] = "  Je compte sur vous !Ah oui, j’oubliais, j’aurais aussi besoin de savoir à bord de quel véhicule il s’est enfui et vers quel pays il est allé.";
        texts[9] = "  Voilà, récupérez le papier écrit par mon assistant et vous pouvez commencer. Je compte sur vous !";
        texts[10] = " Comment ça 10 tâches c’est trop pour vous ?! Vous avez peut-être raison…" +
                    " C’est peut-être pour ça que personne n’a réussi avant… Je vais vous proposer de se concentrer sur 3 de ces tâches.";
        texts[11] = " La première tâche consiste à trouver le sexe du voleur. Pour cela, vous devriez fouillez la taverne. Des parchemins pourraient vous être utiles…" +
                    " Revenez me voir quand vous l’aurez trouvé.";
        /*texts[12] = " Ensuite, j'ai besoin de connaître le pays vers lequel il s'est enfui" +
                    " Ma secrétaire à déja commencé l'enquête à ce sujet, elle a laissé ses notes sur un tableau quelque part";
        texts[13] = " Enfin, pour le retrouver au plus vite, il nous faut l'immatriculation de son véhicule" +
                    " La liste est déja réduite à une dizaine de plaques, mais il faut encore l'affiner";
        texts[14] = " Voila, vous savez tout, à vous de vous organisez maintenant au mieux. Prenez ceci, cela vous aidera"+
                    " Bon courage, je vous tiens au courant de tout changement...";*/
        /*texts[15] = " Parfait, votre organisation me convient, il est maintenant temps d'agir"+
                    " Faîtes au plus vite, la pièce contient tout ce dont vous aurez besoin";*/
        texts[16] = " Finalement, j’aurais besoin non seulement de son sexe, mais également de son nom. J’imagine que cela ne vous pose pas de problème…";
        texts[17] = " SkullBen vous dites ? Excellent, nous tenons notre homme. Avec les autres informations, nous aurons tout ce qu’il nous faut pour retrouver cette crapule !";
        texts[18] = " J’aurais maintenant besoin de connaître le pays vers lequel il s’est enfui. Mon assistant a déjà commencé l’enquête à ce sujet." +
                    " Il a laissé ses notes sur un tableau quelque part… Sélectionner le pays sur la carte quand vous pensez l’avoir trouvé.";
        texts[19] = " Ah, le Congo, nous n’étions pas partis sur cette piste, bien joué !";
        texts[20] = " Enfin, pour le retrouver au plus vite, il nous faut l’immatriculation de son véhicule." +
                    " La liste est déjà réduite à une dizaine de plaques, mais il faut encore l’affiner." +
                    " Vous trouverez tout le nécessaire pour le faire dans la pièce située à l’arrière de la taverne.";
        texts[21] = " Bien, nous connaissons maintenant la plaque d’immatriculation du véhicule que le voleur a utilisé." +
                    " C’est un pas de plus vers la découverte de ce criminel.";
        texts[22] = " Et bien, il semblerait que vous ayez réuni toutes les informations demandées je suis satisfait de votre travail." +
                    " Merci beaucoup !";
        texts[23] = " Il ne vous reste plus qu’à découvrir si vous avez été suffisamment efficaces. Poussez la porte pour connaître la réponse…";
        texts[24] = " hello 24";
    }

    public void findObjetChangementText()
    {
        GameObject hints = GameObject.Find("Hints");
        GameObject hint = hints.transform.GetChild(1).gameObject;
        objetChangemantText[0] = hint;
    }

    IEnumerator blablaClient()
    {
        text.GetComponent<Text>().text = texts[0];
        yield return new WaitForSeconds(10);

        text.GetComponent<Text>().text = texts[1];
        
        yield return new WaitForSeconds(10);

        text.GetComponent<Text>().text = texts[2];
        yield return new WaitForSeconds(5);

        text.GetComponent<Text>().text = texts[3];
        yield return new WaitForSeconds(5);

        text.GetComponent<Text>().text = texts[4];
        yield return new WaitForSeconds(5);

        text.GetComponent<Text>().text = texts[5];
        yield return new WaitForSeconds(5);

        text.GetComponent<Text>().text = texts[6];
        yield return new WaitForSeconds(5);

        text.GetComponent<Text>().text = texts[7];
        yield return new WaitForSeconds(5);

        text.GetComponent<Text>().text = texts[8];
        yield return new WaitForSeconds(5);

        text.GetComponent<Text>().text = texts[9];

        yield return new WaitForSeconds(5);
    }

    public void lanceExplications(){
        StartCoroutine(explicTaches());
    }

    IEnumerator explicTaches()
    {
        text.GetComponent<Text>().text = texts[10];
        yield return new WaitForSeconds(10);

        text.GetComponent<Text>().text = texts[11];
        
        yield return new WaitForSeconds(5);

    }

    IEnumerator textEnigmePays()
    {
        text.GetComponent<Text>().text = texts[19];
        yield return new WaitForSeconds(10);

        text.GetComponent<Text>().text = texts[20];
        yield return new WaitForSeconds(10);
    }

    IEnumerator textEnigmeNom()
    {
        text.GetComponent<Text>().text = texts[17];
        yield return new WaitForSeconds(10);

        text.GetComponent<Text>().text = texts[18];
        

    }

    IEnumerator textEnigmePlaque()
    {
        text.GetComponent<Text>().text = texts[21];
        yield return new WaitForSeconds(10);

    }

    IEnumerator textEnigmeSexe()
    {
        text.GetComponent<Text>().text = texts[16];
        yield return new WaitForSeconds(10);

    }

    IEnumerator textFinal()
    {
        
        yield return new WaitForSeconds(10);
        text.GetComponent<Text>().text = texts[22];
        yield return new WaitForSeconds(3);
        text.GetComponent<Text>().text = texts[23];

    }

    public void finEnigmePays(){
        Debug.Log("pays");
        enigmePays = true;
            StartCoroutine(textEnigmePays());
    }

    public void finEnigmePlaque(){
        Debug.Log("plaques");
        enigmePlaque = true;
            StartCoroutine(textEnigmePlaque());
    }

    public void finEnigmeNom(){
        Debug.Log("noms");
        enigmeNom = true;
            StartCoroutine(textEnigmeNom());
    }

    public void chgmtEnigmeNom(){
            StartCoroutine(textEnigmeSexe());
    }

    public bool finTroisTaches(){
        return enigmePlaque && enigmePays && enigmeNom;
    }

    public void blablaFin(){
            StartCoroutine(textFinal());
    }



    public void avancementScenario()
    {
        
        if (text.GetComponent<Text>().text == texts[9] && !hasPassed)
        {
            BLB.SetActive(true);
            hasPassed = true;
        }
        if (text.GetComponent<Text>().text == texts[15]) 
        {
            BookCars.GetComponent<BoxCollider>().enabled = true;
            map.GetComponent<BoxCollider>().enabled = true;
        }
    }
}

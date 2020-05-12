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
        premierTexteClient = false;

        // initialisation des variables déroulement du scénario //
        map = GameObject.Find("WorldMap");
        BLB = GameObject.Find("BackLogBook");
        BookCars = GameObject.Find("BookEnigme");
        
        BLB.SetActive(false);
        map.GetComponent<BoxCollider>().enabled = false;
        BookCars.GetComponent<BoxCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
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
                            changeText();
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
        texts[2] = "  Ma secrétaire vous fournira la liste des choses que j’attends de vous, mais vous feriez bien de m’écouter attentivement.";
        texts[3] = "  Il y a quelques mois, un voleur est entré dans la taverne et m’a volé un trésor d’une valeur inestimable…";
        texts[4] = "  Malheureusement je n’ai AUCUNE information sur l’identité de ce voleur.";
        texts[5] = "  Afin de le retrouver j’aurais besoin que vous trouviez pour moi plusieurs renseignements essentiels qui permettront de déterminer son identité comme son âge, son sexe, son métier, ou encore son nom.";
        texts[6] = "  Des éléments permettant de définir à quoi il ressemble physiquement comme sa taille, un accessoire caractéristique qu’il pourrait porter, ou encore la couleur de ses yeux et de ses cheveux pourraient également m’être utiles.";
        texts[7] = "  Attention !!! je n’ai pas besoin d’informations inutiles comme sa boisson, son plat, ou son film préféré…";
        texts[8] = " Je compte sur vous !Ah oui, j’oubliais, j’aurais aussi besoin de savoir à bord de quel véhicule il s’est enfui et vers quel pays il est allé.";
        texts[9] = " Voilà, récupérez le papier écrit par ma secrétaire et vous pouvez commencer.Je compte sur vous !";
        texts[10] = " Ah parfait ! Vous avez bien résumé la situation, c'est un bon début, " +
                    " Maintenant, il va falloir s'organiser pour réaliser ces tâches au mieux, tenez ceci pourra vous être utile" +
                    " (Vous êtes plus efficace que ma secrétaire, je ferais mieux d'engager isabelle wagner)";
        texts[11] = "  Vos estimations de temps me conviennent, je vous laisse essayer de chercher le véhicule avec lequel le voleur s’est enfui, revenez me voir dès que vous pensez l’avoir trouvé !";
        texts[12] = " hello yolo";
        texts[13] = " hello 13";
        texts[14] = " hello 14";
        texts[15] = " hello 15";
        texts[16] = " hello 16";
        texts[17] = " hello 17";
        texts[18] = " hello 18";
        texts[19] = " hello 19";
        texts[20] = " hello 20";
        texts[21] = " hello 21";
        texts[22] = " hello 22";
        texts[23] = " hello 23";
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
        yield return new WaitForSeconds(10);

        text.GetComponent<Text>().text = texts[6];
        yield return new WaitForSeconds(10);

        text.GetComponent<Text>().text = texts[7];
        yield return new WaitForSeconds(5);

        text.GetComponent<Text>().text = texts[8];
        yield return new WaitForSeconds(10);

        text.GetComponent<Text>().text = texts[9];

        yield return new WaitForSeconds(10);
    }



    public void avancementScenario()
    {
        
        if (text.GetComponent<Text>().text == texts[9])
        {
            BLB.SetActive(true);
        }
        if (text.GetComponent<Text>().text == texts[11]) 
        {
            BookCars.GetComponent<BoxCollider>().enabled = true;
        }
    }
}

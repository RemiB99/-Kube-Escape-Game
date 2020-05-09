using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;
using UnityEngine.EventSystems;

public class MelangePotionScript : MonoBehaviour
{
    public GameObject tableau;
    public GameObject recipient;
    public GameObject contourRecipient;
    private bool hasPlayed = false;
    private bool hasPlayed2 = false;
    private bool test = false;
    public GameObject[] potions = new GameObject[7];
    private GameObject bouche;
    // Start is called before the first frame update
    void Start()
    {
        bouche = GameObject.Find("Bouches");
    }

    // Update is called once per frame
    void Update()
    {   
        
        if ((Input.GetMouseButtonDown(0)))
        {   
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if ((Physics.Raycast(ray, out hit))){
                if(!EventSystem.current.IsPointerOverGameObject()){
                    
                    if(hit.transform.name == this.name){
                        if(!hasPlayed){
                            StartCoroutine(animTextClient());
                            hasPlayed = true;
                        }
                        
                    }
                }
                
            }
        }
        if(!test)
            verifPotionsRecipient();
        if(GameObject.Find("RecipientMain")!=null){

            contourRecipient.SetActive(true);
            contourRecipient.GetComponent<MeshRenderer>().enabled = true;
            this.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = "Vous avez fini ? Placez votre préparation ici...";

        }
    }

    IEnumerator animTextClient(){

        GameObject textClient = this.transform.GetChild(0).gameObject;
        GameObject sorcier = this.transform.GetChild(1).gameObject;
        Destroy(this.transform.GetChild(2).gameObject);
        sorcier.GetComponent<SpriteRenderer>().enabled = true;

        textClient.GetComponent<TextMeshPro>().text = "Ah... vous voila ! J'ai vraiment besoin d'aide, "
                                                        + "on m'a dit que vous saviez comment bien gérer un projet !";
        yield return new WaitForSeconds(5);
        textClient.GetComponent<TextMeshPro>().text = "Voici ma mission : j'ai besoin que vous m'aidiez à préparer une potion"
                                                        +" très importante, elle doit être préparée dans un ordre bien précis";
        yield return new WaitForSeconds(5);
        textClient.GetComponent<TextMeshPro>().text = "Elle s'appelle 'Potion de logiciel bien pensé' Pierrot pourra vous aider"
                                                        +", vous feriez bien de l'écouter, suivez bien ses conseils ...";
        yield return new WaitForSeconds(5);
        textClient.GetComponent<TextMeshPro>().text = "Vous devriez trouver les potions dont vous aurez besoin dans la pièce"
                                                        +" Vous trouverez aussi après de quoi les mélanger. Bon courage ! Je compte sur vous";
        yield return new WaitForSeconds(5);
        bouche.GetComponent<Bouches>().animBoucheReflechi();
        bouche.GetComponent<Bouches>().setText("Ah, la potion de logiciel bien pensé, c'est une potion très utile pour vous"
                                                + "mais hélas, très peu arrivent à la maîtriser parfaitement");
        yield return new WaitForSeconds(5);
        bouche.GetComponent<Bouches>().animBoucheContente();
        bouche.GetComponent<Bouches>().setText("Enfin bref, pour le moment, cherchons ces potions, elles ne doivent pas être très"
                                                + " difficiles à trouver. Il y en a 7 si je me souviens bien...");
        debutTachePotion();

    }

    public void debutTachePotion(){
        // Active toutes les potions + biblio descente + ouverture coffre
        
        GameObject coffre = GameObject.Find("Coffre");
        GameObject bookCase = GameObject.Find("bookCaseMove");
        
        coffre.GetComponent<BoxCollider>().enabled = true;
        Animator bookcaseReveal = bookCase.GetComponent<Animator>();
        bookcaseReveal.SetTrigger("MoveBookCase");
        bookCase.GetComponent<AudioSource>().Play();

        potions[2].GetComponent<Outline>().enabled = true;
        potions[3].GetComponent<Outline>().enabled = true;
        potions[4].GetComponent<Outline>().enabled = true;


    }

    public void verifPotionsRecipient(){
        bool potionsRecup = true;
        foreach(var pot in potions){
            if(pot.activeSelf){
                potionsRecup = false;
            }
        }

        if(potionsRecup){
            recipient.SetActive(true);
            test = true;
        }
    }

}

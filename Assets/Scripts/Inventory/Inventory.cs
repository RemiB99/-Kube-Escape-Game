using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventory;
    public GameObject slotHolder;

    

    public bool estPassé = true;
    private bool inventoryEnabled;
    private int allSlots;
    public GameObject[] slot;

    private string[] textesBouche = new string[20];
    private GameObject bouche;

    void Awake()
    {
        allSlots = 27;
        slot = new GameObject[allSlots];

        for (int i = 0; i < allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;

            if (slot[i].GetComponent<Slot>().item == null)
            {
                slot[i].GetComponent<Slot>().empty = true;
                
                slot[i].SetActive(false);
            }
        }

        textesBouche[1] = "Vous avez recupéré un objet, consultez-le dans votre inventaire pour en apprendre plus";
        textesBouche[2] = "Aïe aïe aïe... Elle ne se laissera pas faire si facilement...";
        textesBouche[3] = "Ne touchez pas à ça malheureux ! Cela pourrait être dangereux...";
        textesBouche[4] = "Je vous l'avait dit ! Ce diamant est maudit ! ";

        bouche = GameObject.Find("Bouches");
    }
    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryEnabled = !inventoryEnabled;
        }
        if(inventoryEnabled == true)
        {
            //inventory.SetActive(true);
            inventory.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {//Inventaire fermé

            inventory.transform.localScale = new Vector3(0, 0, 0);
            GameObject diams = GameObject.Find("DiamantMain");
            
            //Cinématique Fin du Monde
            if( diams != null && estPassé){
                    
                    bouche.GetComponent<Bouches>().animBoucheFache();
                    bouche.GetComponent<Bouches>().setText(textesBouche[4]);

                    diams.GetComponent<AudioSource>().Play();

                    GameObject test = GameObject.Find("Tornade");
                    test.GetComponent<ParticleSystem>().Play();

                    GameObject image = GameObject.Find("Image");
                    image.GetComponent<Animator>().SetTrigger("FonduFDM");
                    estPassé = false;
            }

        }
        if (Input.GetMouseButtonDown(0)) {
            if (Physics.Raycast(ray, out hit)){
                if(hit.transform.name == "StrangeFlower" && GameObject.Find("PotionBleueMain")== null){
                    
                    bouche.GetComponent<Bouches>().animBoucheTriste();
                    bouche.GetComponent<Bouches>().setText(textesBouche[2]);
                }

                if(hit.transform.name == "PotionVerte" || hit.transform.name == "PotionViolette"){
                    
                    bouche.GetComponent<Bouches>().animBoucheFache();
                    bouche.GetComponent<Bouches>().setText(textesBouche[3]);
                }

                if (hit.transform.tag == "Item") {
                    //Recupération d'objet inventaire
                    
                    GameObject itemPickedUp = hit.transform.gameObject;
                    itemPickedUp.transform.parent.GetComponent<AudioSource>().Play();
                    Item item = itemPickedUp.GetComponent<Item>();

                    if(itemPickedUp.name == "Diamant"){
                        itemPickedUp.transform.GetChild(0).gameObject.SetActive(false);
                        itemPickedUp.transform.GetChild(1).gameObject.SetActive(false);
                    }

                    /*if(itemPickedUp.name == "PotionRouge"){
                        
                        bouche.GetComponent<Bouches>().animBoucheContente();
                        bouche.GetComponent<Bouches>().setText(textesBouche[1]);
                        
                    }*/
                    
                    bouche.GetComponent<Bouches>().animBoucheContente();
                    bouche.GetComponent<Bouches>().setText(textesBouche[1]);
                    AddItem(itemPickedUp, item.id, item.type, item.description, item.icon, item.use);
                }
                if (hit.transform.name == "door")
                {
                    ItemSaveManager.saveItems(slot, "slotsSave");
                }
            } 
        }
    }


    public void AddItem(GameObject itemObject, int itemId, string itemType, string itemDescription, Sprite itemIcon, string itemUse)
    {
        Debug.Log("passage item");
        Debug.Log(allSlots);
        for (int i =0; i < allSlots; i++)
        {
            Debug.Log("passage for");
            if (slot[i].GetComponent<Slot>().empty)
            {
                Debug.Log("slot i empty");
                itemObject.GetComponent<Item>().pickedUp = true;

                slot[i].GetComponent<Slot>().item = itemObject;
                slot[i].GetComponent<Slot>().icon = itemIcon;
                slot[i].GetComponent<Slot>().type = itemType;
                slot[i].GetComponent<Slot>().description = itemDescription;
                slot[i].GetComponent<Slot>().id = itemId;
                slot[i].GetComponent<Slot>().use = itemUse;

                itemObject.transform.parent = slot[i].transform;
                itemObject.SetActive(false);

                slot[i].GetComponent<Slot>().UpdateSlot();
                slot[i].GetComponent<Slot>().empty = false;
                slot[i].SetActive(true);
                return;
            }
            
        }
        return;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventory;
    public GameObject slotHolder;

    public bool hamze = true;
    private bool inventoryEnabled;
    private int allSlots;
    private GameObject[] slot;

    

    void Start()
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
        {
            inventory.transform.localScale = new Vector3(0, 0, 0);
            GameObject diams = GameObject.Find("DiamantMain");
            
            if( diams != null && hamze){
                    
                    diams.GetComponent<AudioSource>().Play();

                    GameObject test = GameObject.Find("Tornade");
                    test.GetComponent<ParticleSystem>().Play();

                    GameObject image = GameObject.Find("Image");
                    image.GetComponent<Animator>().SetTrigger("FonduFDM");
                    hamze = false;
            }

        }
        if (Input.GetMouseButtonDown(0)) {
            if (Physics.Raycast(ray, out hit)){
                
                if (hit.transform.tag == "Item") {
                    //Debug.Log(hit.transform.name);
                    
                    GameObject itemPickedUp = hit.transform.gameObject;
                    itemPickedUp.transform.parent.GetComponent<AudioSource>().Play();
                    Item item = itemPickedUp.GetComponent<Item>();

                    if(itemPickedUp.name == "Diamant"){
                        itemPickedUp.transform.GetChild(0).gameObject.SetActive(false);
                        itemPickedUp.transform.GetChild(1).gameObject.SetActive(false);
                        

                    }
                    
                    AddItem(itemPickedUp, item.id, item.type, item.description, item.icon);
                    
                    
                }
            } 
        }
    }


    public void AddItem(GameObject itemObject, int itemId, string itemType, string itemDescription, Sprite itemIcon)
    {
        for(int i =0; i < allSlots; i++)
        {
            if (slot[i].GetComponent<Slot>().empty)
            {
                itemObject.GetComponent<Item>().pickedUp = true;

                slot[i].GetComponent<Slot>().item = itemObject;
                slot[i].GetComponent<Slot>().icon = itemIcon;
                slot[i].GetComponent<Slot>().type = itemType;
                slot[i].GetComponent<Slot>().description = itemDescription;
                slot[i].GetComponent<Slot>().id = itemId;

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

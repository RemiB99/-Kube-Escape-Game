using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : NetworkBehaviour
{
    public GameObject inventory;

    [SyncVar]
    public GameObject slotHolder;
    //public GameObject player;

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

       /* if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryEnabled = !inventoryEnabled;
        }
        if(inventoryEnabled == true)
        {
            inventory.SetActive(true);
        }
        else
        {
            inventory.SetActive(false);
        }*/
        if (Input.GetMouseButtonDown(0)) {
            if (Physics.Raycast(ray, out hit)){
                if (hit.transform.tag == "Item") {
                    //Debug.Log(hit.transform.name);
                    GameObject itemPickedUp = hit.transform.gameObject;
                    Item item = itemPickedUp.GetComponent<Item>();
                    Debug.Log("Clic inventaire");

                    
                    //itemPickedUp.GetComponent<NetworkIdentity>().AssignClientAuthority(player.GetComponent<NetworkIdentity>().connectionToClient);
                    //GameObject playerObj = GameObject.Find("Player(Clone)");
                    AddItem(itemPickedUp, item.id, item.type, item.description);
                }
            } 
        }
    }

    //[Command]
    public void AddItem(GameObject itemObject, int itemId, string itemType, string itemDescription)
    {
        for(int i =0; i < allSlots; i++)
        {
            if (slot[i].GetComponent<Slot>().empty)
            {
                Debug.Log("Passage1");
                itemObject.GetComponent<Item>().pickedUp = true;

                slot[i].GetComponent<Slot>().item = itemObject;
                //slot[i].GetComponent<Slot>().icon = itemIcon;
                slot[i].GetComponent<Slot>().type = itemType;
                slot[i].GetComponent<Slot>().description = itemDescription;
                slot[i].GetComponent<Slot>().id = itemId;

                itemObject.transform.parent = slot[i].transform;
                itemObject.SetActive(false);

                //slot[i].GetComponent<Slot>().UpdateSlot();
                slot[i].GetComponent<Slot>().empty = false;
                slot[i].SetActive(true);
                Debug.Log("Passage2");

                //Canvas canvas = GameObject.Find("InventoryCanvas").GetComponent<Canvas>();
                Canvas.ForceUpdateCanvases();
                return;
            }
            
        }
        return;
    }
}

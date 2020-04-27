using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinkObjects : MonoBehaviour
{
    private GameObject itemManager;
    public int id;
    private GameObject obj;
    private GameObject SlotHolder;
    private GameObject Slot;
    private GameObject panel;

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetMouseButtonDown(0)))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if ((Physics.Raycast(ray, out hit)))
            {
                if (hit.transform.gameObject.tag =="LinkObject" )
                {
                    itemManager = GameObject.FindWithTag("ItemManager");
                    int allItems = itemManager.transform.childCount;
                    for (int i = 0; i < allItems; i++)
                    {
                        if (itemManager.transform.GetChild(i).gameObject.GetComponent<Item>().id == id && itemManager.transform.GetChild(i).gameObject.GetComponent<Item>().equipped)
                        {
                            obj = itemManager.transform.GetChild(i).gameObject;  
                            SlotHolder = GameObject.Find("Slot Holder");
                            

                            for (int j = 0; j < SlotHolder.transform.childCount; j++)
                            {
                                Slot = SlotHolder.transform.GetChild(j).gameObject;
                                panel = Slot.transform.GetChild(0).gameObject;
                                if (obj.GetComponent<Item>().icon == panel.GetComponent<Image>().sprite)
                                {
                                    Destroy(Slot);
                                }
                            }
                            activeAction();
                            Destroy(obj);          
                        }
                    }
                }
            }
        }
    }

    public void activeAction()
    {
        if (obj.name == "Item book player")
        {
            Debug.Log("YEEEEES ça marche !!!");
        }
    }
}

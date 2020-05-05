using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSaveManager : MonoBehaviour
{
    public static void saveItems(GameObject[] slots, string file)
    {
        var saveData = new ItemContainerSaveData(slots.Length);

        for (int i = 0; i < saveData.savedSlots.Length; i++)
        {
            Slot slot = slots[i].GetComponent<Slot>();

            if (slot.empty)
            {
                saveData.savedSlots[i] = null;
            }
            else
            {
                saveData.savedSlots[i] = new ItemSlotSaveData(slot.id);
            }
        }
        ItemSaveIO.saveItems(saveData, file);
    }

    public static void LoadItems(string file)
    {
        ItemContainerSaveData savedSlots = ItemSaveIO.LoadItems(file);

        if (savedSlots != null)
        {
            GameObject canvas = GameObject.Find("Canvas Joystick");
            //Debug.Log("canvas :" + canvas);
            GameObject objets = GameObject.Find("ObjetsInventaire");
            for (int i = 0; i < savedSlots.savedSlots.Length; i++)
            {
                ItemSlotSaveData savedSlot = savedSlots.savedSlots[i];
                if (savedSlot != null)
                {
                    //Debug.Log("id :" + savedSlot.id);
                   // Debug.Log("childCount : " + objets.transform.childCount);
                    for(int j = 0; j < objets.transform.childCount; j++)
                    {
                        if (savedSlot.id == objets.transform.GetChild(j).GetComponent<Item>().id)
                        {
                            GameObject obj = objets.transform.GetChild(j).gameObject;
                            //Debug.Log("obj :" + obj);
                            canvas.GetComponent<Inventory>().AddItem(obj, obj.GetComponent<Item>().id, obj.GetComponent<Item>().type, obj.GetComponent<Item>().description,
                                     obj.GetComponent<Item>().icon, obj.GetComponent<Item>().use);
                        }
                    }
                }
            }
        }
    }
  
}

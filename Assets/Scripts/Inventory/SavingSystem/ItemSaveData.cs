using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ItemSlotSaveData
{
    public int id;

    public ItemSlotSaveData(int id)
    {
        this.id = id;
    }
}

[Serializable]
public class ItemContainerSaveData
{
    public ItemSlotSaveData[] savedSlots;

    public ItemContainerSaveData(int numItems)
    {
        savedSlots = new ItemSlotSaveData[numItems];
    }

}

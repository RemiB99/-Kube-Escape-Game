using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    public GameObject item;
    public int id;
    public string type;
    public string description;
    public string use;
    public bool empty;
    public Sprite icon;
    public Transform slotIconGO;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        UseItem();
    }
    void Awake()
    {
        slotIconGO = transform.GetChild(0);
    }
    public void UpdateSlot()
    {
        slotIconGO.GetComponent<Image>().sprite = icon;
        
    }

    public void UseItem()
    {
        item.GetComponent<Item>().ItemUsage();
    }
}

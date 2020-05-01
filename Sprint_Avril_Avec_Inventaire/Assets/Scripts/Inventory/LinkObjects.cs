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
    private GameObject Description;
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
                        obj = itemManager.transform.GetChild(i).gameObject;  
                        SlotHolder = GameObject.Find("Slot Holder");
                        Description = GameObject.Find("Description");

                        if (itemManager.transform.GetChild(i).gameObject.GetComponent<Item>().id == id && itemManager.transform.GetChild(i).gameObject.GetComponent<Item>().equipped)
                        {
                            
                            
                            destroyImage();
                            /*for (int j = 0; j < SlotHolder.transform.childCount; j++)
                            {
                                Slot = SlotHolder.transform.GetChild(j).gameObject;
                                panel = Slot.transform.GetChild(0).gameObject;

                                GameObject Text = Description.transform.GetChild(1).gameObject;
                                Text.GetComponent<Text>().text = null;
                                GameObject Image = GameObject.Find("Active Object");
                                Image.GetComponent<Image>().sprite = null;
                                
                                if (obj.GetComponent<Item>().icon == panel.GetComponent<Image>().sprite)
                                {
                                    Destroy(Slot);
                                }
                                Image.GetComponent<Image>().color = new Color(95,84,80, 255);
                            }*/
                            
                            activeAction();
                            Destroy(obj);          
                            
                        }
                        else if (itemManager.transform.GetChild(i).gameObject.GetComponent<Item>().equipped){
                            
                            //son a mettre buzz que colin cherche
                            
                            
                            if(obj.name=="BookInvisibleMain" && this.name=="ActiveFeu"){
                                
                                GameObject anim = GameObject.Find("FeuRouge");
                                anim.GetComponent<AudioSource>().Play();
                                ParticleSystem test = anim.GetComponent<ParticleSystem>();
                                test.Play();
                                destroyImage();
                                
                                Destroy(obj);
                            }

                            if(obj.name=="BookVieMain" && this.name=="ActiveFeu"){
                                
                                GameObject anim = GameObject.Find("FeuRouge2");
                                anim.GetComponent<AudioSource>().Play();
                                ParticleSystem test = anim.GetComponent<ParticleSystem>();
                                test.Play();
                                destroyImage();
                                Destroy(obj);
                            }


                        }
                    }
                }
            }
        }
    }

    public void activeAction()
    {
        if (obj.name == "CubeInventaire(1)")
        {
            Debug.Log("YEEEEES ça marche !!!");
        }

        if (obj.name == "BookDodoMain")
        {
            GameObject anim = GameObject.Find("FeuVert");
            ParticleSystem test = anim.GetComponent<ParticleSystem>();
            test.Play();

            GameObject potionJaune = GameObject.Find("PotionJaune");
            Animator potion = potionJaune.GetComponent<Animator>();
            potion.SetTrigger("PotionJaune");
            
            this.GetComponent<AudioSource>().Play();
            
            GameObject tab = GameObject.Find("TextPotion");
            tab.SetActive(false);
        }

        if (obj.name == "PotionRougeMain")
        {
            Animator blueOrange = this.GetComponent<Animator>();
            this.GetComponent<AudioSource>().Play();
            blueOrange.SetTrigger("PotionBleue1");
            id = 6;    
        }

        if (obj.name == "PotionJauneMain")
        {
            Animator OrangeWhite = this.GetComponent<Animator>();
            this.GetComponent<AudioSource>().Play();
            OrangeWhite.SetTrigger("PotionBleue2");
            Invoke("waitPotion",2);
            
        }

        if (obj.name == "PotionBleueMain")
        {
            Animator Bramble = this.GetComponent<Animator>();
            this.GetComponent<AudioSource>().Play();
            Bramble.SetTrigger("Bramble");
            Invoke("destroyBramble",2);
            
        }
    }

    public void destroyImage(){

        for (int j = 0; j < SlotHolder.transform.childCount; j++)
        {
            Slot = SlotHolder.transform.GetChild(j).gameObject;
            panel = Slot.transform.GetChild(0).gameObject;

            GameObject Text = Description.transform.GetChild(1).gameObject;
            Text.GetComponent<Text>().text = null;
            GameObject Image = GameObject.Find("Active Object");
            Image.GetComponent<Image>().sprite = null;
                                
            if (obj.GetComponent<Item>().icon == panel.GetComponent<Image>().sprite)
            {
                Slot.GetComponent<Slot>().empty = true;
                panel.GetComponent<Image>().sprite = null;
                Slot.SetActive(false);
                //Destroy(Slot);
            }
            Image.GetComponent<Image>().color = new Color(95,84,80, 255);
        }
    }

    public void waitPotion(){
        this.tag = "Item";
    }

    public void destroyBramble(){
        GameObject bramble = GameObject.Find("StrangeFlower");
        bramble.SetActive(false);
    }
}

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
    private GameObject Use;
    private GameObject Slot;
    private GameObject panel;
    private GameObject objetCliqué;

    private string[] textesBouche = new string[20];
    private GameObject bouche;


    void Start(){

        textesBouche[1] = "Bon sang ! Un livre si précieux ! Comment osez-vous !";
        textesBouche[2] = "Quel  acte  irresponsable ! Réfléchissez un peu...";
        textesBouche[3] = "Très bon choix... Espérons que cela continue !";
        textesBouche[4] = "Félicitations ! Utilisez la à bon escient, les conséquences pourraient être fatales";

        bouche = GameObject.Find("Bouches");

    }
    // Update is called once per frame
    void Update()
    {
        if ((Input.GetMouseButtonDown(0)))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if ((Physics.Raycast(ray, out hit)))
            {
                objetCliqué = hit.transform.gameObject;
                if (hit.transform.gameObject.tag =="LinkObject" )
                {
                    itemManager = GameObject.FindWithTag("ItemManager");
                    int allItems = itemManager.transform.childCount;
                    for (int i = 0; i < allItems; i++)
                    {
                        
                        
                        obj = itemManager.transform.GetChild(i).gameObject;  
                        SlotHolder = GameObject.Find("Slot Holder");
                        Description = GameObject.Find("Description");
                        Use = GameObject.Find("Use");



                        if (itemManager.transform.GetChild(i).gameObject.GetComponent<Item>().id == hit.transform.gameObject.GetComponent<LinkObjects>().id && itemManager.transform.GetChild(i).gameObject.GetComponent<Item>().equipped)
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
                            
                            
                            
                            
                            if(obj.name=="BookInvisibleMain" && objetCliqué.name=="ActiveFeu"){
                                
                                GameObject anim = GameObject.Find("FeuRouge");
                                anim.GetComponent<AudioSource>().Play();
                                ParticleSystem test = anim.GetComponent<ParticleSystem>();
                                test.Play();

                                bouche.GetComponent<Bouches>().animBoucheFache();
                                bouche.GetComponent<Bouches>().setText(textesBouche[1]);

                                destroyImage();
                                Destroy(obj);
                            }

                            if(obj.name=="BookVieMain" && objetCliqué.name=="ActiveFeu"){
                                
                                GameObject anim = GameObject.Find("FeuRouge2");
                                anim.GetComponent<AudioSource>().Play();
                                ParticleSystem test = anim.GetComponent<ParticleSystem>();
                                test.Play();

                                bouche.GetComponent<Bouches>().animBoucheFache();
                                bouche.GetComponent<Bouches>().setText(textesBouche[2]);
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
            
            objetCliqué.GetComponent<AudioSource>().Play();
            
            GameObject tab = GameObject.Find("TextPotion");
            if(tab!=null)
                tab.SetActive(false);

            bouche.GetComponent<Bouches>().animBoucheContente();
            bouche.GetComponent<Bouches>().setText(textesBouche[3]);
        }

        if (obj.name == "PotionRougeMain")
        {
            Animator blueOrange = objetCliqué.GetComponent<Animator>();
            objetCliqué.GetComponent<AudioSource>().Play();
            blueOrange.SetTrigger("PotionBleue1");
            objetCliqué.GetComponent<LinkObjects>().id = 6;    
        }

        if (obj.name == "PotionJauneMain")
        {
            Animator OrangeWhite = objetCliqué.GetComponent<Animator>();
            objetCliqué.GetComponent<AudioSource>().Play();
            OrangeWhite.SetTrigger("PotionBleue2");

            bouche.GetComponent<Bouches>().animBoucheContente();
            bouche.GetComponent<Bouches>().setText(textesBouche[4]);
            Invoke("waitPotion",2);
            
        }

        if (obj.name == "PotionBleueMain")
        {

            Animator Bramble = objetCliqué.GetComponent<Animator>();
            objetCliqué.GetComponent<AudioSource>().Play();
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

            GameObject use = Use.transform.GetChild(1).gameObject;
            use.GetComponent<Text>().text = null;

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
        objetCliqué.tag = "Item";
        objetCliqué.GetComponent<Outline>().enabled=true;
    }

    public void destroyBramble(){
        GameObject bramble = GameObject.Find("StrangeFlower");
        if(bramble!=null)
            bramble.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinkObjects : MonoBehaviour
{
    private GameObject itemManager;
    public int id;
    private GameObject listeObjetsInventaires;
    private GameObject objMain;
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

        listeObjetsInventaires = GameObject.Find("ObjetsInventaire");


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
                if (hit.transform.gameObject.tag =="LinkObject")
                {
                    itemManager = GameObject.FindWithTag("ItemManager");
                    int allItems = itemManager.transform.childCount;
                    for (int i = 0; i < allItems; i++)
                    {
                        
                        
                        objMain = itemManager.transform.GetChild(i).gameObject;  
                        SlotHolder = GameObject.Find("Slot Holder");
                        Description = GameObject.Find("Description");
                        Use = GameObject.Find("Use");

                        
                        if (objMain.GetComponent<Item>().id == objetCliqué.GetComponent<LinkObjects>().id 
                            && objMain.GetComponent<Item>().equipped
                            )
                        {
                            startAction();
                        }

                        else if(objetCliqué.GetComponent<LinkObjects>().id == 56 && testObjetMainLivresCycle() && objMain.GetComponent<Item>().equipped)
                        {
                            startAction();
                        }
                    }
                }
            }
        }
    }

    public void activeAction()
    {
        if (objMain.name == "CubeInventaire(1)")
        {
            Debug.Log("YEEEEES ça marche !!!");
        }

        if (objMain.name == "BookDodoMain")
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

        if (objMain.name == "PotionRougeMain")
        {
            Animator blueOrange = objetCliqué.GetComponent<Animator>();
            objetCliqué.GetComponent<AudioSource>().Play();
            blueOrange.SetTrigger("PotionBleue1");
            //objetCliqué.GetComponent<LinkObjects>().id = 2;    
        }

        if (objMain.name == "PotionJauneMain")
        {
            Animator OrangeWhite = objetCliqué.GetComponent<Animator>();
            objetCliqué.GetComponent<AudioSource>().Play();
            OrangeWhite.SetTrigger("PotionBleue2");

            bouche.GetComponent<Bouches>().animBoucheContente();
            bouche.GetComponent<Bouches>().setText(textesBouche[4]);
            Invoke("waitPotion",2);
            
        }

        if (objMain.name == "PotionBleueMain")
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

            if (objMain.GetComponent<Item>().icon == panel.GetComponent<Image>().sprite)
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

    public bool testObjetMainLivresCycle(){
        return objMain.GetComponent<Item>().id == 6 
            || objMain.GetComponent<Item>().id == 7
            || objMain.GetComponent<Item>().id == 8
            || objMain.GetComponent<Item>().id == 9
            || objMain.GetComponent<Item>().id == 10;
    }

    public void startAction(){
        // detruit l'objet dans l'inventaire, met a false celui de la main et a true celui recuperable
        destroyImage();
        activeAction();
                            
        objMain.GetComponent<Item>().equipped = false;
        objMain.GetComponent<Item>().occupied = false;
                            
                            
        int allItems2 = listeObjetsInventaires.transform.childCount;
        for (int j = 0; j < allItems2; j++)
        {
            GameObject obj2 = listeObjetsInventaires.transform.GetChild(j).gameObject;
            if(obj2.GetComponent<Item>().id == objMain.GetComponent<Item>().id) {
                obj2.SetActive(true);
            }
        }
        objMain.SetActive(false);
    }
}

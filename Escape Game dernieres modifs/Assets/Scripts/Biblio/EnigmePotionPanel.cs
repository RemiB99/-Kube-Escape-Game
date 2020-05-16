using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class EnigmePotionPanel : MonoBehaviour
{
    public GameObject[] potions = new GameObject[7];
    private bool[] potionsBool = new bool[7];
    private bool[] ordrePotions = new bool[7];
    public GameObject textCourant;
    public GameObject recipient;
    private bool hasPlayed = false;
    private bool hasTalked = false;

    private string[] textesBouche = new string[20];
    private GameObject bouche;
    // Start is called before the first frame update
    void Start()
    {
        bouche = GameObject.Find("Bouches");
    }

    // Update is called once per frame
    void Update()
    {   
        //Debug.Log(GameObject.Find("Inventory").transform.localScale == new Vector3(0, 0, 0));
        if(!hasPlayed){
            
            StartCoroutine(explicationsBouches());
            hasPlayed = true;
        }
        if(potionFinie() && !hasTalked){
            StartCoroutine(finPotion());
            hasTalked = true;

        }
        
    }

    public void changeText(){
        
        GameObject buttonClicked = EventSystem.current.currentSelectedGameObject;
        textCourant.GetComponent<TextMeshProUGUI>().text = buttonClicked.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text;
        
        //recipient.transform.GetChild(0).GetComponent<Image>().color = new Color32(255,255,255,255);

        foreach(var pot in potions){
            if(pot == buttonClicked)
                potionsBool[System.Array.IndexOf(potions,pot)] = true;
            else
                potionsBool[System.Array.IndexOf(potions,pot)] = false;
        }
    }

    public void colorPotion(){
        GameObject buttonClicked = EventSystem.current.currentSelectedGameObject;
        foreach(var boolPot in potionsBool){
            if(boolPot){
                GameObject potionCourante = potions[System.Array.IndexOf(potionsBool,boolPot)];
                buttonClicked.transform.GetChild(0).GetComponent<Image>().color = potionCourante.GetComponent<Button>().colors.pressedColor;
                potionCourante.GetComponent<Image>().sprite = potionCourante.transform.GetChild(1).gameObject.GetComponent<Image>().sprite;
                potionCourante.GetComponent<Button>().enabled = false;
            }

        }
    }

    public void testOrdrePotion(){
        int positionPotClick = firstTrueArray(potionsBool);
        changeTabOrdrePotions(positionPotClick);
        if(ordrePotions[positionPotClick]){
            colorPotion();
            /*bouche.GetComponent<Bouches>().animBoucheContente();
            bouche.GetComponent<Bouches>().setText("Super ! Ca fonctionne ! Continuez comme ça !");*/
            majTextBouche(positionPotClick);
        }
        else{
            
            
            bouche.GetComponent<Bouches>().animBoucheFache();
            bouche.GetComponent<Bouches>().setText("Non Non Non ! Ce n'est pas l'ordre que j'ai indiqué! Ecoutez-moi !");
        }
        //System.Array.FindIndex(potionsBool,test);
        //return true;

        
    }

    public int firstTrueArray(bool[] arrayBool){
        for(int i=0;i<arrayBool.Length;i++){
            if (arrayBool[i])
                return i;
        }
        return -1;
    }

    public void changeTabOrdrePotions(int position){
        bool bonnePotion = true;
        for(int i=0;i<position;i++){
            if(!ordrePotions[i])
                bonnePotion = false;
        }
        if(bonnePotion)
            ordrePotions[position] = true;
    }

    IEnumerator explicationsBouches(){
        
        bouche.GetComponent<Bouches>().animBoucheReflechi();
        bouche.GetComponent<Bouches>().setText("Bon, je suis sûr qu'on va épater ce client. "
                                                +" Je sais exactement ce qu'il faut faire !");
        yield return new WaitForSeconds(5);
        bouche.GetComponent<Bouches>().animBoucheReflechi();
        bouche.GetComponent<Bouches>().setText("Je serai votre chef, mettons un maximum de "
                                                +" concepts dans ce mélange !");
        yield return new WaitForSeconds(5);
        bouche.GetComponent<Bouches>().animBoucheReflechi();
        bouche.GetComponent<Bouches>().setText("Alors, il faut d'abord utiliser cette potion violette, "
                                                +" ca va être génial !");
        yield return new WaitForSeconds(5);
    }

    public bool potionFinie(){
        bool finie = true;
        foreach(var util in ordrePotions){
            if(!util)
                finie = false;
        }
        return finie;
    }
    
    IEnumerator finPotion(){

        bouche.GetComponent<Bouches>().animBoucheContente();
        bouche.GetComponent<Bouches>().setText("Ca y est ! C'est parfait ! Tout y est !");
        yield return new WaitForSeconds(2);
        bouche.GetComponent<Bouches>().animBoucheContente();
        bouche.GetComponent<Bouches>().setText("Vite ! Regardez votre inventaire ! Il va être ravi !");
        yield return new WaitForSeconds(3);
        GameObject.Find("PanelRecipient").GetComponent<Item>().close();

        GameObject recip = GameObject.Find("RecipientRempli");
        GameObject canv = GameObject.Find("Canvas");
        Item itemRecip = recip.GetComponent<Item>();
        canv.GetComponent<Inventory>().AddItem(recip,itemRecip.id,itemRecip.type,itemRecip.description,itemRecip.icon,itemRecip.use);
        destroyPotions();
        
    }

    public void majTextBouche(int posPotion){
        switch (posPotion)
        {
            case 0:
                bouche.GetComponent<Bouches>().animBoucheContente();
                bouche.GetComponent<Bouches>().setText("Ca commence bien ! Continuez avec cette potion verte...");
                break;
            case 1:
                bouche.GetComponent<Bouches>().animBoucheContente();
                bouche.GetComponent<Bouches>().setText("Parfait ! Maintenant c'est au tour de la bleue");
                break;
            case 2:
                bouche.GetComponent<Bouches>().animBoucheContente();
                bouche.GetComponent<Bouches>().setText("Ca se construit ! C'est au tour de cette autre potion violette");
                break;
            case 3:
                bouche.GetComponent<Bouches>().animBoucheContente();
                bouche.GetComponent<Bouches>().setText("Il faut maintenant un peu de cette potion jaune...");
                break;
            case 4:
                bouche.GetComponent<Bouches>().animBoucheContente();
                bouche.GetComponent<Bouches>().setText("Génial ! C'est bientôt fini, la potion rouge maintenant, c'est la plus importante");
                break;
            case 5:
                bouche.GetComponent<Bouches>().animBoucheContente();
                bouche.GetComponent<Bouches>().setText("Plus qu'une ! Vous avez sûrement deviné laquelle...");
                break;
            default:
                bouche.GetComponent<Bouches>().animBoucheContente();
                bouche.GetComponent<Bouches>().setText("");
                break;
        }
    }

        public void destroyPotions(){
            GameObject itemManag = GameObject.Find("ItemManager");
            GameObject objInv = GameObject.Find("ObjetsInventaire");
            int[] idsPotions = new int[8];
            idsPotions[0]=1;idsPotions[1]=2;idsPotions[2]=3;idsPotions[3]=4;idsPotions[4]=5;idsPotions[5]=17;idsPotions[6]=18;idsPotions[7]=16;
            for (int i = 0; i < itemManag.transform.childCount; i++)
            {
                GameObject objCourant = itemManag.transform.GetChild(i).gameObject;
                if (System.Array.IndexOf(idsPotions,objCourant.GetComponent<Item>().id) != -1){
                    Destroy(objCourant);
                }
            }
            for (int j = 0; j < objInv.transform.childCount; j++)
            {
                GameObject objCourant = objInv.transform.GetChild(j).gameObject;
                if (System.Array.IndexOf(idsPotions,objCourant.GetComponent<Item>().id) != -1){
                    Destroy(objCourant);
                }
            }    
            GameObject SlotHolder = GameObject.Find("Slot Holder");
            for (int j = 0; j < SlotHolder.transform.childCount; j++)
            {
                GameObject Slot = SlotHolder.transform.GetChild(j).gameObject;
                GameObject panel = Slot.transform.GetChild(0).gameObject;
                if (System.Array.IndexOf(idsPotions,Slot.GetComponent<Slot>().id) != -1){
                    Slot.GetComponent<Slot>().empty = true;
                    panel.GetComponent<Image>().sprite = null;
                    Slot.SetActive(false);
                }
            }
        }
}

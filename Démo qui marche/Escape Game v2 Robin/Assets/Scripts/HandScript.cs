using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (/*(Input.touchCount > 0) || (*/Input.GetMouseButtonDown(0))
        {
            
            //Touch touch = Input.GetTouch(0);
            //Ray rayTouch = Camera.main.ScreenPointToRay(touch.position);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;


            if ((Physics.Raycast(ray, out hit))) /* || (Physics.Raycast(rayTouch, out hit)))*/
            {
                if (hit.transform.name == "Main")
                {
                    //GameObject Main = hit.transform.gameObject;
                    //Main.GetComponent<Animator>().Play("AnimationHand");

                    //Main.GetComponent<Animation>().Play("AnimationHand");

                    anim.SetTrigger("Active");
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    public Text tCount;
    public ConstantForce cf;
    public GameObject go;
    
    

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Cube Test")
                {
                    //tCount.text = Input.touchCount.ToString();
                    Debug.Log("cube touched");
                    hit.transform.Translate(Input.GetTouch(0).deltaPosition * Time.deltaTime * 1f);
                }
                else if (hit.transform.name == "Capsule")
                {
                    //tCount.text = Input.touchCount.ToString();
                    hit.transform.Translate(Input.GetTouch(0).deltaPosition * Time.deltaTime * 1f);
                    /*go = hit.transform.gameObject;
                    go.AddComponent<ConstantForce>();
                    go.GetComponent<ConstantForce> = new Vector3(0.0f, 0.0f, 0.0f);
                    hit.rigidbody.gameObject.GetComponent<Rigidbody>().useGravity= false;*/
                    Debug.Log("Capsule touched");
                }
            }
        }


        /*if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            tCount.text = Input.touchCount.ToString();

            //Debug.Log("nb doigt sur l'écran = " + Input.touchCount);
            //Debug.Log(Input.GetTouch(1).deltaPosition);
            transform.Translate(Input.GetTouch(0).deltaPosition * Time.deltaTime * 3f);

            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log("Began " + touch.position);
            }
            if (touch.phase == TouchPhase.Stationary)
            {
                Debug.Log("Stationary " + touch.position);
            }
            if (touch.phase == TouchPhase.Moved)
            {
                Debug.Log("Moved " + touch.position);
            }
            if (touch.phase == TouchPhase.Ended)
            {
                Debug.Log("Ended " + touch.position);
            }
        }*/
    }
}

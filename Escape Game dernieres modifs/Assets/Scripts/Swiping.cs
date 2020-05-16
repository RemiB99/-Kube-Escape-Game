using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swiping : MonoBehaviour
{

    public Camera cam;
    private float rotX = 0f;
    private float rotY = 0f;
    private Vector3 origRotation;
    private Touch iniTouch = new Touch();
    public float rotSpeed = 0.5f;
    public float direction = -1f;
    GameObject charecter;

    // Start is called before the first frame update
    void Start()
    {
        origRotation = cam.transform.eulerAngles;
        rotX = origRotation.x;
        rotY = origRotation.y;
        //charecter = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 2)
        {
            foreach (Touch touch in Input.touches) //ou pour juste un seul doigt => Touch touch = Input.GetTouch(0); 
            {
                if (touch.phase == TouchPhase.Began)
                {
                    iniTouch = touch;
                }
                if (touch.phase == TouchPhase.Moved)                //swaping
                {
                    float deltaX = iniTouch.position.x - touch.position.x;
                    float deltaY = iniTouch.position.y - touch.position.y;
                    rotX -= deltaY * Time.deltaTime * rotSpeed * direction;
                    rotY += deltaX * Time.deltaTime * rotSpeed * direction;
                    rotX = Mathf.Clamp(rotX, -45f, 45f);
                    cam.transform.eulerAngles = new Vector3(rotX, rotY, 0f);
                    //charecter.transform.eulerAngles = new Vector3(rotX, rotY, 0f);
                }
                if (touch.phase == TouchPhase.Ended)
                {
                    iniTouch = new Touch();
                }
            }
        }
        

    }
}

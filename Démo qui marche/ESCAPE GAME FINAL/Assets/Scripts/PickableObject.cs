using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    public Transform player;
    public Transform playerCam;
    public float throwForce = 10;
    private bool hasPlayer = false;
    private bool beingCarried = false;
    private bool touched = false;

    
    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(gameObject.transform.position, player.position);

        if(distance <= 1.9f)
        {
            hasPlayer = true;
        }
        else
        {
            hasPlayer = false;
        }

        if(hasPlayer && Input.touchCount == 5)
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = playerCam;
            beingCarried = true;
        }

        if (beingCarried)
        {
            if (touched)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                touched = false;
            }

            if(Input.touchCount == 4)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForce);
            }

            if(Input.touchCount == 3)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
            }
        }
    }
    // Détection de contact grace au collider is trigger
    void OnTriggerEnter()
    {
        if (beingCarried)
        {
            touched = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickControler : MonoBehaviour
{
    private Joystick joystick;
    public float speed = 10f;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        joystick = FindObjectOfType<Joystick>();
        var rigibody = GetComponent<Rigidbody>();
        if (rigibody != null && joystick != null)
        {
            rigibody.velocity = new Vector3(0,
                                        rigibody.velocity.y,
                                        joystick.Vertical * 5f);

            rigibody.velocity = transform.TransformDirection(rigibody.velocity);
            transform.Rotate(Vector3.up * joystick.Horizontal * Time.deltaTime * 10f * speed);
        }
        
        
        
    }
   
   /* void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player(Clone)")
        {
            Debug.Log("Collisin");
            
        }
    }*/
}

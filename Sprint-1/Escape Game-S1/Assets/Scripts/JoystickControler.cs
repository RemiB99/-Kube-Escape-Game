using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickControler : MonoBehaviour
{
    private Joystick joystick;
    public float speed = 10f;
    

    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        var rigibody = GetComponent<Rigidbody>();

        rigibody.velocity = new Vector3(0,
                                        rigibody.velocity.y,
                                        joystick.Vertical * 5f);

        rigibody.velocity = transform.TransformDirection(rigibody.velocity);
        transform.Rotate(Vector3.up * joystick.Horizontal * Time.deltaTime * 10f * speed);
        

        
    }
}

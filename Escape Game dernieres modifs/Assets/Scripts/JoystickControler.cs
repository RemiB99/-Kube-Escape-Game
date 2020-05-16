using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Rémi
public class JoystickControler : MonoBehaviour
{
    private Joystick joystick;
    public float speed = 10f;
    private string sceneName;
    private float velocity;
    

    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        sceneName = SceneManager.GetActiveScene().name;
        
        if (sceneName == "PirateTavern")
        {
            velocity = 2.5f;
        }
        else
        {
            velocity = 5f;
        }

        var rigibody = GetComponent<Rigidbody>();

        rigibody.velocity = new Vector3(0,
                                        rigibody.velocity.y,
                                        joystick.Vertical * velocity);

        rigibody.velocity = transform.TransformDirection(rigibody.velocity);
        transform.Rotate(Vector3.up * joystick.Horizontal * Time.deltaTime * 10f * speed);
        

        
    }
}

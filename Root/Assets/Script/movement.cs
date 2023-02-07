using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class movement : MonoBehaviour
{
    public float movespeed = 1;
    public bool cursorLock = false;
    [SerializeField] public Animator anim;
    [SerializeField] TextMeshProUGUI currentSpeed;
    [SerializeField] TextMeshProUGUI speedAlert;
    [SerializeField] MainMenu menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (menu.GameStarted)
        {
            currentSpeed.text = "Current Spinning Speed : " + anim.speed.ToString(".00");
            anim.speed += Input.GetAxis("Mouse ScrollWheel");
            speedAlert.gameObject.SetActive(anim.speed >= 3);
        }

        /*
        if (Input.GetKey(KeyCode.W))
        {
           //this.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, movespeed));
        }
        if (Input.GetKey(KeyCode.A))
        {
            //this.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(-movespeed/4*3, 0, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            //this.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, -movespeed/4*3));
        }
        if (Input.GetKey(KeyCode.D))
        {
            //this.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(movespeed/4*3, 0, 0));
        }
        
        */
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            cursorLock = !cursorLock;
        }
        //if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        //{
        //    this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        //}

        this.transform.rotation = Quaternion.Euler(0, this.transform.rotation.eulerAngles.y + Input.GetAxis("Mouse X"), 0);


        Cursor.lockState = cursorLock?CursorLockMode.Locked: CursorLockMode.None;
    }
}

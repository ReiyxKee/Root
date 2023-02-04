using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float movespeed = 1;
    public bool cursorLock = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, movespeed));
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(-movespeed/4*3, 0, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, -movespeed/4*3));
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(movespeed/4*3, 0, 0));
        }

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

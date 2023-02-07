using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BindPos : MonoBehaviour
{
    [SerializeField] GameObject Frame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Frame.transform.position;
    }
}

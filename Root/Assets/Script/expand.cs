using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class expand : MonoBehaviour
{
    float timer = 0;
    public float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timer += 0.0025f * Time.deltaTime;

        this.transform.localScale = new Vector3(this.transform.localScale.x + timer * 0.25f *timer, this.transform.localScale.y, this.transform.localScale.z);
    }
}

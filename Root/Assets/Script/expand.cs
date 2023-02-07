using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class expand : MonoBehaviour
{
    public bool hardmode = false;
    float timer = 0;
    public float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        hardmode = false;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.fixedDeltaTime;

        this.transform.localScale = new Vector3(this.transform.localScale.x + (hardmode?(0.0075f*Time.deltaTime): (0.000125f * time)), this.transform.localScale.y, this.transform.localScale.z);
    }
}

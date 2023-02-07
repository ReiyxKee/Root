using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tYPEWRITTER : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tmp;
    string register = "mission: code 69 spider; \nreach the root and execute the command; \nKEEP IT ROLLING; \n/START to execute; ";
    int i = 0;
    float timer = 0;
    float speed = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (i <= register.Length - 1)
        {
            timer += Time.deltaTime;

            if (timer >= speed)
            {
                timer = 0;
                tmp.text += register[i];
                i++;
            }
        }


    }
}

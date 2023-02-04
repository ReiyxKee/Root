using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class terminal : MonoBehaviour
{
    bool command = false;
    bool resolved = false;
    [SerializeField] TMP_InputField inputcode;
    string Command = "KILL 1";
    [SerializeField] TextMeshProUGUI hint;
    [SerializeField] GameObject RedAlert;
    [SerializeField] expand Expand;
    [SerializeField] TMP_InputField names;
    [SerializeField] OnlineRankingManager on9;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (command &&!resolved)
        {
            hint.gameObject.SetActive(true);
            hint.text = Command;
            inputcode.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Return))
            {
                Resolve();
            }
        }
        else if(command && resolved && Input.GetKeyDown(KeyCode.Return))
        {
            on9.Send(names.text);
        }
    }

    void Resolve()
    {
        Debug.Log(inputcode.text);
        Debug.Log(Command);
        if (inputcode.text == Command)
        {
            RedAlert.SetActive(false);
            PlayerPrefs.SetFloat("Time" , Expand.time);
            names.gameObject.SetActive(true);
            resolved = !resolved;
            Application.Quit();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            command = !command;
        }
    }
}

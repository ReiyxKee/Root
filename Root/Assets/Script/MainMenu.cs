using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject Minimap;
    [SerializeField] GameObject RedAlert;
    [SerializeField] Camera Main;
    [SerializeField] Camera Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            mainMenu.SetActive(false);
            RedAlert.SetActive(true);
            Minimap.SetActive(true);
            Player.targetDisplay = 0;
            Main.targetDisplay = 1;
            
        }
    }
}

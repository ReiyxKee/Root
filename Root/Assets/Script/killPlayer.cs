using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class killPlayer : MonoBehaviour
{
    [SerializeField] GameObject GG;
    [SerializeField] GameObject minimap;
    bool GameOver = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver)
        {
            if (!PlayerPrefs.HasKey("Death"))
            {
                PlayerPrefs.SetInt("Death", 0);
            }
            PlayerPrefs.SetInt("Death", PlayerPrefs.GetInt("Death") + 1);
            GG.SetActive(true);
            minimap.SetActive(false);
            GG.GetComponent<Image>().color = new Color(GG.GetComponent<Image>().color.r, GG.GetComponent<Image>().color.g, GG.GetComponent<Image>().color.b, GG.GetComponent<Image>().color.a + 5 * Time.deltaTime);
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //GameOver
            GameOver = !GameOver;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(GameObject))]
public class OnlineRankingManager : MonoBehaviour
{
    //Variables
    [SerializeField] private int leaderboardAmount = 20;
    [SerializeField] private GameObject rankingPrefab;
    
    //dreamIO 
    private string secretLink = "http://dreamlo.com/lb/FjIRgeetbUK2yDXo0tvqCgRmBDxXsUHEiMxCbFhjHyMw";
    private string privateCode = "FjIRgeetbUK2yDXo0tvqCgRmBDxXsUHEiMxCbFhjHyMw";
    private string publicCode = "63dd375a8f40bb08f4c195e9";

    //userName
    private string userName = "";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Send(string Username)
    {
        string uri = "http://dreamlo.com/lb/" + privateCode + "/add/" + Username + "/" + (PlayerPrefs.HasKey("Death") ? PlayerPrefs.GetInt("Death").ToString() : "0");
        StartCoroutine(WebRequestHandler(uri));
    }

    IEnumerator WebRequestHandler(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
        }
    }

}

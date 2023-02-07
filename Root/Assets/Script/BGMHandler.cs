using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMHandler : MonoBehaviour
{
    [SerializeField] MainMenu menu;
    [SerializeField] movement move;
    [SerializeField] AudioSource MenuBGM;
    [SerializeField] AudioSource Ingame;
    [SerializeField] AudioSource Ingame_Rush;
    public bool muted;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("mute"))
        {
            muted = PlayerPrefs.GetInt("mute") == 1 ? true : false;
        }
        else
        {
            muted = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!muted) { 
        switch (menu.GameStarted)
        {
            case false:
                if (!MenuBGM.isPlaying) MenuBGM.Play();
                if (Ingame.isPlaying) Ingame.Pause();
                if (Ingame_Rush.isPlaying) Ingame_Rush.Pause();
                MenuBGM.volume += 1 * Time.deltaTime;
                break;
            case true:
                if (!Ingame.isPlaying) Ingame.Play();
                if (!Ingame_Rush.isPlaying) Ingame_Rush.Play();
                MenuBGM.volume -= 1 * Time.deltaTime;
                Ingame.volume += (move.anim.speed >= 3) ? -1 * Time.deltaTime : 1 * Time.deltaTime;
                Ingame_Rush.volume += (move.anim.speed >= 3) ? 1 * Time.deltaTime : -1 * Time.deltaTime;
                if (!MenuBGM.isPlaying) MenuBGM.Stop();
                break;
        }
    }
        else 
        {
            MenuBGM.Stop();
            Ingame.Stop();
            Ingame_Rush.Stop();
        }
    }
}

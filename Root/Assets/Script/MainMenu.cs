using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject Minimap;
    [SerializeField] GameObject RedAlert;
    [SerializeField] GameObject sPEED;
    [SerializeField] Camera Main;
    [SerializeField] Camera Player;
    [SerializeField] movement Playermove;
    [SerializeField] TMP_InputField input;
    [SerializeField] TextMeshProUGUI log;
    [SerializeField] Animator roll;
    [SerializeField] dreamloLeaderBoard lb;
    [SerializeField] expand terminals;
    [SerializeField] BGMHandler bgm;
    bool inCommand = false;
    bool CommandUsername = false;
    public bool GameStarted = false;
    bool exitCountdown = false;
    float exitTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("username"))
        {
            PlayerPrefs.SetString("username", ("RANDOM_" + Random.Range(0, 9).ToString() + Random.Range(0, 9).ToString() + Random.Range(0, 9).ToString() + Random.Range(0, 9).ToString()));
            addLog("WELCOME TO THE MISSION, " + PlayerPrefs.GetString("username") + "\n");
        }
        else
        {
            addLog("WELCOME BACK, " + PlayerPrefs.GetString("username")+ "\n");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (exitCountdown)
        {
            exitTimer += Time.deltaTime;

            if (exitTimer >= 5)
            {
                Application.Quit();
            }
        }
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {

            addLog(input.text + '\n');

            
            if (!inCommand)
            {
                string[] splitCommand = input.text.Split(" ");
                switch (splitCommand[0].ToUpper())
                {
                    case "/START": StartGame(); break;
                    case "/HELP": addLog("\n\n/START : TO EXECUTE MISSION" +
                        "\n/USERNAME : TO CHANGE YOUR NAME ON LEADERBOARD" +
                        "\n/PROFILE : VIEW YOUR PROFILE OF THE GAME" +
                        "\n/RESET : RESET PROFILE" +
                        "\n/LEADERBOARD : TO SHOW FASTEST EXECUTION" +
                        "\n/HOWTOPLAY : FOR TUTORIAL" +
                        "\n/CLS : CLEARLOG" +
                        "\n/HARDMODE : TOO EASY?" +
                        "\n/MUTE : NEED NO BGM" +
                        "\n/CREDITS" +
                        "\n/EXIT : TO ABORT MISSION"); break;


                    case "/LEADERBOARD": Leaderboard(); break;

                    case "/USERNAME":
                        if (splitCommand.Length > 1)
                        {
                            PlayerPrefs.SetString("username", splitCommand[1]);
                            addLog("Username Set To " + PlayerPrefs.GetString("username"));
                        }
                        else
                        {
                            addLog("Input your name and enter:");
                            inCommand = true;
                            CommandUsername = true;
                        }
                        break;

                    case "/RESET": PlayerPrefs.DeleteAll(); addLog("PROFILE RESET COMPLETE"); break;

                    case "/CLS": log.text = ""; break;

                    case "/HOWTOPLAY": Tutorial(); break;

                    case "/PROFILE": if (!PlayerPrefs.HasKey("username"))
                        {
                            PlayerPrefs.SetString("username", ("RANDOM_" + (Random.Range(0, 9)).ToString() + (Random.Range(0, 9).ToString()) + (Random.Range(0, 9).ToString()) + (Random.Range(0, 9).ToString())));
                        }

                        addLog("username: " + PlayerPrefs.GetString("username") + "\nFailed attempts : " + PlayerPrefs.GetInt("Death") + "\nFastest Clear Time (s): " + (PlayerPrefs.GetFloat("Time") == 0 ? "N/A" : PlayerPrefs.GetFloat("Time"))); break;

                    case "/HARDMODE": terminals.hardmode = !terminals.hardmode; addLog(terminals.hardmode ? "Hard mode enabled" : "Hard mode disabled"); break;

                    case "/MUTE": bgm.muted = !bgm.muted;
                        addLog(bgm.muted ? "BGM MUTED" : "BGM UNMUTED");
                        PlayerPrefs.SetInt("mute", bgm.muted? 1:0);
                        break;

                    case "/CREDITS":
                        addLog("\nGGJ 2023" +
                        "\nGAME BY REIYX" +
                            "\n\nTOOLS:" +
                            "\n UNITY 2021.3.11F1" +
                            "\n BLENDER" +
                            "\n ADOBE PHOTOSHOP" +
                            "\n MPC BEATS" +
                            "\n GITHUB");
                        break;

                    case "/EXIT": exitCountdown = true;
                        addLog("MISSION ABORTED\nAPPLICATION WILL EXIT IN 5S\nTHANK YOU FOR PLAYING");
                        break;

                    default: addLog("ERROR(): COMMAND NOT FOUND;\nEXECUTE.COMMAND(''" + input.text + "'')\n                           ^"); break;
                }

            }
            else if (CommandUsername)
            {
                PlayerPrefs.SetString("username", input.text);
                addLog("Username Set To "+PlayerPrefs.GetString("username"));
                CommandUsername = false;
                inCommand = false;
            }

            input.text = "";
        }
    }
    void Tutorial()
    {
        string tutorial = "\nMOUSESCROLL TO ADJUST SPEED\nREACH THE /ROOT DIRECTORY, MARKED GREEN, WITHOUT ENTERING VOID ZONE AND GOT SCANNED BY ANTIVIRUS";
        addLog(tutorial);
    }

    void Leaderboard()
    {
        string[] results = lb.ToStringArray();

        //Debug.Log(results.Length);
        if (results == null)
        {
            addLog("Leaderboard is Empty");
        }
        else
        {
            bool found = false;
            int foundNum = -1;
            int cap = 10;
            int i = results.Length - 1;
            foreach (string score in results)
            {
                string[] temp = results[i].Split('|');
                if (cap > 0)
                {
                    addLog("\nRANK " + (results.Length - i).ToString() + ": " + temp[0] + " failed " + temp[1] + " times, success execution time taken: " + ((temp[2] == "9999999") ? "N/A" : temp[2]) + ";\n");
                    Debug.Log(results[i]);


                    cap--;
                }
                if (temp[0] == PlayerPrefs.GetString("username"))
                {
                    found = true;
                    foundNum = i;
                }

                i--;
            }

            if (found)
            {
                string[] temp = results[foundNum].Split('|');
                addLog("\nYOUR RANK: " + (results.Length - i).ToString() + ", failed " + temp[1] + " times, success execution time taken: " + ((temp[2] == "9999999") ? "N/A" : temp[2]) + ";\n");
            }
            else
            {
                addLog("\nYOUR RANK: NOT FOUND");
            }

        }
    }

    void StartGame()
    {
        mainMenu.SetActive(false);
        RedAlert.SetActive(true);
        Minimap.SetActive(true);
        Player.targetDisplay = 0;
        Main.targetDisplay = 1;
        sPEED.SetActive(true);
        Playermove.cursorLock = true;
        roll.SetBool("start", true);
        GameStarted = true;
    }

    void addLog(string content)
    {
        log.text += content + '\n';
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{

    public float bigger = 1f, lowwer = 0.8f;
    public Sprite mus_on, mus_off;


    void start()
    {
        if (gameObject.name == "Music")
        {
            if (PlayerPrefs.GetString("Music") == "off")
            {
               transform.GetChild(0).gameObject.GetComponent<Image>().sprite = mus_off;
                Camera.main.GetComponent<AudioListener>().enabled = false; //SWITCH off music
            }
        }
    }

    public void MenuButtons()
    {
        Application.LoadLevel("Menu");

    }
    void OnMouseDown()
    {
        transform.localScale = new Vector3(lowwer, lowwer, lowwer);

    }
    void OnMouseUp()
    {
        transform.localScale = new Vector3(bigger, bigger, bigger);
    }

    void OnMouseUpAsButton()
    {
        GetComponent<AudioSource>().Play();
        switch (gameObject.name)
        {
            case "Play":
                Application.LoadLevel("Level1");
                break;

            case "Settings":
                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(!transform.GetChild(i).gameObject.activeSelf);
                }
                break;

            case "Music":

                if (PlayerPrefs.GetString("Music") == "on") // Play music now
                {
                    Debug.Log("OFF");
                    GetComponent<Image>().sprite = mus_off;
                    PlayerPrefs.SetString("Music", "off");
                    Camera.main.GetComponent<AudioListener>().enabled = false; //SWITCH off music

                }
                else // Off music
                {
                    Debug.Log("ON");
                    GetComponent<Image>().sprite = mus_on;
                    PlayerPrefs.SetString("Music", "on");
                    Camera.main.GetComponent<AudioListener>().enabled = true; //SWITCH on music
                }
                break;

            case "Shop":
                Application.OpenURL("http://google.com");
                break;

            case "Telegram":
                Application.OpenURL("https://web.telegram.org");
                break;

            case "Exit":
                Application.Quit();
                break;

            case "MenuButtons":
                Application.LoadLevel("Menu");
                break;
            case "Help":
                Application.OpenURL("https://wikipedia.com");
                break;
        }

    }

   
}

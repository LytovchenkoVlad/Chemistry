using UnityEngine;
using System.Collections;

public class GameOverButtons: MonoBehaviour
{ 

    public float bigger = 1f, lowwer = 0.8f;


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
        switch (gameObject.name)
        {
            case "RepeatButton":
                Application.LoadLevel("Level1");
                break;

            case "BackButton":
                Application.LoadLevel("Menu");
                break;
        }
    }
}

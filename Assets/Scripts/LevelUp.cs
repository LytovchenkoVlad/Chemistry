using UnityEngine;
using System.Collections;

public class LevelUp : MonoBehaviour {

    public float timer;

	void Update () {
        timer = timer + 1f / 60f;
        if (timer > 5)
        {
            Debug.Log("Time!");
            Application.LoadLevel("menu");
        }

    }
}

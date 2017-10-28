using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpiningElectron : MonoBehaviour
{


    public Vector3 napravlenie;

    public GameObject hero;
    public Rigidbody2D rb;
    public float speed;
    public SpriteRenderer sr;
    public float timer;
    public Vector3 zet;
    public Vector3 Minuszet;

    void Start()
    {
        napravlenie = napravlenie * speed;

    }
    // ПОСТОЯННОЕ УМНОЖЕНИЕ СКОРОСТИ ИДЕТ!!!!!!!!!!!!!!
    void Update()
    {
        napravlenie = napravlenie.normalized;  
        napravlenie = hero.transform.position - this.transform.position;
        rb.AddForce(napravlenie);
    
        timer = timer + 1f / 60f;
        if(timer > 1)
        {
            this.transform.localScale = Minuszet;
            timer = 0;
        }


        if (timer == 0)
        {
            this.transform.localScale = zet;
        }

    }

   
}

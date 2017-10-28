using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    public Vector3 napravlenie;
    public GameObject Hero;
    public Rigidbody2D rb;

    private float angle;
    private Vector3 vecScale;
    public float mass;
    private float delta;
    private float massCoin;
    public Vector2 randVec;

    public PlayerController2 PlayerScript;

    public float timer;
    public bool timeOn;
    public float rastoyanie;

    public float maxRange;
    public float minRange;

    public Vector3 naprRasroyanie;
    public bool attack;
    public int CounterE, CounterP, CounterN; //ELements

    void Start()
    {
        mass = 200;
        delta = 5;
        vecScale.Set(1, 1, 1);
        delta = 8 * Mathf.Pow(20, -Mathf.Log(2, 0.1f)) * Mathf.Pow(mass, Mathf.Log(2, 0.1f));
        massCoin = 10;
    }

    // Controll for atacked Player
    void ControlEnemy()
    {
        napravlenie = Hero.transform.position - this.transform.position;

        napravlenie = napravlenie.normalized;
        napravlenie = napravlenie * delta;
        rb.AddForce(napravlenie);
        angle = Mathf.Atan2(napravlenie.y, napravlenie.x) * 57.32f;
        this.transform.localRotation = Quaternion.Euler(0, 0, angle);

        vecScale.Set((mass / 200 + 0.95f), (mass / 200 + 0.95f), 1);
        transform.localScale = vecScale;
        // mass -= 0.000002f * mass * mass; //уменьшение размера от массы. 
    }

    // Controll for backed down from Player
    void BackControlEnemy()
    {
        napravlenie = this.transform.position - Hero.transform.position;

        napravlenie = napravlenie.normalized;
        napravlenie = napravlenie * delta;
        rb.AddForce(napravlenie);
        angle = Mathf.Atan2(napravlenie.y, napravlenie.x) * 57.32f;
        this.transform.localRotation = Quaternion.Euler(0, 0, angle);

        vecScale.Set((mass / 200 + 0.95f), (mass / 200 + 0.95f), 1);
        transform.localScale = vecScale;
        // mass -= 0.000002f * mass * mass; //уменьшение размера от массы. 
    }

    void CheckMass()
    {
        if (PlayerScript.mass < this.mass) // If mass Hero < Enemy
        {
            attack = true;
        }
        else
        {
            attack = false;
        }

    }


    void Update()
    {
        delta = 8 * Mathf.Pow(20, -Mathf.Log(2, 0.1f)) * Mathf.Pow(mass, Mathf.Log(2, 0.1f));

        //Считаем растояние до Player
        naprRasroyanie = Hero.transform.position - this.transform.position;
        rastoyanie = naprRasroyanie.magnitude;
        naprRasroyanie = naprRasroyanie.normalized;


        if (rastoyanie < maxRange) // Проверка на атаку
        {
            Debug.Log("GO!");
            CheckMass();
            if (attack == true)
            {
                Debug.Log("ATTACK");
                ControlEnemy();
            }
        }

        if (rastoyanie < minRange) // Проверка на отступление
        {
            CheckMass();
            if (attack == false)
            {
                Debug.Log("BACK!!!");
                BackControlEnemy();
            }
        }

        //timer for gameover
        if (timeOn == true)
        {
            timer = timer + 1f / 60f;
        }
        if (timer > 3f)
        {
            Debug.Log("TIMER");
            Application.LoadLevel("GameOver");
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Food")
        {
            mass += massCoin;

            //сьеденый эл. телепортируем(рандомно)
            randVec.Set(Random.Range(-99.5f, 99.5f), (Random.Range(-99.5f, 99.5f)));
            col.gameObject.transform.position = randVec;
        }

        //Proton
        if (col.gameObject.tag == "ElementP")
        {
            CounterP++;
            Destroy(col.gameObject);
            //ANIMATIONS    
        }

        //Neytron
        if (col.gameObject.tag == "ElementN")
        {
            CounterN++;
            Destroy(col.gameObject);
            //ANIMATIONS    
        }

        //Electron
        if (col.gameObject.tag == "ElementE")
        {
            CounterE++;
            Destroy(col.gameObject);

        }

        if (col.gameObject.tag == "Player") // Если Враг > Hero
        {
            if (this.mass > PlayerScript.mass)
            {
                GetComponent<AudioSource>().Play();
                mass += PlayerScript.mass * 2;
                col.gameObject.SetActive(false);
                timeOn = true;

            }

        }
    }
}

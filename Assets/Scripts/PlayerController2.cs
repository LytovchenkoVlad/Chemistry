using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController2 : MonoBehaviour
{

    private Vector2 mousePosition;
    private float quotient;
    private float delta; // speed
    public float mass;
    private bool control;
    private Vector2 randVec;
    private Vector3 vecScale; // size Player

    public Camera cam;
    private float camSize;
    private int massCoin; //масса елементов

    public GameObject Enemy;
    public Enemy enemyScript;
    public float timer;

    private int CounterE, CounterP, CounterN; //ELements
    public Text txtCounterP, txtCounterN, txtCounterE;
    public GameObject ElectronAnimat;

    public GameObject LevelUpAnimat;
    public SpriteRenderer sr;
    public Sprite Geliy;

    public int previousLevel = 1; //Предыдущий
    public int currentLevel = 0; //текущий
    public float increase = 1; // на сколько будем увеличивать условие для LevelUp'a 
    public Text txtLevel; // output on display

    public Sprite[] sprites = new Sprite[2];




    void Start()
    {

        control = true;
        mass = 10;
        delta = 5;
        vecScale.Set(1, 1, 1);
        delta = 8 * Mathf.Pow(20, -Mathf.Log(2, 0.1f)) * Mathf.Pow(mass, Mathf.Log(2, 0.1f));

        camSize = 8;
        massCoin = 10;
    }


    void Update()
    {
        timer = timer + 1f / 60f;

        if (control == true)
        {
            delta = 8 * Mathf.Pow(20, -Mathf.Log(2, 0.1f)) * Mathf.Pow(mass, Mathf.Log(2, 0.1f));

            mousePosition = Input.mousePosition;  //получаем координаты нашей мыши
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition); //переводим экранные координаты в мировые
            mousePosition = mousePosition - (Vector2)transform.position; // притягиваем игрока к позиции мыши + преобразовываем в Вектор 2.
            quotient = Mathf.Sqrt(mousePosition.x * mousePosition.x + mousePosition.y * mousePosition.y) / delta; //коефиц. подобия (Пифагор/длину).
            mousePosition /= quotient;
            transform.Translate(mousePosition * Time.deltaTime);

            vecScale.Set((mass / 200 + 0.95f), (mass / 200 + 0.95f), 1);
            transform.localScale = vecScale;
            mass -= 0.0000015f * mass * mass; // то на сколько будет умешаться наш герой относительно своей массы.


            if (cam.orthographicSize > camSize)
            {
                if (cam.orthographicSize - 1 > camSize)
                {
                    cam.orthographicSize = camSize;
                }
                else
                {
                    cam.orthographicSize -= 0.0001f;
                }
            }
            else if (cam.orthographicSize < camSize)
            {
                if (cam.orthographicSize + 1 < camSize)
                {
                    cam.orthographicSize = camSize;
                }
                else
                {
                    cam.orthographicSize += 0.0001f;
                }
            }
        }

        //Elements countres 
        txtCounterP.text = "" + CounterP;
        txtCounterN.text = "" + CounterN;
        txtCounterE.text = "" + CounterE;
        txtLevel.text = "Level: " + previousLevel;

        //LEVEL UP
        if (CounterE >= increase)
        {
            if (CounterN >= increase)
            {
                if (CounterP >= increase)
                {
                    LevelUpAnimat.SetActive(true);
                    sr.sprite = Geliy;
                    increase = increase * 1.6f; // на сколько будем увеличивать условие для LevelUp'a 
                    previousLevel = previousLevel + 1; //к предыдущ. добавляем новый уровень
                    currentLevel = previousLevel; //приравниваем их, чтобы можно было составить условие
                    if(previousLevel == currentLevel)
                    {
                        LevelUpAnimat.SetActive(false);
                        Debug.Log("LEVEL UP");
                        LevelUpAnimat.SetActive(true);
                    }


                    //level = level + 1; // infinity ++ !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!  
                }
            }
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        //Eating
        if (col.gameObject.tag == "Food")
        {
            mass += massCoin;
            randVec.Set(Random.Range(-99.5f, 99.5f), (Random.Range(-99.5f, 99.5f))); //сьеденый эл. телепортируем(рандомно)
            col.gameObject.transform.position = randVec;

            camSize += 0.002f * massCoin;   //отдаление камеры * массу елемента. 
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
            ElectronAnimat.SetActive(true);
        }

        // Если Hero > Enemy
        if (col.gameObject.tag == "Enemy")
        {

            if (enemyScript.mass < this.mass)
            {
                GetComponent<AudioSource>().Play();
                Destroy(col.gameObject);
                mass += enemyScript.mass * 2; // Насколько увеличится Hero =(масса Enemy * 2)
            }
        }



    }
}


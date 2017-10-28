using UnityEngine;
using System.Collections;

public class ChaoticMoving : MonoBehaviour
{
    private float speed;
    public Rigidbody2D rb;
    public bool Control;

    private float timer;

    public Vector3 naprRasroyanie;
    public GameObject Hero;
    public float rastoyanie;
    public float maxRange;


    // Random moving 
    void ControlChaotic() 
    {   
            speed = 0.2f;
        //  transform.position = new Vector3(Mathf.PingPong(Time.time, 8) - 4, Mathf.PingPong(Time.time, 5) - 2, 1f) * speed;   
        transform.position = new Vector3(Random.value +10f, Random.value, 1) * speed;
    }

    void Update()
    {
        naprRasroyanie = Hero.transform.position - this.transform.position;
        rastoyanie = naprRasroyanie.magnitude;
        naprRasroyanie = naprRasroyanie.normalized;

        // Distance check  
        if (rastoyanie < maxRange) 
        {
            ControlChaotic();
        }


        //    timer = timer + 1f / 60f;
        //    if (timer > 2f)
        //    {
        //        RandomSpeed();
        //        timer = 0;
        //    }
        //}

        //public void RandomSpeed()
        //{
        //    speed = Random.Range(1f, 2f);
        //}
    }
}

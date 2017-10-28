using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour
{

    public GameObject Food;
    public GameObject Electron, Neytron, Proton;
    private Vector2 randVectorE; //for chemical elements Electron
    private Vector2 randVectorN;
    private Vector2 randVectorP;


    private Vector2 randVectorF; // for food


    void Awake()
    {
        // for food
        for (int i = 0; i < 3000; i++)
        {
            randVectorF.Set(Random.Range(-99.5f, 99.5f), (Random.Range(-99.5f, 99.5f)));
            Instantiate(Food, randVectorF, Quaternion.identity);
        }

        //for Neytron
        for (int i = 0; i < 30; i++)
        {
            randVectorN.Set(Random.Range(-99.5f, 99.5f), (Random.Range(-99.5f, 99.5f)));
            Instantiate(Neytron, randVectorN, Quaternion.identity);
        }

        //for Proton
        for (int i = 0; i < 30; i++)
        {
            randVectorP.Set(Random.Range(-99.5f, 99.5f), (Random.Range(-99.5f, 99.5f)));
            Instantiate(Proton, randVectorP, Quaternion.identity);
        }

        //for Electron
        for (int i = 0; i < 30; i++)
        {
            randVectorE.Set(Random.Range(-99.5f, 99.5f), (Random.Range(-99.5f, 99.5f)));
            Instantiate(Electron, randVectorE, Quaternion.identity);
        }

    }

}

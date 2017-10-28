using UnityEngine;
using System.Collections;

public class Coroutines : MonoBehaviour
{

    public GameObject obj;

    //void Start()
    //{
    //    Invoke("Inst", 1f); //это если нужно выполнить какую-то функцию один раз
    //}

    //void Inst()
    //{
    //    Instantiate(obj, new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(-10f, 10f)), Quaternion.identity);
    //}

    void Update()
    {
        if (Input.GetKey(KeyCode.F))
            StartCoroutine(instObj());
    }
   

    IEnumerator instObj()
    {
        Instantiate(obj, new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 1f), Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        
    }

}

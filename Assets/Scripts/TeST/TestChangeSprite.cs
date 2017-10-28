using UnityEngine;
using System.Collections;

public class TestChangeSprite : MonoBehaviour {

    public GameObject[] objects;
    private GameObject ins_obj;
    void Start()
    {
        int rand = Random.Range(0, objects.Length); //рандомные значения от нуля до кол-обьектов в массиве
        //for (int i = 0; i < objects.Length; i++) //внизу меняем на "i" и будет всё работаь в цикле
        
            ins_obj = Instantiate(objects[rand], objects[rand].transform.position, Quaternion.identity)
            /*указывем какого типа  обьект мы создаем*/ as GameObject; // (какой обьект создаем, позиция его, ротейшшн) 
        ins_obj.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f); //меняем параметры созданому геймобжекту.
    }
	

	void Update () {

       


    }
}

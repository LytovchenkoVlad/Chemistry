//http://doctrina-kharkov.blogspot.com/2016/07/lessons.html
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Записать результат выполнения функции в переменную Примеры:

// public float rzlt;

// rzlt = Mathf.Sqrt( 16f );
// rzlt = Mathf.Pow( 2f,3f );
// rzlt = Vector3.Distance( this.transform.position, hero.transform.position );

// Mathg.Sqrt - вызов функции, 16f - параметр, rzlt - переменная в которую запишиться результат

// НЕ Об'являть переменные здесь
public class Hero : MonoBehaviour
{

	//Об'являть переменные здесь
	public Vector3 povVlevo;
	public Vector3 povVpravo;

	//Переменные для управления по физике
	public Rigidbody2D rb;
	public Vector2 vverh;
	public Vector2 vpravo;

	//Переменные для жизней
	public float zhyzni = 3f;
	public GameObject krov;
	public GameObject serc1;
	public GameObject serc2;
	public GameObject serc3;
	public SpriteRenderer sr;


	//Переменные для подбора сундуков
	public float sobrSund;
	public Text sundTxt;

	public Text txtRange;
	public Vector3 napravlenie;
	public float rastoyanie;
	public GameObject chest;

	//public UrovenKisloroda urKisl; //получаем доступ к скприпту кислорода

	//
	public bool mertv = false;
	public float timer;

	void Start ()
	{
	
	}

	void Update ()
	{
		if ( mertv == false ){
			//Вызов ф-ии Upravlenie
			Upravlenie ();
		}

		if (mertv == true) {
			timer = timer + 1f/60f;
			if ( timer > 2f ){
				Application.LoadLevel("GameOver");
			}
		}
	
		napravlenie = chest.transform.position - this.transform.position;
		rastoyanie = napravlenie.magnitude;
		txtRange.text = rastoyanie + " ";


	}

	//Описание ф-ии Upravlenie
	void Upravlenie ()
	{

		if (Input.GetKey ("a")) {
			rb.AddForce (-vpravo);
			transform.localScale = povVlevo; //развернуть героя влево
		}

		if (Input.GetKey ("d")) {
			rb.AddForce (vpravo);
			transform.localScale = povVpravo; //развернуть героя вправо
		}

		if (Input.GetKey ("w")) {
			rb.AddForce (vverh);
		}

		if (Input.GetKey ("s")) {
			rb.AddForce (-vverh);
		}

	}

	void ObnovitEkran ()
	{
		if (zhyzni < 3f) {
			serc3.SetActive (false);
		}

		if (zhyzni < 2f) {
			serc2.SetActive (false);
		}

		if (zhyzni < 1f) {
			serc1.SetActive (false);
		}

		sundTxt.text = sobrSund + " ";

	}

	public void OtnqtZhyzn(){
		zhyzni = zhyzni - 1f; // уменьшить жизни
		ObnovitEkran ();
		
		if ( zhyzni < 1f ){
			Die();
		}
	}

	public void Die(){
		krov.SetActive( true ); //включаем кровь в Джоне
		sr.color = Color.red; // перекрашиваем его в красный
		mertv = true; // устанавливаем признак смерти
		rb.gravityScale = -0.2f; // делаем чтобы Джон всплывал
	}

	void OnCollisionEnter2D (Collision2D stolk)
	{
		if (stolk.gameObject.name == "ZlayaFish") {
			OtnqtZhyzn();
		}

		if (stolk.gameObject.name == "Sunduk") {
			sobrSund = sobrSund + 1f;
			Destroy( stolk.gameObject ); //удалить подобранный сундук
			ObnovitEkran();
		}

		//if (stolk.gameObject.name == "BalonKisloroda") {
		//	urKisl.sclKolichesvo.x = urKisl.sclKolichesvo.x + 1f; //увеличиваем переменную в которой храниться уровень кислорода
		//	Destroy( stolk.gameObject ); //удалить подобранный балон
		//}

	}



}

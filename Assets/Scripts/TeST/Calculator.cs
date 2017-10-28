using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Calculator : MonoBehaviour {

	public float currentNumber = 0;
	public float previousNumber = 0;
	public string operation;
	public Text txtNumbers;
	public GameObject force;




	void Start () {
	
	}

	void Update () {
	
	}

	public void ClickOne(){
		currentNumber = currentNumber * 10 + 1;
		resetMonitor();

	}

	public void ClickTwo(){
		currentNumber = currentNumber *10 + 2;
		resetMonitor();
		
	}

	public void ClickThird(){
		currentNumber = currentNumber *10 + 3;
		resetMonitor();
		
	}
	public void ClickZero(){
		currentNumber = currentNumber *10 + 0;
		resetMonitor();
	}

	public void ClickPlus(){
		previousNumber = currentNumber;
		currentNumber = 0;
		operation = "+";
		resetMonitor();
	}
	public void ClickMinus(){
		previousNumber = currentNumber;
		currentNumber = 0;
		operation = "-";
		resetMonitor();
	}
	public void ClickMultyly(){
		previousNumber = currentNumber;
		currentNumber = 0;
		operation = "*";
		resetMonitor();
	}
	public void ClickDivide(){
		previousNumber = currentNumber;
		currentNumber = 0;
		operation = "/";
		resetMonitor();
	}
	public void ClickStepen(){
		previousNumber = currentNumber;
		currentNumber = 0;
		operation = "^";
		resetMonitor();
	}


	public void ClickEquals(){
		if(operation == "+"){
		txtNumbers.text ="Ответ: " +(currentNumber =  currentNumber + previousNumber);
			force.gameObject.SetActive(true);
		}
		if(operation == "-"){
			txtNumbers.text = "Ответ: " +(currentNumber =  previousNumber - currentNumber);
			force.gameObject.SetActive(true);
		}
		if(operation == "*"){
			txtNumbers.text = "Ответ: " +(currentNumber =  previousNumber * currentNumber);
			force.gameObject.SetActive(true);
		}
		if(operation == "/"){
			txtNumbers.text = "Ответ: " +(currentNumber =  previousNumber / currentNumber);
			force.gameObject.SetActive(true);
		}
		if(operation == "^"){
			txtNumbers.text = "Ответ: " +(currentNumber = Mathf.Pow (previousNumber, currentNumber));
			force.gameObject.SetActive(true);
		}
		resetMonitor();
	}

	public void resetMonitor(){

		txtNumbers.text = currentNumber + "";
	}
	public void Clear(){
		currentNumber =0;
		previousNumber = 0;
		operation = "";
		resetMonitor();
	}


}

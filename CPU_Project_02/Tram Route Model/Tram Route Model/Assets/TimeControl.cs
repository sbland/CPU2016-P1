using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeControl : MonoBehaviour {

	public Button button1;
	public Button button2;
	public Button button3;
	public Button button4;
	public Button button5;
	public Button button6;

	public Text timeText;

	void Start() {


		Button btn1 = button1.GetComponent<Button>();
		btn1.onClick.AddListener(TaskOnClick1);

		Button btn2 = button2.GetComponent<Button>();
		btn2.onClick.AddListener(TaskOnClick2);

		Button btn3 = button3.GetComponent<Button>();
		btn3.onClick.AddListener(TaskOnClick3);

		Button btn4 = button4.GetComponent<Button>();
		btn4.onClick.AddListener(TaskOnClick4);

		Button btn5 = button5.GetComponent<Button>();
		btn5.onClick.AddListener(TaskOnClick5);

		Button btn6 = button6.GetComponent<Button>();
		btn6.onClick.AddListener(TaskOnClick6);

		timeText.text = " ";


	}

	void Update() {

	}



void TaskOnClick1(){

		timeText.text = "Before 07:30";


}

void TaskOnClick2(){

		timeText.text = "AM Peak 07:30-09:30";

}

void TaskOnClick3(){

		timeText.text = "Off-Peak 09:30-13:30";

}

void TaskOnClick4(){

		timeText.text = "13:30-15:59";

}

void TaskOnClick5(){


		timeText.text = "16:00-18:59";

}

void TaskOnClick6(){

		timeText.text = "19:00-End of service";

}

}
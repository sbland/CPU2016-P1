using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LightControl : MonoBehaviour {
	//public float duration = 1.0F;
	public Light lt;

	public Button button1;
	public Button button2;
	public Button button3;
	public Button button4;
	public Button button5;
	public Button button6;

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



		lt = GetComponent<Light>();
		lt.color = Color.white;
	}
	void Update() {
		//float phi = Time.time / duration * 2 * Mathf.PI;
		//float amplitude = Mathf.Cos(phi) * 0.5F + 0.5F;
		//lt.intensity = amplitude;
	}



void TaskOnClick1(){
	lt.intensity = 0.4f;
		Color earlyMorningColor = new Color (0.9f, 0.85f, 0.8f);
		lt.color = earlyMorningColor ;
}

void TaskOnClick2(){
		lt.intensity = 0.5f;
		Color morningColor = new Color (1f, 0.8f, 0.5f);
		lt.color = morningColor;
}

void TaskOnClick3(){
		lt.intensity = 0.8f;
		Color midMorningColor = new Color (1f, 0.8f, 0.5f);
		lt.color = midMorningColor;
}

void TaskOnClick4(){
		lt.intensity = 0.85f;
		Color afternoonColor = new Color (1f, 0.85f, 0.65f);
		lt.color = afternoonColor;
}

void TaskOnClick5(){
		lt.intensity = 0.8f;
		Color midafternoonColor = new Color (1f, 0.85f, 0.7f);
		lt.color = midafternoonColor;
}

void TaskOnClick6(){
		lt.intensity = 0.6f;

		Color eveningNightColor = new Color (1f, 0.8f, 0.5f);
		lt.color = eveningNightColor;
}

}
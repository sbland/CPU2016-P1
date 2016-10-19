using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MouseOver : MonoBehaviour
{
	Ray ray;
	RaycastHit hit;
	public Text floatingText;

	void Update()
	{
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(ray, out hit))
		{

			//ignores map
			if (hit.collider.name == "MapUnderlay") {
			
			} 

			else {
				//Debug.Log (hit.collider.name);
				float scaleOfBar = hit.collider.transform.localScale.z;
				//Debug.Log (scaleOfBar);

				if (scaleOfBar != 100) {
					floatingText.text = ((hit.collider.name) + ": " + (scaleOfBar));
					floatingText.transform.position = (Input.mousePosition);
				}







			}


		}
	}
}
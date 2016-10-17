using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MouseOver : MonoBehaviour
{
	
	Ray ray;
	RaycastHit hit;
	public Text floatingText;
	public Camera camera;

	void Update()
	{
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(ray, out hit))
			
		{

			//ignores map
			if (hit.collider.name == "MapUnderlay") {
			
				floatingText.text = " ";
			} 

			else {
				Debug.Log (hit.collider.name);
				float scaleOfBar = hit.collider.transform.localScale.y;
				floatingText.text = ((hit.collider.name)+ ": " + (scaleOfBar));
				floatingText.transform.position = (Input.mousePosition);


//
//				if (scaleOfBar != 100) {
//					floatingText.text = ((hit.collider.name) + ": " + (scaleOfBar));
//					floatingText.transform.position = (Input.mousePosition);
//				}







			}


		}
	}
}
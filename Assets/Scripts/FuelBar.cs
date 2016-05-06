using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour {

	[SerializeField]
	private float fillAmount;
	[SerializeField]
	private Image content;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		HandleBar ();
	}

	private void HandleBar (){
		content.fillAmount = Map(GameObject.Find("Player").GetComponent<PlayerScript>().fuel,0,GameObject.Find("Player").GetComponent<PlayerScript>().maxFuel);
	}

	private float Map (float value, float inMin, float inMax){
		//return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
		return Mathf.InverseLerp(inMin, inMax, value);
	}

}

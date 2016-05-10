using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour {

	[SerializeField]
	private float fillAmount;
	[SerializeField]
	private Image content;
    private PlayerScript player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
	}
	
	// Update is called once per frame
	void Update () {
		HandleBar ();
	}

	private void HandleBar (){
		content.fillAmount = Map(player.jumpDuration, 0f, 0.7f);
	}

	private float Map (float value, float inMin, float inMax){
		//return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
		return Mathf.InverseLerp(inMin, inMax, value);
	}

}

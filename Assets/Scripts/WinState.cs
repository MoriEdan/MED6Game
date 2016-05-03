using UnityEngine;
using System.Collections;

public class WinState : MonoBehaviour {

	public Texture Clear;
	public Texture ClearBG;
	bool winState = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player"){
			Debug.Log ("WinState Activated");
			winState = true;
		}
	}

	void OnGui(){
		int imageWidth = Clear.width;
		int ImageHeight = Clear.height;
		int imageBGWidth = ClearBG.width;
		int imageBGHeight = ClearBG.height;

		if (winState == true) {
			GUI.DrawTexture(new Rect(Screen.width/2 - imageBGWidth/2, Screen.height/2 - imageBGHeight/2, imageBGWidth,imageBGHeight),ClearBG);
			GUI.DrawTexture(new Rect(Screen.width/2 - imageWidth/2, Screen.height/2 - ImageHeight/2, imageWidth,ImageHeight),ClearBG);
		}
	}

}

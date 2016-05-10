using UnityEngine;
using System;
using System.IO;
using System.Text;
using System.Collections;

public class WinState : MonoBehaviour {

	public Texture Clear;
	public Texture ClearBG;
	bool winState = false;
    public bool hasStarted = false;

    private bool textHandled;
    private float playTime;
    private int addRate;
    private string path;
    private string name = "Participant";
    private StreamWriter textOut;
    private PlayerEmotions playEmo;

	void Start () {
        path = @"C:\" + name + ".txt";
        if (File.Exists(path))
        {
            for (int i = 0; i < 100; i++)
            {
                path = @"C:\" + name + i + ".txt";
                if (!File.Exists(path))
                    break;
            }
        }
        textOut = new StreamWriter(path, false);
        playEmo = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerEmotions>();
	}

	void FixedUpdate () {
        if (!winState && hasStarted)
        {
            playTime += Time.fixedDeltaTime;
            if (addRate >= 5)
            {
                textOut.WriteLine(playEmo.currentAnger);
                addRate = 0;
            }
            else
                addRate++;
        }
        else if (winState && !textHandled)
        {
            textHandled = true;
            textOut.WriteLine("\n\n\n " + name + "'s time: " + playTime);
            textOut.Close();
        }
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
			GUI.DrawTexture(new Rect(Screen.width/2 - imageWidth/2, Screen.height/2 - ImageHeight/2, imageWidth,ImageHeight),Clear);
			GUI.DrawTexture(new Rect(Screen.width/2 - imageBGWidth/2, Screen.height/2 - imageBGHeight/2, imageBGWidth,imageBGHeight),ClearBG);
            GUI.Label(new Rect(20, 20, 100, 30), "Time: " + playTime);
		}
	}

}

using UnityEngine;
using System.Collections;

public class ButtonCheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		abc  = Input.inputString;
		Debug.Log ("   "+abc);
	}
	string abc;
	void OnGUI() {

		//string temp = Input.GetKey (KeyCode);
		 //abc  = Input.inputString;
		GUI.Label(new Rect(10, 10, 100, 20),abc);
	}

	public void Reloadmove(){
		Application.LoadLevel ("MoveCube");
	}
}

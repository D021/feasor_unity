using UnityEngine;
using System.Collections;

public class StartMenuGUIScript : MonoBehaviour {
	
	public GUIStyle customGUIStyle;
	
	void OnGUI ()
	{
		
		
		float w = 200f;
		float h = 200f;
		
		Rect boxArea = new Rect (Screen.width / 2 - w / 2, Screen.height / 2 - h / 2, w, h);
		GUILayout.BeginArea (boxArea);
		if (GUILayout.Button ("Start Game", customGUIStyle)) {
			Application.LoadLevel (1);
		}
		
		if (GUILayout.Button ("Quit Game", customGUIStyle)) {
			print ("Quit");
			Application.Quit ();
		}
		
		GUILayout.EndArea ();
	}
	
	// Use this for initialization
	void Start () {
		this.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit ();
		}
	
	}
}

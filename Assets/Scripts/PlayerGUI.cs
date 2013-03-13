using UnityEngine;
using System.Collections;

public class PlayerGUI : MonoBehaviour {
	
	private PlayerStatus playerStatus;
	
	void OnGUI ()
	{
		DisplayCursor();
		DisplayHealth();
	}
	
	void DisplayHealth ()
	{
		GUI.Box (new Rect (10, 10, 100, 50), "");
		
		GUI.Label (new Rect (20, 20, 100, 50), "Health: " + playerStatus.health);
		
	}

	void DisplayCursor ()
	{
		float w = 20f;
		float h = 20f;
		GUI.Box (new Rect ((Screen.width - w )/ 2 , (Screen.height - h) / 2, w, h), "");
	}
	
	// Use this for initialization
	void Start () {
		this.playerStatus = GetComponent<PlayerStatus>();
	}
	
	// Update is called once per frame
	void Update () {
		Screen.lockCursor = true;
	}
}

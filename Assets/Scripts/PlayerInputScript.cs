using UnityEngine;
using System.Collections;

public class PlayerInputScript : MonoBehaviour {
	
	public GameObject respawnPoint;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit();
		}
		
	}
}

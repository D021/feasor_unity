using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {
	
	public float health;
	public GameObject spawnPoint;
	
	private CharacterController characterController;
	private bool isFalling;
	private float lastY;
	
	void Respawn ()
	{
		transform.position = spawnPoint.transform.position;
		CameraFade.StartAlphaFade (Color.black, true, 5f);
		
	}
	
	// Use this for initialization
	void Start ()
	{
		health = 100f;
		characterController = GetComponent<CharacterController>();
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (Input.GetKeyDown (KeyCode.R)) {
			Respawn();
		}
		

		
		if (characterController.isGrounded == false) { // if character not grounded...
			isFalling = true;        // assume it's falling
		} else {
			isFalling = false;
			lastY = transform.position.y; // update lastY when character grounded
		}
		
		if (isFalling) {            // but was falling last update...
			float hFall = lastY - transform.position.y; // calculate the fall height...
			if (hFall > 8) {        // then check the damage/death
				
				// Fall too high, die
				//CameraFade.StartAlphaFade (Color.black, false, 5f, 0f, Respawn);
			}
			
		}
	}
}

using UnityEngine;
using System.Collections;

public class IntroStoryScript : MonoBehaviour
{
	public GameObject startMenu;
	
	private bool isLockCursor = true;
	
	private static string[] lines = {
		"An experiment went bad",
		"Jacobian found a way to reconstruct mini black holes",
		"The black holes have taken him away from home to Skyelo",
		"At this place, he will find many bizzare things, among those are feasors",
		"The planet may look like Earth",
		"...but it's nothing like home."
	};
	
	private static int lineIndex = 0;
	private float passedTime = 0.0f;
	private const float FADE_TIME = 5f;
	
	void OnGUI ()
	{
		passedTime += Time.deltaTime;
		if (passedTime >= FADE_TIME) {
			
			if (Event.current.type == EventType.KeyDown || Event.current.type == EventType.MouseDown) {
				passedTime = 0f;

				CameraFade.StartAlphaFade (Color.black, true, FADE_TIME);
				if (lineIndex + 1 == lines.Length) {
						
					//
					// Done. Move to GUI menu
					//
						
					isLockCursor = false;
					transform.Translate (new Vector3 (transform.position.x, transform.position.y, -100));
					startMenu.GetComponent<StartMenuGUIScript> ().enabled = true;
				} else {
		
					lineIndex += 1;
					guiText.text = lines [lineIndex];
				}			
			}
		}
	}
	
	// Use this for initialization
	void Start ()
	{
		CameraFade.StartAlphaFade (Color.black, true, 10f);
		guiText.text = lines [lineIndex];
	}
	
	// Update is called once per frame
	void Update ()
	{
		Screen.lockCursor = isLockCursor;

	}
}

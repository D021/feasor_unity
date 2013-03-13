using UnityEngine;
using System.Collections;

public class Manipulator : MonoBehaviour {
	
	private Ray mouseRay;
	private Transform pickObj;
	private float dist;
	private float closingDist;
	private const float MIN_DIST = 1f;
		
	void CheckRayCastBor ()
	{
		RaycastHit hit = new RaycastHit ();
		
		if (Physics.Raycast (mouseRay, out hit, 100) && hit.transform.tag == "Nethon") {
									
			if (Input.GetMouseButton (0)) {
			
				if (!pickObj) {
										
					//
					// if it's a rigidbody, zero its physics velocity
					//
					
					if (hit.rigidbody) {
						hit.rigidbody.velocity = Vector3.zero;
					}
					
					pickObj = hit.transform; // now there's an object picked
					
					//
					// remember its distance from the camera
					//
					
					dist = Vector3.Distance (pickObj.position, Camera.main.transform.position);
					
				} else { 
						
					//
					// if object already picked...
					//
					
					if (Input.GetKey (KeyCode.LeftShift) && dist > MIN_DIST) {
						
						//
						// Closing distance to player to create sling shot.
						//
						
						float deltaDist = Time.deltaTime;
						closingDist += deltaDist;
						dist -= deltaDist * 2;
					}
					
					if (Input.GetKeyUp (KeyCode.LeftShift)) {
						
						//
						// Clear closing dist when we release sling shot key
						//
						closingDist = 0;
					}
					
					Vector3 newPos = mouseRay.GetPoint (dist);
					pickObj.position = newPos;
				}
			} else { 
					
				//
				// when button released free pickObj, apply a force scaled with the closing distance 
				// the bor traveled
				//
				
				if (pickObj) {
					pickObj.gameObject.GetComponent<NethonScript> ().force = transform.forward * closingDist;
				}
				
				//
				// Reset to null
				//
				
				closingDist = 0;
				pickObj = null;
			}
		}
	}
		
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		CheckRayCastBor();
	}
}

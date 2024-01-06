using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class GravityBody : MonoBehaviour {
	
	public GravityAttractor planet;
	Rigidbody rb;
	
	void Awake () {
		//planet = GameObject.FindGameObjectWithTag("Ground").GetComponent<GravityAttractor>();
		rb = GetComponent<Rigidbody> ();

		// Disable rigidbody gravity and rotation as this is simulated in GravityAttractor script
		rb.useGravity = false;
		rb.constraints = RigidbodyConstraints.FreezeRotation;
	}
	
	void FixedUpdate () {
		// Allow this body to be influenced by planet's gravity
		planet.Attract(rb);
	}
}
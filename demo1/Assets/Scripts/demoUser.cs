using UnityEngine;
using System.Collections;

public class demoUser : MonoBehaviour {
	
	public Transform puck;
	private Vector3 initialPositionOfMallet;
	float radius1;
	float radius2;
	float sumOfRadius;
	float distance;
	Vector3 direction;
	float rayLength =0.5f;
	Vector3 previousPosition;
	Vector3 velocity;

	void Awake(){
		previousPosition = this.transform.position;
	}
	// Use this for initialization
	void Start () {
		initialPositionOfMallet = new Vector3 (0, 0.08f, -3.44f);
		this.transform.position = initialPositionOfMallet;
	}
	
	// Update is called once per frame

	void FixedUpdate(){

		velocity = (this.transform.position - previousPosition) / Time.deltaTime;

        //Debug.Log(velocity.magnitude);


//		Debug.Log (puck.GetComponent<Rigidbody> ().velocity.magnitude);

		direction = puck.transform.position - this.transform.position;
		//Working
		radius1 = this.GetComponent<Renderer> ().bounds.extents.magnitude;
		radius2 = puck.GetComponent<Renderer> ().bounds.extents.magnitude;
		sumOfRadius = radius1 + radius2;
		distance = Vector3.Distance (this.transform.position, puck.position);
		if (distance <= sumOfRadius) {
			puck.GetComponent<Rigidbody>().AddForce((direction)*20,ForceMode.VelocityChange);
		}
	}


	void OnMouseDrag(){
		float maxX = 1.76f;
		float minX = -1.76f;
		float minZ = -3.59f;
		float maxZ = -0.39f;
		//float maxZ = 3.62f;
		float distance_to_screen = Camera.main.WorldToScreenPoint(this.transform.position).z;
		Vector3 position = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
		this.transform.position = new Vector3 (position.x, this.transform.position.y, position.z);
		if(this.transform.position.x <=minX || this.transform.position.x >=maxX || 
		   this.transform.position.z <=minZ || this.transform.position.z >=maxZ){
			float xPos =Mathf.Clamp(this.transform.position.x,minX,maxX);
			float zPos = Mathf.Clamp(this.transform.position.z,minZ,maxZ);
			this.transform.position=new Vector3(xPos,this.transform.position.y,zPos);
		}

	}
	void OnMouseUp(){
		this.GetComponent<Rigidbody>().velocity = Vector3.zero;
		this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
	}

}

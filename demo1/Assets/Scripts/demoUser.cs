using System;
using UnityEngine;
using System.Collections;
public class demoUser : MonoBehaviour {

    
   
    
	public Transform puck;
	float radius1;
	float radius2;
	float sumOfRadius;
	float distance;
	Vector3 direction;
    float maxX;
    float minX;
    float minZ;
    float maxZ;
    Vector3 center;
    Vector3 extents;
    

    void Awake()
    {
        maxX = ObjectPlacing.maxX;
        minX = ObjectPlacing.minX;
        maxZ = ObjectPlacing.maxZ;
        minZ = ObjectPlacing.minZ;
       
    }
	// Use this for initialization
	void Start () {

	}
	// Update is called once per frame
	void FixedUpdate(){

		direction = puck.transform.position - this.transform.position;
		//Working
		radius1 = this.GetComponent<Renderer> ().bounds.extents.magnitude;
		radius2 = puck.GetComponent<Renderer> ().bounds.extents.magnitude;
		sumOfRadius = radius1 + radius2;
		distance = Vector3.Distance (this.transform.position, puck.position);
		if (distance <= sumOfRadius) {
            puck.GetComponent<Rigidbody>().AddForce((direction) * 20, ForceMode.VelocityChange);
		}
	}
	void OnMouseDrag()
    {
		float distance_to_screen = Camera.main.WorldToScreenPoint(this.transform.position).z;
		Vector3 position = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
		this.transform.position = new Vector3 (position.x, this.transform.position.y, position.z);
		if(this.transform.position.x <=minX || this.transform.position.x >=maxX || 
		   this.transform.position.z <=minZ || this.transform.position.z >=maxZ)
        {
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
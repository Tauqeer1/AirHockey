using System;
using UnityEngine;
using System.Collections;

public class demoUser : MonoBehaviour {

    public Transform table;
    public Camera camera;
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
        //ObjectPlacing obj = new ObjectPlacing();
        

        //maxX = ObjectPlacing.maxX;
        //minX = ObjectPlacing.minX;
        //maxZ = ObjectPlacing.maxZ;
        //minZ = ObjectPlacing.minZ;


        //Debug.Log("Max X" + maxX);
        //Debug.Log("Min X" + minX);

        double cameraAspectRatio = Math.Round(camera.aspect, 2);
        center = table.GetComponent<Renderer>().bounds.center;
        extents = table.GetComponent<Renderer>().bounds.extents;


        Debug.Log("Camer Aspect Ratio " + cameraAspectRatio);

        if (cameraAspectRatio == 0.75)
        {
            Debug.Log("iPad Tall");
            this.transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
            this.transform.position = new Vector3(0, 0.05f, -3.5f);
            puck.transform.position = new Vector3(0, 0.113f, 0);
            maxX = center.x + extents.x - 0.6f;
            minX = center.x - extents.x + 0.6f;
            maxZ = center.z;
            minZ = center.z - extents.z + 0.7f;


        }
        else if (cameraAspectRatio == 0.67)
        {
            Debug.Log("iPhone Tall");
            this.transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
            this.transform.position = new Vector3(0, 0.05f, -3.5f);
            maxX = center.x + extents.x - 0.6f;
            minX = center.x - extents.x + 0.6f;
            maxZ = (center.z);
            minZ = center.z - extents.z + 0.7f;
            Debug.Log("Max Z" + maxZ);
            Debug.Log("Min Z" + minZ);
        }
        else if (cameraAspectRatio == 0.56)
        {
            Debug.Log("iPhone 5 Tall");
            this.transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
            this.transform.position = new Vector3(0, 0.05f, -3.5f);
            maxX = center.x + extents.x - 0.6f;
            minX = center.x - extents.x + 0.6f;
            maxZ = center.z;
            minZ = center.z - extents.z + 0.7f;
        }

    }
	// Use this for initialization
	void Start () {
        
        //initialPositionOfMallet = new Vector3 (0, 0.08f, -3.44f);
        //this.transform.position = initialPositionOfMallet;
	}
	
	// Update is called once per frame

	void FixedUpdate(){

        //velocity = (this.transform.position - previousPosition) / Time.deltaTime;

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


	void OnMouseDrag()
    {
		
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

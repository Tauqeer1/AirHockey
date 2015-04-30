using UnityEngine;
using System.Collections;

public class User : MonoBehaviour {


    public GameObject mallet;
    public GameObject puck;
    private Vector3 initialPositionOfMallet;
    private Vector3 initialPositionOfPuck;
	private Vector3 direction;
	// Use this for initialization

	Vector3 prevPosition;
	Vector3 velocity;

    void Start()
    {
		initialPositionOfMallet = new Vector3 (0, 43.17f, -55);
        mallet.transform.position = initialPositionOfMallet;

        initialPositionOfPuck = new Vector3(0, 43.68f, 0);
        puck.transform.position = initialPositionOfPuck;
    }
	// Update is called once per frame
    void FixedUpdate()
    {
		velocity = (transform.position - prevPosition) / Time.deltaTime;
		prevPosition = transform.position;
		HittingPuck ();
    }
    void OnMouseDrag()
    {
		float maxX = 31;
		float minX = -31;
		float minZ = -63f;
		float maxZ = -3f;
        float distance_to_screen = Camera.main.WorldToScreenPoint(mallet.transform.position).z;
		Vector3 position = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
		mallet.transform.position = new Vector3 (position.x, mallet.transform.position.y, position.z);
		if(mallet.transform.position.x <=minX || mallet.transform.position.x >=maxX || 
		   mallet.transform.position.z <=minZ || mallet.transform.position.z >=maxZ){
			float xPos =Mathf.Clamp(mallet.transform.position.x,minX,maxX);
			float zPos = Mathf.Clamp(mallet.transform.position.z,minZ,maxZ);
			mallet.transform.position=new Vector3(xPos,mallet.transform.position.y,zPos);
		}
	}
	void OnMouseUp()
	{
		mallet.GetComponent<Rigidbody>().velocity = Vector3.zero;
		mallet.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
	}



	bool detectionDisabled = false;
	void HittingPuck()
	{
		//Debug.Log ("Hitting puck");
		direction = puck.transform.position - mallet.transform.position;

		float distance = direction.magnitude;

		if (distance > 6.5f)
						detectionDisabled = false;

		if(distance < 6.5f){

            
			//puck.rigidbody.velocity = Vector3.zero;
            if (velocity.magnitude > 2)
            {
                puck.transform.position = 
                    transform.position + velocity.normalized * Mathf.Clamp(velocity.magnitude, 1, 2) * Mathf.Abs(transform.GetComponent<Renderer>().bounds.extents.y * 1 + puck.transform.GetComponent<Renderer>().bounds.extents.z * 1) * 1.5f;
            }

            if (!detectionDisabled)
            {
                detectionDisabled = true;
                Vector3 force = (direction) * 70;
                force -= new Vector3(0, force.y, 0);
                /////puck.rigidbody.AddForceAtPosition((direction)*500,puck.transform.position);	
                puck.GetComponent<Rigidbody>().AddForce(force, ForceMode.VelocityChange);
            }


		}
	}

}






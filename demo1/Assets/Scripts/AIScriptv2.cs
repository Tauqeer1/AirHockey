using UnityEngine;
using System.Collections;

public class AIScriptv2 : MonoBehaviour {

    public Transform puck;
    public Transform Goal;
    private Vector3 direction;
    private float defaultPuckHeight;
    private Vector3 puckPosition;
    private Vector3 goalDirection;
    Vector3 initialPositionOfMallet;
    int waitCount = 0;
	// Use this for initialization
	void Start () {
        defaultPuckHeight = puck.transform.position.z - puck.GetComponent<Renderer>().bounds.min.z;
        //initialPositionOfMallet = new Vector3(0, 43.2f, 71f); 
        
    }
	
	// Update is called once per frame
	void FixedUpdate()
    {

        puckPosition = puck.transform.position + new Vector3(0, 0, defaultPuckHeight);
        goalDirection = (initialPositionOfMallet - this.transform.position);
        
        direction = (puckPosition - this.transform.position).normalized;

		if (waitCount > 0)
        {
            waitCount--;
            this.transform.position += goalDirection * 3.0f * Time.deltaTime;
            return;
        }
        if (puckPosition.z > 0)
        {
            //Attack();
            Debug.Log(puckPosition.z);
        }
        else if (puckPosition.z < 0)
        {
            //Defence();
        }
        
    }
   
    void Defence()
    {
			this.transform.position += goalDirection * Time.deltaTime * 3.0f;
            if (puck.transform.position.x > this.transform.position.x)
            {
                this.transform.position += Vector3.right * puck.GetComponent<Rigidbody>().velocity.magnitude * Time.deltaTime;
            }
            if (puck.transform.position.x < this.transform.position.x)
            {
                this.transform.position += -(Vector3.right * puck.GetComponent<Rigidbody>().velocity.magnitude * Time.deltaTime);
            }
    }
    void Attack()
    {
		if (Vector3.Dot (this.transform.up, direction) > 0) 
		{	
			this.transform.position+=direction*2.0f;
			float distance = Vector3.Distance(this.transform.position,puckPosition);

				if(distance < Mathf.Abs (defaultPuckHeight * 1))
				{
				    waitCount = 30;
				    puck.GetComponent<Rigidbody>().velocity = Vector3.zero;
				    puck.transform.position = transform.position + 
                                              transform.up * (transform.GetComponent<Renderer>().bounds.extents.z * 1 + 
                                              puck.transform.GetComponent<Renderer>().bounds.extents.z * 1);

                    //Vector3 force = (direction) * 150;
                    //force -= new Vector3(0, force.y, 0);
                    puck.GetComponent<Rigidbody>().AddForce((direction)*150 , ForceMode.VelocityChange);
                    this.transform.position += goalDirection  * Time.deltaTime * 1.0f;      
                    
				}
		}

		if (Vector3.Dot (this.transform.up, direction) < 0) {

						this.transform.position += goalDirection * Time.deltaTime * 3.0f;
						//this.transform.position += initialPositionOfMallet * 1.0f;
				} 

    }
   
}

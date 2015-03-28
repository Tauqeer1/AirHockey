using UnityEngine;
using System.Collections;

public class puckWallColliding : MonoBehaviour {

	public Transform puck;
	public LayerMask layerMask;
	private Vector3 previousPosition;
	private Vector3 currentPositionTo;
	private Rigidbody myRigidBody;
	private RaycastHit hit;


	void Awake(){
		myRigidBody = GetComponent<Rigidbody>();
		previousPosition = myRigidBody.position;
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		currentPositionTo = (previousPosition - transform.position);
		Debug.DrawLine(transform.position, currentPositionTo, Color.red);
		if (Physics.Raycast(previousPosition, currentPositionTo, out hit, Vector3.Distance(previousPosition,transform.position), layerMask.value))
		{
			puck.GetComponent<Rigidbody>().velocity = -(puck.GetComponent<Rigidbody>().velocity);
		}
		previousPosition = myRigidBody.position;
	}
}

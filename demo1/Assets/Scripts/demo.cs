using UnityEngine;
using System.Collections;

public class demo : MonoBehaviour {

    
    public LayerMask layerMask;
    private Vector3 previousPosition;
    private Vector3 currentPositionTo;
    private Rigidbody myRigidBody;
    private RaycastHit hit;


    private Color color = Color.red;

    private Vector3 frontTopLeft;
    private Vector3 frontTopRight;
    private Vector3 frontBottomRight;
    private Vector3 frontBottomLeft;

    public Transform cylinder1;
    public Transform cylinder2;

    float radius1;
    float radius2;
    float sumOfRadius;
    float distance;



    private float rayLength = 0.5f;
    void Awake()
    {
        myRigidBody = GetComponent<Rigidbody>();
        previousPosition = myRigidBody.position;
    }


    void Start()
    {
        //defaultPuckHeight = puck.transform.position.z - puck.GetComponent<Renderer>().bounds.min.z;
        //puckPosition = puck.transform.position + new Vector3(0, 0, defaultPuckHeight);



        
                 

        
    }

	void FixedUpdate()
    {


        //Working
        //radius1 = cylinder1.GetComponent<Renderer>().bounds.extents.sqrMagnitude;
        //radius2 = cylinder2.GetComponent<Renderer>().bounds.extents.sqrMagnitude;
        //sumOfRadius = radius1 + radius2;
        //distance = Vector3.Distance(cylinder1.position, cylinder2.position);
        //Debug.Log("Distance =" + distance);
        //Debug.Log("Sum of Radius" + sumOfRadius);
        //if (distance <= sumOfRadius)
        //{
        //    Debug.Log("Both cylinders are intersecting each other");
        //}



       // Vector3 center = GetComponent<Renderer>().bounds.center;
       // Vector3 extent = GetComponent<Renderer>().bounds.extents;


        Debug.DrawLine(transform.position, new Vector3(0, 0, 0) * rayLength, Color.black);


        Vector3 direction = (cylinder2.position - cylinder1.position).normalized;

        

        if (Physics.Raycast(transform.position,direction,rayLength))
        {
            Debug.Log("Colliding with another cylinder");
        }
        else if (Physics.Raycast(transform.position, transform.forward, rayLength))
        {
            Debug.Log("Colliding forward");
        }
        else if (Physics.Raycast(transform.position, -transform.forward, rayLength))
        {
            Debug.Log("Colliding backward");
        }
        else if (Physics.Raycast(transform.position, transform.right, rayLength))
        {
            Debug.Log("Colliding right");
        }
        else if (Physics.Raycast(transform.position, -transform.right, rayLength))
        {
            Debug.Log("Colliding Left");
        }
        







        
        //frontTopLeft = new Vector3(center.x - extent.x, center.y + extent.y, center.z + extent.z);
        //frontTopRight = new Vector3(center.x + extent.x, center.y + extent.y, center.z + extent.z);


        //Vector3 frontTopCenter = new Vector3(center.x + 0.2f, center.y + extent.y, center.z + extent.z);
        ////Debug.DrawLine(frontTopCenter, frontTopRight, color);


        //Vector3 frontBottomCenter = new Vector3(center.x + 0.2f, center.y - extent.y, center.z + extent.z);
        //Debug.DrawLine(frontTopCenter, frontBottomCenter, color);






        //float defaultPuckHeight =cylinder1.transform.position.z - cylinder1.GetComponent<Renderer>().bounds.min.z;
        // Vector3 puckPosition = cylinder1.transform.position + new Vector3(0, 0, defaultPuckHeight);


        //currentPositionTo = (transform.position - previousPosition);
        //Debug.DrawLine(transform.position, currentPositionTo, Color.red);
        //if (Physics.Raycast(previousPosition, currentPositionTo, out hit, Vector3.Distance(transform.position,previousPosition), layerMask.value))
        //{
        //    Debug.Log("Layer mask value " + layerMask.value);
        //    Debug.Log("Hit Point " + hit.point);
        //    Debug.Log("My RigidBody Position " + myRigidBody.position);
        //    myRigidBody.position = hit.point;
        //}
        //previousPosition = myRigidBody.position;
    }
}

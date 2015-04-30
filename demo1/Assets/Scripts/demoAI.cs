using UnityEngine;
using System.Collections;

public class demoAI : MonoBehaviour
{

    public Transform puck;
    public Transform goal;
    Vector3 initialPositionOfMallet;
    Vector3 goalDirection;
    Vector3 direction;
    float radius1;
    float radius2;
    float sumOfRadius;
    float distance;
    float movingSpeed;
    int hitForce;
    // Use this for initialization

    void Awake()
    {
        movingSpeed = UIManagerScript.movingSpeed;
        hitForce = UIManagerScript.hitForce;
    }
    
    
    void Start()
    {
        
        initialPositionOfMallet = new Vector3(0, 0.07f, 3.56f);
        this.transform.position = initialPositionOfMallet;
    }

    void FixedUpdate()
    {
        direction = (puck.transform.position - this.transform.position).normalized;
        goalDirection = initialPositionOfMallet - this.transform.position;
        //goalDirection = goalDirection + new Vector3(0, 0, 1);
        if (puck.transform.position.z > 0)
        {
            Attack();
        }
        if (puck.transform.position.z < 0)
        {
            Defence();
        }

    }
    void Attack()
    {
        if (Vector3.Dot(this.transform.up, direction) > 0)
        {
           // this.transform.position += direction * 2.0f * Time.deltaTime;
            this.transform.position += direction * movingSpeed * Time.deltaTime;
            distance = Vector3.Distance(this.transform.position, puck.transform.position);
            radius1 = this.GetComponent<Renderer>().bounds.extents.magnitude;
            radius2 = puck.GetComponent<Renderer>().bounds.extents.magnitude;
            sumOfRadius = radius1 + radius2;
            if (distance <= sumOfRadius)
            {
               // puck.GetComponent<Rigidbody>().AddForce((direction) * 20, ForceMode.VelocityChange);
                puck.GetComponent<Rigidbody>().AddForce((direction) * hitForce, ForceMode.VelocityChange);
            }
        }
        else if (Vector3.Dot(this.transform.up, direction) < 0)
        {
            //this.transform.position += goalDirection * 2.0f * Time.deltaTime;
            this.transform.position += goalDirection * movingSpeed * Time.deltaTime;
        }
    }
    void Defence()
    {
        //this.transform.position += goalDirection * Time.deltaTime * 2.0f;
        this.transform.position += goalDirection * Time.deltaTime * movingSpeed;
        if (puck.transform.position.x > this.transform.position.x)
        {
            this.transform.position += Vector3.right * 1.0f * Time.deltaTime;
        }
        if (puck.transform.position.x < this.transform.position.x)
        {
            this.transform.position += -(Vector3.right * 1.0f * Time.deltaTime);
        }
    }
}
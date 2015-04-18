using System;
using UnityEngine;
using System.Collections;

public class ObjectPlacing : MonoBehaviour {

   
    public Transform malletUser;
    public Transform malletAI;
    public Transform table;
    public Transform puck;
    Vector3 center;
    Vector3 extents;
    public Camera camera;
    public static float maxX;
    public static float minX;
    public static float maxZ;
    public static float minZ;


    void Awake()
    {
        double cameraAspectRatio = Math.Round(camera.aspect, 2);
        center = this.GetComponent<Renderer>().bounds.center;
        extents = this.GetComponent<Renderer>().bounds.extents;
        Debug.Log("center" + center);
        Debug.Log("extent" + extents);

        if (cameraAspectRatio == 0.75)
        {
            Debug.Log("iPad Tall");
            malletUser.transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
            malletUser.transform.position = new Vector3(0, 0.5f, -3.5f);
            puck.transform.position = new Vector3(0, 0.113f, 0);
            maxX = center.x + extents.x - 0.6f;
            minX = center.x - extents.x + 0.6f;
            maxZ = center.z;
            minZ = center.z - extents.z + 0.7f;


        }
        else if (cameraAspectRatio == 0.67)
        {
            Debug.Log("iPhone Tall");
            malletUser.transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
            malletUser.transform.position = new Vector3(0, 0.05f, -3.5f);
            maxX = center.x + extents.x;// -0.6f;
            minX = center.x - extents.x;// +0.6f;
            maxZ = (center.z);
            minZ = center.z - extents.z + 0.7f;
            //Debug.Log("Max Z" + maxZ);
            //Debug.Log("Min Z" + minZ);
        }
        else if (cameraAspectRatio == 0.56)
        {
            Debug.Log("iPhone 5 Tall");
            malletUser.transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
            malletUser.transform.position = new Vector3(0, 0.05f, -3.5f);
            maxX = center.x + extents.x - 0.6f;
            minX = center.x - extents.x + 0.6f;
            maxZ = center.z;
            minZ = center.z - extents.z + 0.7f;
        }

    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

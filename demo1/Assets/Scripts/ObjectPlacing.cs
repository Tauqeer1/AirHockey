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
        Debug.Log(cameraAspectRatio);
        center = this.GetComponent<Renderer>().bounds.center;
        extents = this.GetComponent<Renderer>().bounds.extents;
        malletAI.transform.localScale = new Vector3(8.0f, 8.0f, 8.0f);
        malletUser.transform.localScale = new Vector3(8.0f, 8.0f, 8.0f);
        puck.transform.localScale = new Vector3(1.0f, 0.05f, 1.0f);

        if (cameraAspectRatio == 0.75)
        {
            Debug.Log("iPad Tall");
            malletUser.transform.position = new Vector3(0, 0.5f, -3.5f);
            puck.transform.position = new Vector3(0, 0.113f, 0);
            malletAI.transform.position = new Vector3(0, 0.113f, 2.82f);
            maxX = center.x + extents.x + 0.7f;
            minX = center.x - extents.x - 0.7f;
            maxZ = center.z;
            minZ = center.z - extents.z + 0.1f;
            
        }
        else if (cameraAspectRatio == 0.67)
        {
            Debug.Log("iPhone Tall");
            malletUser.transform.position = new Vector3(0, 0.05f, -3.5f);
            puck.transform.position = new Vector3(0, 0.113f, 0);
            maxX = center.x + extents.x + 0.3f;
            minX = center.x - extents.x - 0.3f;
            maxZ = (center.z);
            minZ = center.z - extents.z + 0.1f;
           
        }
        else if (cameraAspectRatio == 0.56)
        {
            Debug.Log("iPhone 5 Tall");
            malletUser.transform.position = new Vector3(0, 0.05f, -3.5f);
            malletAI.transform.position = new Vector3(0, 0.113f, 2.82f);
            puck.transform.position = new Vector3(0, 0.113f, 0);
            maxX = center.x + extents.x - 0.2f;
            minX = center.x - extents.x + 0.2f;
            maxZ = center.z;
            minZ = center.z - extents.z + 0.1f;
        }
        else if (cameraAspectRatio == 0.6)
        {
            Debug.Log("WVGA");
            malletUser.transform.position = new Vector3(0, 0.05f, -3.5f);
            malletAI.transform.position = new Vector3(0, 0.113f, 2.82f);
            maxX = center.x + extents.x + 0.3f;
            minX = center.x - extents.x - 0.3f;
            maxZ = (center.z);
            minZ = center.z - extents.z + 0.1f;
        }
        else if (cameraAspectRatio == 0.59)
        {
            Debug.Log("WSVGA");
            malletUser.transform.position = new Vector3(0, 0.05f, -3.5f);
            malletAI.transform.position = new Vector3(0, 0.113f, 2.82f);
            maxX = center.x + extents.x + 0.3f;
            minX = center.x - extents.x - 0.3f;
            maxZ = (center.z);
            minZ = center.z - extents.z + 0.1f;
        }
        else if (cameraAspectRatio == 0.62)
        {
            Debug.Log("WXGA");
            malletUser.transform.position = new Vector3(0, 0.05f, -3.5f);
            malletAI.transform.position = new Vector3(0, 0.113f, 2.82f);
            maxX = center.x + extents.x + 0.3f;
            minX = center.x - extents.x - 0.3f;
            maxZ = (center.z);
            minZ = center.z - extents.z + 0.1f;
        }

    }
}

using UnityEngine;
using System.Collections;

public class ScaleScript : MonoBehaviour {


    void Awake()
    {
        ResizeScreen();
    }

	// Use this for initialization
    //void Start () {
    //    ResizeScreen();
    //}


    void ResizeScreen()
    {
        Renderer sr = GetComponent<Renderer>();
        if (sr == null)
        {
            return;
        }
        transform.localScale = new Vector3(1, 1, 1);
        float width = sr.bounds.extents.x;
        float height = sr.bounds.extents.z;

        float worldScreenHeight = Camera.main.orthographicSize * 2.0f;// *2.0f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        float x = worldScreenWidth / width;
        float z = worldScreenHeight / height;

        float xScaled = x / 2f;
        float zScaled = z / 2f;
        transform.localScale = new Vector3(x / 2f, 0.5f, z / 2f);
        Debug.Log("X-Scaled" + x / 2f);
        Debug.Log("Z-Scaled" + z / 2f);

        
        

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

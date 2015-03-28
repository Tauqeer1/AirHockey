using UnityEngine;
using System.Collections;

public class RestartScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Restart()
    {
        Application.LoadLevel("GameScene");
    }
    public void Quit()
    {
        Application.Quit();
    }
}

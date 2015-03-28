using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour {

	public Canvas LoadingCanvas;
	public Canvas MainMenuCanvas;
    public Canvas AiCanvas;
    public static int hitForce;
    public static float  movingSpeed;
	void Awake()
	{
		LoadingCanvas.enabled = true;
		MainMenuCanvas.enabled = false;
        AiCanvas.enabled = false;
	}
	// Use this for initialization
	IEnumerator Start () {
		
		yield return new WaitForSeconds(5);
		
		LoadingCanvas.enabled = false;
		MainMenuCanvas.enabled = true;	
	}
	public void OnePlayer()
	{
        MainMenuCanvas.enabled = false;
        AiCanvas.enabled = true;
	}

    public void AIEasy()
    {
        hitForce = 10;
        movingSpeed = 2.0f;
        Application.LoadLevel("GameScene");
        
    }
    public void AIMedium()
    {
        hitForce = 20;
        movingSpeed = 3.0f;
        Application.LoadLevel("GameScene");
    }
    public void AIHard()
    {
        hitForce = 25;
        movingSpeed = 4.0f;
        Application.LoadLevel("GameScene");
    }
	// Update is called once per frame
	void Update () {
        
	}
}	

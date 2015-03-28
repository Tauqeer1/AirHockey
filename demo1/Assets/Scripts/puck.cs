using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class puck : MonoBehaviour {

    public Canvas scoringCanvas;
    public Canvas winningCanvas;
    public Text winningText;
	int userScore = 0;
	int computerScore = 0;
	public Text userText;
	public Text computerText;
	string yourStr = "Your Score : ";
	string computerStr = "Computer Score : ";
    public Transform userMallet;
    public Transform aiMallet;
	
	// Use this for initialization
	void Start () {

        winningCanvas.enabled = false;
		userText.text = yourStr + userScore.ToString();
		computerText.text = computerStr + computerScore.ToString();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider colObject)
	{
		if (colObject.gameObject.name == "UserGoal")
		{
			computerScore++;
			
			computerText.text = computerStr + computerScore.ToString();
			
			if (computerScore == 7)
			{
                winningCanvas.enabled = true;
                winningText.text = "Computer win";
				//Debug.Log("Computer Win");
				//Application.LoadLevel("WinningScene");
				computerScore = 0;
			}
			puckReset();
			
		}
		else if (colObject.gameObject.name == "ComputerGoal")
		{
			userScore++;
			userText.text = yourStr + userScore.ToString();
			if (userScore == 7)
			{
                winningCanvas.enabled = true;
                winningText.text = "You Win";
                //Debug.Log("User Win");
                //Application.LoadLevel("WinningScene");
				userScore = 0;
			}
			puckReset();
		}
	}
	void puckReset()
	{
		this.transform.position = new Vector3(0, 0.15f, 0);
		this.GetComponent<Rigidbody>().velocity = Vector3.zero;

        userMallet.transform.position = new Vector3(0, 0.08f, -3.44f);
        aiMallet.transform.position = new Vector3(0, 0.07f, 3.56f);
	}
}

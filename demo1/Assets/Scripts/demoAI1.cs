using UnityEngine;
using System.Collections;

public class demoAI1 : MonoBehaviour {


    float elapsedTime = 0.0f;
    bool doneCounting = false;
    bool timeStarted = false;
    float startTime;
    int counter;
    int maxCounter = 250;
	// Use this for initialization
	void Start () {
        startTime = Time.time;
        StartCoroutine(Counter());
	}
	
	// Update is called once per frame
    //void Update()
    //{

    //    if (!timeStarted)
    //    {
    //        timeStarted = true;
    //        startTime = Time.time;
    //    }
    //    if (doneCounting == false)
    //    {
    //        counter++;
    //        if (counter == maxCounter)
    //        {
    //            doneCounting = true;
    //            elapsedTime = Time.time - startTime;
    //            Debug.Log("Elapsed Time" + elapsedTime);
    //        }

    //    }

    //}
    public IEnumerator Counter()
    {
        while (counter <= maxCounter)
        {
            counter++;
            yield return new WaitForEndOfFrame();
        }
        elapsedTime = Time.time - startTime;
        Debug.Log("Elapsed Time" + elapsedTime);
    }
}

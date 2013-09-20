using UnityEngine;
using System.Collections;

public class CameraFollower : MonoBehaviour 
{
	public Transform target;
	public float scenarioMinValue = 0f;
	public float scenarioMaxValue = 300f;
	float myXPos;
	float newXPos;
	
	// Use this for initialization
	void Start () 
	{
		myXPos = this.transform.position.x;
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		if(!target) return;
		
		newXPos = target.transform.position.x;
		newXPos = Mathf.Clamp(newXPos, scenarioMinValue, scenarioMaxValue);
		if(newXPos != myXPos)
		{
			myXPos = newXPos;
			MoveCamera();		
		}
	}
	void MoveCamera()
	{
		transform.position = new Vector3(myXPos,transform.position.y,transform.position.z);
	}
}

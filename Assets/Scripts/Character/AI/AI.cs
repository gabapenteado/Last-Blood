using UnityEngine;
using System.Collections;

public class AI {

	private Character myCharacter;
	private Character target;
	private Vector3 direction = Vector3.left;
	public AI(Character pMyCharacter, Character pTarget)
	{
		myCharacter = pMyCharacter;
		target = pTarget;
	}
	
	public ActionObject MakeDecision(Character pTarget)
	{
		target = pTarget;
		
		Vector3 fwd = myCharacter.transform.TransformDirection(Vector3.left);
        if (Physics.Raycast(myCharacter.transform.position, fwd, 10))
		{
			Debug.Log("There is something in front of the object!");
			Debug.DrawLine(myCharacter.transform.position, new Vector3(myCharacter.transform.position.x-10, myCharacter.transform.position.y, myCharacter.transform.position.z));
		}
		/*
		if (myCharacter.transform.position.x < -22)
		{
			direction = Vector3.right;
			myCharacter.TakeDamage(1, false);
		}
		else if (myCharacter.transform.position.x > 22)
		{
			direction = Vector3.left;
			myCharacter.TakeDamage(1, false);
		}
		*/
		float distance = Vector3.Distance (myCharacter.transform.position, target.transform.position);
		bool willAttack = false;
		if (distance < 4)
		{
			willAttack = true;
		}
		return new ActionObject(willAttack, direction);
	}
}

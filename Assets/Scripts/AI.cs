using UnityEngine;
using System.Collections;

public class AI {

	private Character myCharacter;
	private Character fortress;
	private Vector3 direction = Vector3.left;
	public AI(Character pMyCharacter, Character pFortress)
	{
		myCharacter = pMyCharacter;
		fortress = pFortress;
	}
	
	public ActionObject MakeDecision()
	{
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
		float distance = Vector3.Distance (myCharacter.transform.position, fortress.transform.position);
		bool willAttack = false;
		if (distance < 4)
		{
			willAttack = true;
		}
		return new ActionObject(willAttack, direction);
	}
}

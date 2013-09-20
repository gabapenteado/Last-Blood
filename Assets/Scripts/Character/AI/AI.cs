using UnityEngine;
using System.Collections;

public class AI {

	private NPC myCharacter;
	private Character target;
	private Vector3 direction = Vector3.left;
	public AI(NPC pMyCharacter, Character pTarget)
	{
		myCharacter = pMyCharacter;
		target = pTarget;
	}
	
	public ActionObject MakeDecision(Character pTarget)
	{
		target = pTarget;
		Character closer = null;
		float distCloser = 0;
		float distNext;
		Debug.Log(GameController.instance());
		for (int i=0; i<GameController.instance().activeAllies.Length;i++)
		{
			
			if (closer == null)
			{
				closer = GameController.instance().activeAllies[i];
			}
			else
			{
				distCloser = Vector3.Distance (myCharacter.transform.position, closer.transform.position);
				distNext = Vector3.Distance (myCharacter.transform.position, GameController.instance().activeAllies[i].transform.position);
				
				if (distCloser < distNext)
				{
					closer = GameController.instance().activeAllies[i];
				}
			}
		}
		if (distCloser <= myCharacter.vision)
		{
			Vector3 heading = closer.transform.position - myCharacter.transform.position;
			direction = heading/distCloser;
		}
		
       
		//float distance = Vector3.Distance (myCharacter.transform.position, target.transform.position);
		bool willAttack = false;
		if (distCloser < myCharacter.range)
		{
			willAttack = true;
		}
		return new ActionObject(willAttack, direction);
	}
}

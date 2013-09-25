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
		
		for (int i=0; i<GameController.instance().activeAllies.Count;i++)
		{
			
			if (closer == null)
			{
				
				closer = (Character)GameController.instance().activeAllies[i];
				distCloser = Utility.HorizontalDistance(myCharacter.transform.position, closer.transform.position);
			}
			else
			{
				target = (Character)GameController.instance().activeAllies[i];				
				distCloser = Utility.HorizontalDistance(myCharacter.transform.position, closer.transform.position);
				distNext = Utility.HorizontalDistance(myCharacter.transform.position, target.transform.position);
				if (distCloser > distNext)
				{
					closer = (Character)GameController.instance().activeAllies[i];
					myCharacter.target = target;
					distCloser = distNext;
				}
				else
				{
					target = closer;
					myCharacter.target = target;
				}
			}
			
		}
		if (distCloser <= myCharacter.vision)
		{
			Vector3 heading = closer.transform.position - myCharacter.transform.position;
			direction = heading/distCloser;
			if ( distCloser<= myCharacter.range)
			{
				direction = Vector3.zero;	
			}
			
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

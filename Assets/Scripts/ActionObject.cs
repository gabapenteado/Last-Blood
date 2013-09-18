using UnityEngine;
using System.Collections;

public class ActionObject {
	
	public bool willAttack;
	public Vector3 moveDirection;
	
	public ActionObject(bool pWillattack, Vector3 pMoveDirection)
	{		
		willAttack = pWillattack;
		moveDirection = pMoveDirection;
	}
}

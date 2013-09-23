﻿using UnityEngine;
using System.Collections;

public class NPC : Character {
	
	public AI aiObject;
	public float vision;
	public float range;
	
	
	public ActionObject GetAction(AI pAI)
	{
		return pAI.MakeDecision(target);
	}
	
	public void PerformAIAction(ActionObject pActionObject)
	{
		if (!pActionObject.willAttack)
		{
			Move(pActionObject.moveDirection, speed);
		}
		else{
			
			if ((baseAttack.cooldown + baseAttack.lastTimeUsed)<Time.time)
			{
				UseSkill(baseAttack);
			}
		}
	}
	
	// Use this for initialization
	void Start () {
		range = 40;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
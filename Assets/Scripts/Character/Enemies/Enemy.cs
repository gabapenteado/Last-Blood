using UnityEngine;
using System.Collections;

public class Enemy : NPC {
	
	
	private int xpValue;
	private EnemyType myType;
	private float lastAICheck = 0;
	private float delay = 0.5f;
	private ActionObject lastAction;
	void Awake()
	{
		speed = 50;
		health = 10;
		skillStrength = 1;
		aiObject = new AI(this, target);
		baseAttack = GameObject.FindGameObjectWithTag("Slash");
		//baseAttack.Init(this);
		vision = 50;
	}
	
	void Update()
	{
		
		if (health >0 /*&& Time.time > (lastAICheck + delay)*/)
		{
			//Debug.Log("lastAction :"+lastAction + " : " + Time.time + " : " + lastAICheck);
			if (lastAction == null || (Time.time > (lastAICheck + delay)))
			{
				lastAction = GetAction(aiObject);
				lastAICheck = Time.time;
			}			
			
			PerformAIAction(lastAction);	
		}
		
	}
}

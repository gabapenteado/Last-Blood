using UnityEngine;
using System.Collections;

public class Enemy : NPC {
	
	
	private int xpValue;
	private EnemyType myType;
	
	void Awake()
	{
		speed = 50;
		health = 10;
		skillStrength = 1;
		aiObject = new AI(this, target);
		baseAttack = new BaseAttack();
		baseAttack.Init(this);
		vision = 50;
	}
	
	void Update()
	{
		if (health >0)
		{
			PerformAIAction(GetAction(aiObject));	
		}
		
	}
}

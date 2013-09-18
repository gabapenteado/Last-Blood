using UnityEngine;
using System.Collections;

public class Enemy : NPC {
	
	public Character fortress;
	private int xpValue;
	private EnemyType myType;
	
	void Awake()
	{
		speed = 5;
		health = 10;
		aiObject = new AI(this, fortress);	
	}
	
	void Update()
	{
		if (health >0)
		{
			PerformAIAction(GetAction(aiObject));	
		}
		
	}
}

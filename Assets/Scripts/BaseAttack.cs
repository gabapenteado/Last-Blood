using UnityEngine;
using System.Collections;

public class BaseAttack : Skill {

	public int cooldownLevel;
	public int damageLevel;
	public int lifestealLevel;
	
	public BaseAttack()
	{
		cooldownLevel = 1;
		damageLevel = 1;
		lifestealLevel = 1;
		damageMultiplier = 1;
		baseDamage = 0;
		cooldown = 2;
		cost = 0;
		causesKnockback = false;
		lastTimeUsed = 0;
	}
	
	
}

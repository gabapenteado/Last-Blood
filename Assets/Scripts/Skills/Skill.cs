using UnityEngine;
using System.Collections;

public class Skill {

	public float damageMultiplier;
	public float baseDamage;
	public float cooldown;
	public float cost;
	public bool causesKnockback;
	public float lastTimeUsed;
	
	public float CalculateDamage(float pStrength)
	{
		float damage = (pStrength * damageMultiplier) + baseDamage;
		return 	damage;
	}
	public float CalculateCooldown()
	{
		return 0;
	}
	public int CalculateCost()
	{
		return 0;
	}
}

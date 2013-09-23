using UnityEngine;
using System.Collections;

public class Skill {

	public float damageMultiplier;
	public float baseDamage;
	public float cooldown;
	public float cost;
	public bool causesKnockback;
	public float lastTimeUsed;
	
	public string myAnimationName;
	
	public Character myCharacter;
	
	public void Init(Character pCharacter)
	{
		myCharacter = pCharacter;
	}
	
	public float CalculateDamage(float pStrength)
	{
		float damage = (pStrength * damageMultiplier) + baseDamage;
		return 	damage;
	}
	
	public float CalculateCooldown()
	{
		return cooldown + lastTimeUsed - Time.time;
	}
	
	public int CalculateCost()
	{
		return 0;
	}
	
	public void Use()
	{
		lastTimeUsed = Time.time;
		myCharacter.state = STATE.Attacking;
		myCharacter.PlayAnimation(myAnimationName);
		myCharacter.skillAnimationName = myAnimationName;
	}
}

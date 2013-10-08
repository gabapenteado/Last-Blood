using UnityEngine;
using System.Collections;

public class BaseAttack : Skill {

	public int cooldownLevel;
	public int damageLevel;
	public int lifestealLevel;
	
	private GameObject slash;
	
	public BaseAttack()
	{
		cooldownLevel = 1;
		damageLevel = 1;
		lifestealLevel = 1;
		damageMultiplier = 1;
		baseDamage = 0;
		cooldown = 1;
		cost = 0;
		causesKnockback = false;
		lastTimeUsed = 0;
		
		myAnimationName = "Attack";
		//slash = GameObject.FindGameObjectWithTag("Slash");
	}
	
	public void Use(Transform _transform)
	{
		base.Use(_transform);
		
		//GameObject effect = (GameObject)Instantiate(this.gameObject,new Vector3(_transform.position.x,transform.position.y + 40, _transform.position.z - 100),Quaternion.identity);
		//willDie = true;
		//effect.transform.localScale = this.transform.localScale;
		
	}
	
	
	
}

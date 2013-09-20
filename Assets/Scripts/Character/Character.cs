using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	public int health;
	public int speed;
	public string name;
	public float skillStrength;
	public CharacterController controller;
	//animation controller
	public LayerMask hitEnabledLayers;
	//Skills
	public BaseAttack baseAttack;
	private Vector3 moveDirection;
	public Character target;
	
	private float lastDirection;
	
	public STATE state { get; set; }
	
	void Awake()
	{
		
			
	}
	
	public void Update()
	{
		UpdateAnimation();
	}
	
	virtual public void UpdateAnimation()
	{
		switch(state)
		{
			case STATE.Standing:
				
			break;
			case STATE.Running:
				
			break;
		}
	}
	
	public void Move(Vector3 pMoveDirection, int pSpeed)
	{
		state = STATE.Running;
		//controller.Move((pMoveDirection.normalized) * pSpeed * Time.deltaTime);
		
		transform.position += (pMoveDirection.normalized) * pSpeed * Time.deltaTime;
		
		ClampScenarioLimits();
		
		if(Mathf.Sign(lastDirection) != Mathf.Sign(pMoveDirection.x))
		{
			transform.localScale = new Vector3(transform.localScale.x*-1,transform.localScale.y,transform.localScale.z);
		}
		
		lastDirection = pMoveDirection.x;
	}
	
	public void ClampScenarioLimits()
	{
		transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y,-65,0), transform.position.z);
	}
	
	public void TakeDamage(int pDamage, bool pKnockBack)
	{
		health-=pDamage;
		/*
		if (health <= 0)
		{
			Kill ();
		}
		*/
	}
	
	public virtual void Kill()
	{
		/*
		State = STATE.Dying;
		Debug.Log("kill super");	
	    */
	}
	
	public void UseSkill(Skill pSkill)
	{
		Debug.Log("Atacou");
		state = STATE.Attacking;
		pSkill.lastTimeUsed = Time.time;
		target.health-=(int)pSkill.CalculateDamage(skillStrength);
		if (target.health <=0)
		{
			target.Kill();
			//fortress.LooseGame();
		}
	}
}

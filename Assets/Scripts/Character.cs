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
	public enum STATE
	{
		Standing,
		Running,
		Attacking,
        Dying
	}
	
	public STATE State { get; set; }
	
	void Awake()
	{
		
			
	}
	
	void Update()
	{
		
	}
	
	public void Move(Vector3 pMoveDirection, int pSpeed)
	{
		State = STATE.Running;
		controller.Move(pMoveDirection * pSpeed * Time.deltaTime);
		
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
		State = STATE.Attacking;
		pSkill.lastTimeUsed = Time.time;
		target.health-=(int)pSkill.CalculateDamage(skillStrength);
		if (target.health <=0)
		{
			target.Kill();
			//fortress.LooseGame();
		}
	}
}

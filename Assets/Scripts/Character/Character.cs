using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	
	
	public float health;
	public float maxHealth;
	public int speed;
	public string name;
	public float skillStrength;
	public CharacterController controller;
	//animation controller
	public LayerMask hitEnabledLayers;
	//Skills
	public Skill[] skills;

	public GameObject baseAttack;
	public GameObject baseAttackIns;
	private Vector3 moveDirection;
	public Character target;
	
	private float lastDirection;
	
	public STATE state { get; set; }
	
	public string skillAnimationName;
	
	protected bool isEnemy;
	
	void Awake()
	{
		
			
	}
	
	public void Update()
	{
		CheckAttackAnimation();
		UpdateAnimation();
	}
	
	virtual public void CheckAttackAnimation()
	{
		//if(skillAnimationName
	}
	
	virtual public void UpdateAnimation()
	{
		switch(state)
		{
			case STATE.Standing:
				PlayAnimation("Idle");
			break;
			case STATE.Running:
				PlayAnimation("Walk");
			break;	
			case STATE.Dying:
				PlayAnimation("Death");
			break;
		}
		Debug.Log(state);
	}
	
	public void Move(Vector3 pMoveDirection, int pSpeed)
	{
		state = STATE.Running;
		//controller.Move((pMoveDirection.normalized) * pSpeed * Time.deltaTime);
		
		transform.position += (pMoveDirection.normalized) * pSpeed * Time.deltaTime;
		transform.position += new Vector3(0, 0, pMoveDirection.normalized.y/10 * pSpeed * Time.deltaTime);
		ClampScenarioLimits();
		
		if(Mathf.Sign(lastDirection) != Mathf.Sign(pMoveDirection.x))
		{
			transform.localScale = new Vector3(transform.localScale.x*-1,transform.localScale.y,transform.localScale.z);
		}
		
		lastDirection = pMoveDirection.x;
	}
	
	public void ClampScenarioLimits()
	{
		transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y,-65,0), Mathf.Clamp(transform.position.z,540f,546.5f));
	}
	
	public void TakeDamage(int pDamage, bool pKnockBack)
	{
		health-=pDamage;
		
		DamageFeedback _feedback = Instantiate(GameGUI.instance.damageFeedback,transform.position+Vector3.up*60,Quaternion.identity) as DamageFeedback;
		
		_feedback.Init(pDamage, isEnemy,transform);
		
		if (health <= 0)
		{
			Kill ();
		}		
	}
	
	public virtual void Kill()
	{
		/*
		State = STATE.Dying;
		Debug.Log("kill super");	
	    */
	}
	
	virtual public void PlayAnimation(string pAnimationName)
	{
		//Esse override existe pra poder usar bem os dois sistemas do toolkit e do smooth moves
	}
	
	public void UseSkill(Skill pSkill)
	{
		if(pSkill.CalculateCooldown() > 0)
		{
			return;
		}
		

		pSkill.Use(this.transform);
		
		//teste de ataque
		if (target != null)
		{
			target.TakeDamage((int)pSkill.CalculateDamage(skillStrength), pSkill.causesKnockback);
		}
	}
}

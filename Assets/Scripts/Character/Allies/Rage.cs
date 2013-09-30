using UnityEngine;
using System.Collections;
using SmoothMoves;

public class Rage : Character {
	
	static public Rage instance;
	public BoneAnimation boneAnimation;
	
	public float currentRage;
	public float maximumRage;
	public float rebirthTime;
	
	
	public void Awake()
	{
		instance = this;
		transform.localScale = new Vector3(transform.localScale.x*-1,transform.localScale.y,transform.localScale.z);
		
		maxHealth = 200;
		health = maxHealth;
		
		maximumRage = 200;
		currentRage = maximumRage;
		
		rebirthTime = 5f;
		
		CreateSkills();
	}
	
	public void Start()
	{
		StartSkillTab();
	}
	
	public void Update()
	{
		CheckMovement();
		
		base.Update();
	}
	
	public void CreateSkills()
	{
		skills = new Skill[4];
		for(int i = 0; i < skills.Length; i ++)
		{
			skills[i] = new BaseAttack();
			skills[i].Init(this);
		}		
	}
	
	public void StartSkillTab()
	{
		for(int i = 0; i < skills.Length; i ++)
		{
			SkillTab.instance.InitSkills(skills[i],i);
		}	
	}
	
	public void CheckMovement()
	{
		if(state != STATE.Attacking && state != STATE.Knocked && state != STATE.Dying)
		{
			if(Joystick.instance.GetValue().magnitude > 0.2)
			{
				Move(Joystick.instance.GetValue(), speed);
			}else
			{
				state = STATE.Standing;
			}
		}
	}
	
	override public void CheckAttackAnimation()
	{
		if(state != STATE.Attacking)
		{
			return;
		}
		
		if(!boneAnimation.IsPlaying(skillAnimationName))
		{
			state = STATE.Standing;
		}
	}
	
	public override void PlayAnimation(string pSkill)
	{
		boneAnimation.CrossFade(pSkill);
	}
	public override void Kill()
	{			
		StartCoroutine(Rebirth());
	}
	IEnumerator Rebirth()
	{
		GameController.instance().activeAllies.Remove(Rage.instance);
		state = STATE.Dying;
		yield return new WaitForSeconds(rebirthTime);
		health = maxHealth;
		currentRage = maximumRage;
		state = STATE.Standing;
		GameController.instance().activeAllies.Add(Rage.instance);
		transform.position = Fortress.instance.transform.position;		
		yield break;
	}
}

using UnityEngine;
using System.Collections;
using SmoothMoves;

public class Rage : Character {
	
	static public Rage instance;
	public BoneAnimation boneAnimation;
	
	
	public void Awake()
	{
		instance = this;
		transform.localScale = new Vector3(transform.localScale.x*-1,transform.localScale.y,transform.localScale.z);
		
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
		if(state != STATE.Attacking && state != STATE.Knocked)
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
}

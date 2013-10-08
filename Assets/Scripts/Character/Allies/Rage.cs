using UnityEngine;
using System.Collections;
using SmoothMoves;

public class Rage : Character {
	
	static public Rage instance;
	public BoneAnimation boneAnimation;
	
	public float currentRage;
	public float maximumRage;
	public float rebirthTime;
	
	private Skill skill;
	private DestroyAfterAnim comp;
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
		baseAttack = GameObject.FindGameObjectWithTag("Slash");
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
		if(pSkill != "Death")
		{
			boneAnimation.Stop("Death");
			boneAnimation.CrossFade(pSkill);
		}else{boneAnimation.Play(pSkill);}
		if(pSkill == "Attack")
		{
			Collider[] enemies = Physics.OverlapSphere(transform.position, 30f);
			int i = 0;
			while(i < (enemies.Length))
			{			
				if((transform.position.y - enemies[i].transform.position.y) < 7f || (enemies[i].transform.position.y - transform.position.y) < 7f)
				{
					if (enemies[i].name != "Rage")
					{
						Enemy enemy = enemies[i].GetComponent<Enemy>();
						
						enemy.TakeDamage((int)skills[0].CalculateDamage(skillStrength), false);					
						Debug.Log("Do Dmg on " + enemies[i].name);
					}
				}
				i++;
			}
		}
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

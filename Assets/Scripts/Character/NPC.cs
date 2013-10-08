using UnityEngine;
using System.Collections;

public class NPC : Character {
	
	public AI aiObject;
	public float vision;
	public float range;
	//public GameObject baseAttackVFX;
	
	private Skill skill;
	private DestroyAfterAnim comp;
	public tk2dSpriteAnimator spriteAnimator;
	
	void Awake()
	{
		Debug.Log("awake");
		
	}
	
	public ActionObject GetAction(AI pAI)
	{
		return pAI.MakeDecision(target);
	}
	
	public void PerformAIAction(ActionObject pActionObject)
	{
		if (!pActionObject.willAttack)
		{
			PlayAnimation("Walk");
			Move(pActionObject.moveDirection, speed);
		}
		else{
			//Debug.Log("verificando skill: " + skill);
			if (skill == null)
			{
				//Debug.Log("iniciando uma nova");
				GetSkill();
			}
			
			//if ((baseAttack.cooldown + baseAttack.lastTimeUsed)<Time.time)
			//Debug.Log("verificando o cooldown: " + skill.cooldown + " : " + skill.lastTimeUsed);
			if ((skill.cooldown + skill.lastTimeUsed)<Time.time)
			{
				//Debug.Log("chamando a skill");
				UseSkill(skill);
//				baseAttackIns.animation.Play();
				GetEffect();
				StartCoroutine(StartEfect());
				
				
				if (this.transform.position.x > target.transform.position.x)
				{
					baseAttackIns.transform.rotation = new Quaternion(0,180,0,0);
				}
			}
		}
	}
	
	public override void PlayAnimation(string pAnimationName)
	{
		spriteAnimator.Play(spriteAnimator.GetClipByName(pAnimationName));
		if(pAnimationName == "Death") state = STATE.Dead;
		//if(spriteAnimator.CurrentClip.name == "Attack")StartCoroutine(InstantiateVFX());			
	}
	
	// Use this for initialization
	void Start () {
		range = 30;
	}
	
	Skill GetSkill()
	{	
		/*
		skill = baseAttackIns.GetComponent("BaseAttack") as Skill;
		*/
		skill = new BaseAttack();
		
		skill.Init(this);
		return skill;
	}
	
	void GetEffect()
	{
		baseAttackIns = (GameObject)Instantiate(baseAttack,new Vector3(this.transform.position.x+1000,this.transform.position.y + 40, this.transform.position.z - 100),Quaternion.identity);
		//baseAttackIns = (GameObject)Instantiate(baseAttack);
	}
	
	IEnumerator StartEfect()
	{
		yield return new WaitForSeconds(0.7f);
		baseAttackIns.transform.position = new Vector3(this.transform.position.x,this.transform.position.y + 40, this.transform.position.z - 100);
		tk2dSpriteAnimator sa = baseAttackIns.GetComponent("tk2dSpriteAnimator") as tk2dSpriteAnimator;
		sa.Play();
		comp = baseAttackIns.GetComponent("DestroyAfterAnim") as DestroyAfterAnim;
		comp.willDie = true;
		comp.played = true;
	}
	public override void Kill()
	{			
		state = STATE.Dying;
		this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 989);
	}
}

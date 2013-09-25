using UnityEngine;
using System.Collections;

public class NPC : Character {
	
	public AI aiObject;
	public float vision;
	public float range;
	
	public tk2dSpriteAnimator spriteAnimator;
	
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
			if ((baseAttack.cooldown + baseAttack.lastTimeUsed)<Time.time)
			{
				UseSkill(baseAttack);
			}
		}
	}
	
	public override void PlayAnimation(string pAnimationName)
	{
		spriteAnimator.Play(spriteAnimator.GetClipByName(pAnimationName));
	}
	
	// Use this for initialization
	void Start () {
		range = 30;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

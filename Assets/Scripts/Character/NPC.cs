using UnityEngine;
using System.Collections;

public class NPC : Character {
	
	public AI aiObject;
	public float vision;
	public float range;
	public GameObject baseAttackVFX;
	
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
		if(spriteAnimator.CurrentClip.name == "Attack")StartCoroutine(InstantiateVFX());			
	}
	
	// Use this for initialization
	void Start () {
		range = 30;
	}
	
	IEnumerator InstantiateVFX()
	{
		yield return new WaitForSeconds(0.5f);
		if(baseAttackVFX)
		{
			GameObject effect = (GameObject)Instantiate(baseAttackVFX,new Vector3(transform.position.x,transform.position.y + 40, transform.position.z - 100),Quaternion.identity);
			effect.transform.localScale = this.transform.localScale;			
		}
		yield return null;
	}
}

using UnityEngine;
using System.Collections;

public class SkillButton : MonoBehaviour {

	public UISprite slicedSprite;
	public UILabel timeLabel;
	public Skill mySkill;
	
	private float myCurrentCooldown;
	
	public void Init(Skill pSkill)
	{
		mySkill = pSkill;
	}
	
	public void Update()
	{
		myCurrentCooldown = mySkill.CalculateCooldown();
		
		if(myCurrentCooldown > 0)
		{
			timeLabel.text = myCurrentCooldown.ToString("f1");
			
			slicedSprite.fillAmount = myCurrentCooldown/mySkill.cooldown;
			
		}else
		{
			timeLabel.text = "";
			slicedSprite.fillAmount = 0;
		}
	}
	
	public void StartTouch()
	{
		Rage.instance.UseSkill(mySkill);
	}
}

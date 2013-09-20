using UnityEngine;
using System.Collections;

public class SkillButtonReceiver : MonoBehaviour {
	
	public SkillButton mySkillButton;
	
	public void OnPress()
	{
		mySkillButton.StartTouch();
	}
}

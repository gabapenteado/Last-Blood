using UnityEngine;
using System.Collections;

public class SkillTab : MonoBehaviour {

	static public SkillTab instance;
	public SkillButton[] skills;
	
	public void Awake()
	{
		instance = this;
	}
	
	public void InitSkills(Skill pSkill, int index)
	{
		skills[index].Init(pSkill);
	}
}

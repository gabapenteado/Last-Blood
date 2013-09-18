using UnityEngine;
using System.Collections;

public class NPC : Character {
	
	public AI aiObject;
	private float vision;
	private float range;
	
	
	public ActionObject GetAction(AI pAI)
	{
		return pAI.MakeDecision();
	}
	
	public void PerformAIAction(ActionObject pActionObject)
	{
		if (!pActionObject.willAttack)
		{
			Move(pActionObject.moveDirection, speed);
		}
		else{
			Debug.Log("Atacou");
			UseSkill(new BaseAttack());	
		}
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

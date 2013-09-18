using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	public int health;
	public int speed;
	public string name;
	public float skillStrength;
	public CharacterController controller;
	//animation controller
	public LayerMask hitEnabledLayers;
	//Skills
	
	private Vector3 moveDirection;
	
	public enum STATE
	{
		Standing,
		Running,
		Attacking,
        Dying
	}
	
	public STATE State { get; set; }
	
	void Awake()
	{
		
			
	}
	
	void Update()
	{
		
	}
	
	public void Move(Vector3 pMoveDirection, int pSpeed)
	{
		controller.Move(pMoveDirection * pSpeed * Time.deltaTime);
		
	}
	
	public void TakeDamage(int pDamage, bool pKnockBack)
	{
		health-=pDamage;
		/*
		if (health <= 0)
		{
			Kill ();
		}
		*/
	}
	
	public void Kill()
	{
		Debug.Log("kill super");	
	}
	
	public void UseSkill(Skill pSkill)
	{
		
	}
}

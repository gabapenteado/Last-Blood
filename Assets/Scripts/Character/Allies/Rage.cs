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
	}
	
	public void Update()
	{
		CheckMovement();
		
		base.Update();
	}
	
	public void CheckMovement()
	{
		if(Joystick.instance.GetValue().magnitude > 0.2)
		{
			Move(Joystick.instance.GetValue(), speed);
		}else
		{
			state = STATE.Standing;
		}
	}
	
	public override void  UpdateAnimation()
	{
		switch(state)
		{
			case STATE.Standing:
				boneAnimation.CrossFade("Stand");
			break;
			case STATE.Running:
				boneAnimation.CrossFade("Run");
			break;
		}
	}
}

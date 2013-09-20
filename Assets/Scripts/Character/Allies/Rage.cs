using UnityEngine;
using System.Collections;

public class Rage : Character {
	
	static Rage instance;
	
	public void Awake()
	{
		instance = this;
	}
	
	public void Update()
	{
		Move(Joystick.instance.GetValue(), speed);
	}
}

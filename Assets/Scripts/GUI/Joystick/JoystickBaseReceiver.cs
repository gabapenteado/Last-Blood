using UnityEngine;
using System.Collections;

public class JoystickBaseReceiver : MonoBehaviour {

	public void OnPress()
	{
		Joystick.instance.StartTouch();
	}
}

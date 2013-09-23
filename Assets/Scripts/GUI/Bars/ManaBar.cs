using UnityEngine;
using System.Collections;

public class ManaBar : MonoBehaviour {
	
	public UISprite myBar;
	
	void Update ()
	{
		myBar.fillAmount = Rage.instance.currentRage/Rage.instance.maximumRage;
	}
}

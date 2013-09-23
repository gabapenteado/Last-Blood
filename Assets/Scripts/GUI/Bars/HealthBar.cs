using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
	
	public UISprite myBar;
	
	void Update ()
	{
		myBar.fillAmount = Rage.instance.health/Rage.instance.maxHealth;
	}
}

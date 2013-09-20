using UnityEngine;
using System.Collections;

public class Joystick : MonoBehaviour {
	
	static public Joystick instance;
	public Transform thumb;
	
	private float maxOffset;
	
	private bool isPressed;
	
	//private var JoystickState state;
	
	private Vector3 lastInputPosition;
	
	public void Awake ()
	{
		instance = this;
		
		maxOffset = 35;
	}
	
	public void StartTouch()
	{
		isPressed = true;
		
		ResetInputPosition();
	}
	
	public void StopTouching()
	{
		isPressed = false;
	}
	
	public bool CheckForInputs()
	{
		if(Application.isEditor)
		{
			if(Input.GetKeyUp(KeyCode.Mouse0))
			{
				return false;
			}
		}else
		{
			if(Input.touchCount == 0)
			{
				return false;
			}
		}
		
		return true;
	}
	
	public void UpdateThumbPosition()
	{
		Vector3 inputDelta;
		Vector3 newPosition;
		
		if(Application.isEditor)
		{
			
			inputDelta = Input.mousePosition - lastInputPosition;
			
		}else
		{
			inputDelta = new Vector3(Input.GetTouch(0).position.x,Input.GetTouch(0).position.y,0) - lastInputPosition;	
		}
		
		newPosition = new Vector3(Mathf.Clamp(thumb.localPosition.x + inputDelta.x, -maxOffset, maxOffset), Mathf.Clamp(thumb.localPosition.y + inputDelta.y, -maxOffset, maxOffset),0);
		
		thumb.localPosition = newPosition;
		
		
		ResetInputPosition();
	}
	
	public void ResetInputPosition()
	{
		
		if(Application.isEditor)
		{
			
			lastInputPosition = Input.mousePosition;
			
		}else
		{
			
			lastInputPosition = Input.GetTouch(0).position;
			
		}
		
	}
	
	void Update ()
	{
		if(isPressed)
		{
			if(CheckForInputs())
			{
				UpdateThumbPosition();
			}else
			{
				StopTouching();
			}
			
		}else
		{
			thumb.localPosition = Vector3.zero;
		}
	}
	
	public float GetXValue()
	{
		return thumb.localPosition.x/maxOffset;
	}
	
	public float GetYValue()
	{
		return thumb.localPosition.y/maxOffset;
	}
	
	public Vector3 GetValue()
	{
		return thumb.localPosition/maxOffset;
	}
}

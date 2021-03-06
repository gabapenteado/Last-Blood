﻿using UnityEngine;
using System.Collections;

public class DestroyAfterAnim : MonoBehaviour 
{
	tk2dSpriteAnimator animator;
	tk2dSpriteAnimationClip clip;
	
	float destroyTime = 0.3f;
	public bool willDie = false;
	public bool played = false;
	// Use this for initialization
	void Start () 
	{
		if(gameObject.GetComponent<tk2dSpriteAnimator>())
		{
			animator = gameObject.GetComponent<tk2dSpriteAnimator>();
			clip = animator.CurrentClip;
		}
	}
	void LateUpdate()
	{		
		if(!animator.IsPlaying(clip) && willDie && played)
		{
			StartCoroutine("Destroy");
		}
	}
	IEnumerator Destroy()
	{
		
		yield return new WaitForSeconds(destroyTime);
		Destroy(gameObject);
	}
}

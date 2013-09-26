using UnityEngine;
using System.Collections;

public class DamageFeedback : MonoBehaviour {
	
	public tk2dTextMesh myText;
	
	private float yOffset;
	
	private Transform follow;
	
	/*public void Start()
	{
		Init(349.2f,false);
	}*/
	
	// Use this for initialization
	public void Init(float pDamage, bool pIsEnemy, Transform pFollow)
	{
		//iTween.MoveTo();
		
		//iTween.MoveBy(gameObject, iTween.Hash("y", 15, "time", "1"));
		
		myText.text = pDamage.ToString("f0");
		follow = pFollow;
		
		if(!pIsEnemy)
		{
			myText.color = Color.red;
		}
		
		Destroy(gameObject, 0.4f);
	}
	
	public void Update()
	{
		yOffset += 30 * Time.deltaTime;
		
		transform.position = new Vector3(follow.position.x ,follow.position.y + yOffset + 50,follow.position.z);
		
	}
}

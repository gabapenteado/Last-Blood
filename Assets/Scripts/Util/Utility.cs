using UnityEngine;
public static class Utility
{
	public static float HorizontalDistance(Vector3 pA,Vector3 pB)
	{
		
		return Vector3.Distance(new Vector3(pA.x,0,pA.z), new Vector3(pB.x,0,pB.z));
	}
	
}
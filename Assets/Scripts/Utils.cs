using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class VectorExtension{
	public static Vector2 ToVector2 (this Vector3 v3){
		return new Vector2 (v3.x, v3.z);
	}
}


public class Utils : MonoBehaviour {

	public static Transform FindNearest(Transform tra, List<Transform> tars){
		Transform t = null;
		tars.RemoveAll(o => o == null);
		
		if (tars.Count > 0){
			float dis = float.MaxValue;
			float minDis = float.MaxValue;
			
			foreach (var tar in tars) {
				dis = (tra.position - tar.position).sqrMagnitude;
				if (dis < minDis) {
					t = tar;
					minDis = dis;
				}
			}
			return t;
		} else 
			return null;
	}

	public static bool InRange (Vector3 pos,Vector3 tar, float range){
		return Vector3.Distance(tar, pos) <= range;
	}
}
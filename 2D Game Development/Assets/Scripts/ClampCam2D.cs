using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class ClampCam2D : MonoBehaviour {
	[SerializeField]Transform target;
	[SerializeField]float xMin = -1;
	[SerializeField]float xMax = 1;
	[SerializeField]float yMin = -1;
	[SerializeField]float yMax = 1;


	Transform t;

	void Awake()
	{
		t = transform;
	}



	void LateUpdate()
	{
		float x = Mathf.Clamp(target.position.x, xMin, xMax);
		float y = Mathf.Clamp(target.position.y, yMin, yMax);

		t.position = new Vector3( x, y, t.position.z);
	}

}

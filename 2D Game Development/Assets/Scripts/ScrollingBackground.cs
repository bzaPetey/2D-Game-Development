using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class ScrollingBackground : MonoBehaviour {
	[Range(0,1)][SerializeField]float xSpeed = 1f;
	[Range(0,1)][SerializeField]float ySpeed = 1f;

	Vector2 offset = Vector2.zero;
	Material mat;



	void Awake()
	{
		mat = GetComponent<MeshRenderer>().material;
	}



	public void Scroll(Vector2 pos)
	{
		offset.x += pos.x * xSpeed;
		offset.y += pos.y * ySpeed;

		if(offset.x > 1f)
			offset.x -= 1f;
		else if(offset.x < -1)
			offset.x += 1f;

		if(offset.y > 1f)
			offset.y -= 1f;
		else if(offset.y < -1)
			offset.y += 1f;

		mat.mainTextureOffset = offset;
	}
}

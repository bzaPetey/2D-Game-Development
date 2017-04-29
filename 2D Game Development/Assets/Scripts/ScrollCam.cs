using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class ScrollCam : MonoBehaviour {
	[SerializeField]ScrollingBackground[] scrollables;

	Vector2 lastFramePos;



	void Start()
	{
		lastFramePos = new Vector2(transform.position.x, transform.position.y);
	}


	void Update()
	{
		Vector2 curPos = new Vector2(transform.position.x, transform.position.y);
		if(lastFramePos == curPos)
			return;

		Vector2 pos;
		pos = lastFramePos - curPos;
		pos.x = pos.x - (int)pos.x;
		pos.y = pos.y - (int)pos.y;

		foreach(ScrollingBackground s in scrollables)
			s.Scroll(pos);

		lastFramePos = curPos;
	}
}

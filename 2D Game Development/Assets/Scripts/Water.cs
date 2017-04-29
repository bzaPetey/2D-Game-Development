using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(BuoyancyEffector2D))]
public class Water : MonoBehaviour {
	[SerializeField]float speed = -.001f;

	[SerializeField]Renderer rend;
	float pos = 0f;



	void Awake()
	{
		rend = GetComponent<Renderer>();
	}



	void Update()
	{
		pos += speed;
		if(pos >= 1f)
			pos -=1f;

		rend.material.mainTextureOffset = new Vector2( pos, 0);
	}
}

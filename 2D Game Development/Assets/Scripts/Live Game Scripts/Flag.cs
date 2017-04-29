using UnityEngine;


namespace BurgZergArcade.Live.Platformer2D
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(BoxCollider2D))]
	[RequireComponent(typeof(Animator))]
	public class Flag : MonoBehaviour {
		bool state = false;



		/// <summary>
		/// Start is called on the frame when a script is enabled just before
		/// any of the Update methods is called the first time.
		/// </summary>
		void Start()
		{
			GetComponent<BoxCollider2D>().isTrigger = true;
		}



		/// <summary>
		/// Sent when another object enters a trigger collider attached to this
		/// object (2D physics only).
		/// </summary>
		/// <param name="other">The other Collider2D involved in this collision.</param>
		void OnTriggerEnter2D(Collider2D other)
		{
			if(other.tag == "Player" && !state)
				GetComponent<Animator>().SetBool("LevelDone", true);
		}
	}
}

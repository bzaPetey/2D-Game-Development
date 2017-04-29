using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class CharacterController2DSimple : MonoBehaviour {
	[SerializeField]float attackResetTimer = .5f;
	[SerializeField]float maxSpeed = 5f;
	[SerializeField]float jumpPower = 500f;
	[SerializeField]float groundTriggerRadius = .15f;
	[SerializeField]Transform groundTrigger;
	[SerializeField]LayerMask groundLayer;


	Rigidbody2D rb;
	SpriteRenderer sr;
	Animator anim;
	float curSpeed = 0f;
	bool jump = false;
	bool isGrounded = false;
	bool canAttack = true;



	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
	}



	void Update()
	{
		curSpeed = Input.GetAxis("Horizontal") * maxSpeed;

		anim.SetFloat("hSpeed", Mathf.Abs(Input.GetAxis("Horizontal")));

		ChangeDirection();
		Attack();

		if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
			jump = true;
	}



	void FixedUpdate()
	{
		isGrounded = Physics2D.OverlapCircle(groundTrigger.position, groundTriggerRadius, groundLayer);
		anim.SetBool("isGrounded", isGrounded);

		Move();
		Jump();
	}


	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawSphere(groundTrigger.position, groundTriggerRadius);
	}


	void Move()
	{
		rb.velocity = new Vector2(curSpeed, rb.velocity.y);
	}



	void ChangeDirection()
	{
		if( curSpeed > 0 && sr.flipX )
			sr.flipX = false;
		else if( curSpeed < 0 && !sr.flipX )
			sr.flipX = true;
	}



	void Jump()
	{
		if(jump)
		{
			jump =false;
			rb.AddForce(Vector2.up * jumpPower);
		}
	}


	void Attack()
	{
		if(Input.GetKeyDown(KeyCode.F) && canAttack)
		{
			canAttack = false;
			anim.SetTrigger("Attack");
			Invoke("ResetAttackFlag", attackResetTimer);
		}
	}


	void ResetAttackFlag()
	{
		canAttack = true;
	}
}


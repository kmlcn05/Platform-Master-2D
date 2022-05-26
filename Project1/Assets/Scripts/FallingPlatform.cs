using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
	
	Rigidbody2D rb;

	public float fallTime = 1;

	private bool colliding = false;
	
	[SerializeField]
	private float time = 0;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{

		if(colliding)
		{

			time += Time.deltaTime;

		}

		if(time >= fallTime)
		{
			DropPlatform();
		}
			
	}

	void OnCollisionEnter2D(Collision2D col)
	{

		if (col.gameObject.tag == "Player")
		{
			colliding = true;
		}
	}

	private void OnCollisionExit2D(Collision2D col) 
	{
		if (col.gameObject.tag == "Player")
		{
			colliding = false;
		}
	}

	void DropPlatform()
	{
		rb.isKinematic = false;
		colliding = false;
		GetComponent<Collider2D>().isTrigger = true;

		Destroy(gameObject, 5);

	}
}

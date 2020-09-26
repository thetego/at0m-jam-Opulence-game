using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
	public float speed = 15f;

	public CharacterController cc;
	public float gravity ;
	Animator anim;

	Vector3 vec;

	private void Awake()
	{
		anim = transform.GetChild(0).GetComponent<Animator>();
	}

	private void Update()
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		Vector3 Move = transform.right * h + transform.forward * v;

		cc.Move(Move * speed * Time.deltaTime);

		vec.y += gravity * Time.deltaTime;

		cc.Move(vec * Time.deltaTime);

		if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
		{
			anim.Play("Walk Anim", -1, 0.0f);
		}
		if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
		{
			anim.Play("Idle", -1, 0.0f);
		}
	}

}

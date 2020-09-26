using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
	public float sensivity = 125f;
	float xRot = 0f;
	public Transform body;
	public bool cursorLock;


    void Update()
    {
		float h = Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
		float v = Input.GetAxis("Mouse Y") * sensivity* Time.deltaTime;


		xRot -= v;
		xRot = Mathf.Clamp(xRot, -90f, 90f);

		transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
		body.Rotate(Vector3.up * h);

		if (cursorLock)
		{
			LockCursor();
		}
		else
		{
			UnlockCursor();
		}

	}

	public void LockCursor()
	{
		Cursor.lockState = CursorLockMode.Locked;
		cursorLock = true;
	}
	public void UnlockCursor()
	{
		Cursor.lockState = CursorLockMode.None;
		cursorLock = false;
	}
}

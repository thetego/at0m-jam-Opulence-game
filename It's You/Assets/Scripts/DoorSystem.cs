using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSystem : MonoBehaviour
{
	Quaternion beginnigRot;
	public bool isLocked, isOpen, key = false;
	public bool secretDoor, isTriggered;
	public float Angle, Smooth, preferredangle;

	

	private void Awake()
	{
		beginnigRot = transform.localRotation;
		Smooth = 0.05f;
	}

	public void IsTheDoorLocked()
	{
		if (!isLocked)
		{
			isOpen = !isOpen;
			Angle = preferredangle;
			if (isTriggered)
			{
				isTriggered = false;
			}
		}
		else
		{
			if (key)
			{
				Angle = preferredangle;
				isOpen = !isOpen;
				
			}
			else
			{
				Angle = 0;
				
			}

		}
	}
	private void Update()
	{
		Quaternion currentRot = transform.rotation;
		Quaternion newRot = Quaternion.Euler(transform.eulerAngles.x, Angle, transform.eulerAngles.z);

		if (isOpen)
			transform.rotation = Quaternion.Lerp(currentRot, newRot,Smooth);
		else
			transform.rotation = Quaternion.Lerp(currentRot, beginnigRot, Smooth);

		if (secretDoor)
		{
			if (isTriggered)
			{
				isLocked = false;
				IsTheDoorLocked();
				Debug.Log("triggered");
			}
		}

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
	DoorSystem ds;



	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Map")
		{
			ds = transform.parent.GetComponent<DoorSystem>();
			ds.isTriggered = true;
		}
	}
}

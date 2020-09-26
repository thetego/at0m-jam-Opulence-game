using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraHit : MonoBehaviour
{

	public Image cursor;
	MouseLook ml;
	bool key, inspect;
	GameObject inspectItem;
	MeshFilter filter;
	FPSController fps;
	Vector3 minus;
	Quaternion beginnigrot;
	GameObject inspectObject;
	public GameObject e;
	public Text inspectexit;

	private void Awake()
	{
		ml = GetComponent<MouseLook>();
		fps = transform.parent.transform.parent.GetComponent<FPSController>();
		inspectItem = Camera.main.transform.GetChild(0).gameObject;
		inspectItem.SetActive(false);
		e.SetActive(false);
		inspectexit.gameObject.SetActive(false);
	}

	private void Update()
	{
		RaycastHit hit;
		if (Physics.Raycast(transform.position,transform.forward,out hit, 5F))
		{
			if(hit.transform.tag != "Untagged")
			{
				cursor.color = Color.green;
				e.SetActive(true);
			}
			if (hit.transform.tag == "Untagged")
			{
				cursor.color = Color.white;
				e.SetActive(false);
			}
			if (hit.transform.tag == "Door")
			{
				if(Input.GetKeyDown(KeyCode.E))
					hit.transform.GetComponent<DoorSystem>().IsTheDoorLocked();
					hit.transform.GetComponent<DoorSystem>().key = key;
					
				
			}
			if (hit.transform.tag == "Key" && Input.GetKeyDown(KeyCode.E))
			{
				key = true;
				Destroy(hit.transform.gameObject);
				
			}
			if (hit.transform.tag == "Inspect" && Input.GetKeyDown(KeyCode.E))
			{
				inspectItem.SetActive(true);
				inspectItem.transform.localPosition = new Vector3(0, 0.3f, 1.75f);
				filter = inspectItem.GetComponent<MeshFilter>();
				inspect = true;
				fps.enabled = false;
				ml.UnlockCursor();
				ml.enabled = false;
				filter.mesh = hit.transform.GetComponent<MeshFilter>().mesh;
				beginnigrot = inspectItem.transform.localRotation;
				hit.transform.gameObject.SetActive(false);
				inspectObject = hit.transform.gameObject;
				inspectexit.gameObject.SetActive(true);
			}
		}
		else
		{
			cursor.color = Color.white;
			e.SetActive(false);
		}
		if (Input.GetMouseButtonDown(0))
		{
			minus = Input.mousePosition;
		}
		if (Input.GetMouseButton(0))
		{
			var rot = Input.mousePosition - minus;
			minus = Input.mousePosition;
			var axis = Quaternion.AngleAxis(-90f, Vector3.forward) * rot;
			inspectItem.transform.localRotation = Quaternion.AngleAxis(rot.magnitude * 0.1f, axis) * inspectItem.transform.localRotation;
		}
		if (Input.GetMouseButtonUp(0))
		{
			inspectItem.transform.localRotation = Quaternion.Lerp(transform.localRotation, beginnigrot, .5f);
		}
		if (inspect) 
		{
			if (Input.GetKeyDown(KeyCode.Tab))
			{
				inspectItem.SetActive(false);
				inspectObject.SetActive(true);
				inspect = false;
				ml.enabled = true;
				ml.LockCursor();
				fps.enabled = true;
				inspectexit.gameObject.SetActive(false);
			}
		}
	}
}

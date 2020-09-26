using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptFlow : MonoBehaviour
{
	FPSController fps;
	MouseLook ml;
	Animator anim;
	CameraHit ch;
	public Image comics, skip;

	private void Awake()
	{
		ml = Camera.main.GetComponent<MouseLook>();
		fps = Camera.main.transform.parent.transform.parent.GetComponent<FPSController>();
		anim= Camera.main.transform.parent.GetComponent<Animator>();
		ch= Camera.main.GetComponent<CameraHit>();
	}

	private void Update()
	{
		if (comics.gameObject.activeSelf)
		{
			anim.Play("Idle");
			ch.cursor.gameObject.SetActive(false);
			comics.color = Color.Lerp(comics.color, new Color(255, 255, 255, 1), 0.05f);
			skip.color = Color.Lerp(skip.color, new Color(255, 255, 255, 1), 0.05f);
			
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (transform.tag == "First" && other.tag == "Player")
		{
			skip.gameObject.SetActive(true);
			comics.gameObject.SetActive(true);
			ml.UnlockCursor();
			ml.enabled = false;
			fps.enabled = false;
		}
	}

	public void Skip()
	{
		fps.gameObject.transform.position =new Vector3(transform.GetChild(0).transform.position.x,fps.gameObject.transform.position.y, transform.GetChild(0).transform.position.z);
		comics.gameObject.SetActive(false);
		skip.gameObject.SetActive(false);
		ml.enabled = true;
		ml.LockCursor();
		ch.cursor.gameObject.SetActive(true);
		fps.enabled = true;
	}
}

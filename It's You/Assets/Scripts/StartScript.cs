using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScript : MonoBehaviour
{
	public Image image, skip ,sec;
	AudioSource src;
	FPSController fps;
	MouseLook ml;
	CameraHit ch;
	Camera cam;
	bool second, finish;

	private void Awake()
	{
		ml = Camera.main.GetComponent<MouseLook>();
		fps = Camera.main.transform.parent.transform.parent.GetComponent<FPSController>();
		ch = Camera.main.GetComponent<CameraHit>();
		ch.cursor.gameObject.SetActive(false);
		cam = Camera.main;
		cam.gameObject.SetActive(false);
		second = false;
	}

	private void Update()
	{
		if (!second&&!finish)
		{
			image.color = Color.Lerp(image.color, new Color(255, 255, 255, 1), 0.05f);
			skip.color = Color.Lerp(skip.color, new Color(255, 255, 255, 1), 0.05f);
			StartCoroutine(Skip());
		}
		if (second)
		{
			image.color = Color.Lerp(image.color, new Color(255, 255, 255, 0), 0.09f);
			sec.color = Color.Lerp(image.color, new Color(255, 255, 255, 1), 0.09f);
			StartCoroutine(Finish());
		}
		if (finish)
		{
			sec.color = Color.Lerp(image.color, new Color(255, 255, 255, 0), 0.1f);
			sec.gameObject.SetActive(false);
			cam.gameObject.SetActive(true);
			ch.cursor.gameObject.SetActive(true);
			this.enabled = false;

		}
	}

	IEnumerator Skip()
	{
		if (!second)
		{
			yield return new WaitForSeconds(10);
			image.gameObject.SetActive(false);
			second = true;
		}
	}
	IEnumerator Finish()
	{
			yield return new WaitForSeconds(10);
			
			second = false;
			finish = true;
	}
}

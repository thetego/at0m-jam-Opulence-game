using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptFlow : MonoBehaviour
{
	FPSController fps;
	MouseLook ml;
	Animator anim;
	public Image background;
	public Image comics;

	private void Awake()
	{
		ml = Camera.main.GetComponent<MouseLook>();
		fps = Camera.main.transform.parent.transform.parent.GetComponent<FPSController>();
		anim= GetComponent<Animator>();
	}

	private void Update()
	{
		if (comics.gameObject.activeSelf)
		{
			background.color = Color.Lerp(background.color, new Color(256, 256, 256, 1), 0.02f);
			print(background.color.a);
			if (background.color.a >= 0.95f)
			{
				comics.color = Color.Lerp(comics.color, new Color(0, 0, 0, 1), 0.02f);
				StartCoroutine(Wait());
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (transform.tag == "First" && other.tag == "Player")
		{
			background.gameObject.SetActive(true);
			comics.gameObject.SetActive(true);
			ml.enabled = false;
			fps.enabled = false;
		}
	}
	IEnumerator Wait()
	{
		yield return new WaitForSeconds(20);
		yield return null;
		print("asd");
		Skip();
	}
	 void Skip()
	{
		background.gameObject.SetActive(false);
		comics.gameObject.SetActive(false);
		ml.enabled = true;
		fps.enabled = true;
	}
}

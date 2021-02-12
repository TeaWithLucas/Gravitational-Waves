using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimatorFunctions : MonoBehaviour
{
	[SerializeField] MenuButtonController menuButtonController;
	public bool disableOnce;

	void PlaySound(AudioClip whichSound)
	{
		if (!disableOnce)
		{
			menuButtonController.audioSource.PlayOneShot(whichSound);
		}
		else
		{
			disableOnce = false;
		}
	}
}

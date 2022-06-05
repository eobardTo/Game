using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour 
{
	public static AudioManager instance;

	[SerializeField] AudioSource[] sounds;

	private void Awake ()
	{
		if (instance == null)
		{
			instance = this;
		}
	}

	void Start ()
	{
        sounds = GetComponentsInChildren<AudioSource>();
	}
	

	public void PlaySound (string _name)
	{
		for (int i = 0; i < sounds.Length; i++)
		{
			if (sounds[i].name == _name)
			{
				sounds[i].Play();
				return;
			}
		}

	}

}

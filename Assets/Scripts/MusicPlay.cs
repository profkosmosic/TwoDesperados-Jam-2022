using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlay : MonoBehaviour
{
    private static MusicPlay music = null;
	public static MusicPlay Music
	{
		get { return music; }
	}

	void Awake()
	{
		if (music != null && music != this)
		{
			Destroy(this.gameObject);
			return;
		}
		else
		{
			music = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}
}

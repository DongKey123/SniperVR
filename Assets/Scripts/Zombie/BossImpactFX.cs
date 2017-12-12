using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossImpactFX : MonoBehaviour
{
	public void Play()
	{
		_SoundAppear.Play();
		_ImpactFX.Play();

		Destroy( gameObject, 2f );
	}

	[SerializeField]
	private AudioSource _SoundAppear;
	[SerializeField]
	private ParticleSystem _ImpactFX;
}

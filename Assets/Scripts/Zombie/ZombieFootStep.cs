using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFootStep : MonoBehaviour
{
	public void Play(int foot)
	{
		if ( foot >= 2 )
			return;

		PlayFootStep( foot );

		_dustParticle.Clear();
		_dustParticle.Play();

		Invoke( "Dead", 2.5f );
	}

	void Dead()
	{
		gameObject.SetActive( false );
	}

	void PlayFootStep(int foot)
	{
		if ( foot == 0 )
			_soundAppear.clip = _leftFootStep;
		else
			_soundAppear.clip = _rightFootStep;

		_soundAppear.Play();
	}
	[SerializeField]
	private ParticleSystem _dustParticle;

	[SerializeField]
	private AudioClip _leftFootStep;
	[SerializeField]
	private AudioClip _rightFootStep;

	[SerializeField]
	private AudioSource _soundAppear;
}

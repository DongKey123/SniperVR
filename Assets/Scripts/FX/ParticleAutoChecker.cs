using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAutoChecker : MonoBehaviour
{
	void Awake()
	{
		_myParticle = GetComponent<ParticleSystem>();
	}
	
	void OnEnable()
	{
		if ( !_myParticle.isStopped )
			_myParticle.Stop();
		_myParticle.Clear();
		_myParticle.Play();

		Invoke( "Death", _myParticle.main.duration + 0.2f );
	}

	void OnDisable()
	{
		this.CancelInvoke();
	}
	
	void Death()
	{
		gameObject.SetActive( false );
	}

	ParticleSystem _myParticle;
}

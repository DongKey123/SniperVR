using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactWood : MonoBehaviour
{
	[SerializeField]
	ParticleSystem	_impactParticle;

	[SerializeField]
	GameObject		_impactDecal;

	public void Play()
	{
		_impactParticle.Play();
		Invoke( "PlaceOnDecal", _impactParticle.main.duration );
	}

	void PlaceOnDecal()
	{
		_impactDecal.SetActive( true );
	}

}

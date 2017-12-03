using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactBlood : MonoBehaviour
{
	[SerializeField]
	ParticleSystem _BloodImapctFX;

	public void Play()
	{
		_BloodImapctFX.Play();
	}
}

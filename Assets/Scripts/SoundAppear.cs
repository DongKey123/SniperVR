using System.Collections;
using UnityEngine;

public class SoundAppear : MonoBehaviour
{
	public enum SoundType
	{
		ATTACK,
		IDLE,
		DEATH,
		HIT
	};

	public AudioClip _IdleSound;
	public AudioClip _AtkSound;
	public AudioClip _DeathSound;
	public AudioClip _HitSound;

	[SerializeField]
	private AudioSource _appearPoint;

	public void Play( SoundType playType )
	{
		AudioClip selectClip = null;
		switch ( playType )
		{
			case SoundType.ATTACK:
				selectClip = _AtkSound;
				break;
			case SoundType.IDLE:
				selectClip = _IdleSound;
				break;
			case SoundType.DEATH:
				selectClip = _DeathSound;
				break;
			case SoundType.HIT:
				selectClip = _HitSound;
				break;
		}

		_appearPoint.clip = selectClip;
		_appearPoint.Play();
	}
}

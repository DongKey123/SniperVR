using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSplatRender : MonoBehaviour
{
	[SerializeField]
	float	_AppearDelay;
	
	bool			_play;
	int				_objOpenIndex;
	float			_nowTime;

	[SerializeField]
	Transform _bloodSplatTransform;
	
	
	// Use this for initialization
	void Start ()
	{
		_play = false;
		_objOpenIndex = 0;
		_nowTime = 0;
	}

	public void Update()
	{
		if ( _play == false )
			return;

		if ( _objOpenIndex >= _bloodSplatTransform.childCount )
			return;

		_nowTime += Time.deltaTime;

		if ( _nowTime >= _AppearDelay )
		{
			_nowTime -= _AppearDelay;
			_bloodSplatTransform.GetChild( _objOpenIndex ).gameObject.SetActive( true );
			_objOpenIndex++;
		}

	}

	public void Play()
	{
		_play = true;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepManager : Singleton<FootStepManager>
{
	public void Initialized()
	{
		_footStepFrefab = Resources.Load( "FX/FootStep" ) as GameObject;

		GameObject ret = null;
		for ( int i = 0; i < 100; i++ )
		{
			ret = Instantiate( _footStepFrefab );
			ret.transform.parent = transform;
			ret.gameObject.SetActive( false );
			_ParticlePool.Add( ret );
		}
	}

	public void Clear()
	{
		if(_ParticlePool != null)
			_ParticlePool.Clear();
	}

	public void PlayParticle( Vector3 appearPosition, int footType )
	{
		GameObject selectParticle = null;
		for ( int i = 0; i < _ParticlePool.Count; i++ )
		{
			if ( _ParticlePool[i].activeSelf == false )
			{
				selectParticle = _ParticlePool[i];
				break;
			}
		}

		selectParticle.SetActive( true );
		selectParticle.transform.position = appearPosition;
		selectParticle.GetComponent<ZombieFootStep>().Play( footType );
	}

	GameObject _footStepFrefab;

	List<GameObject> _ParticlePool = new List<GameObject>();


}

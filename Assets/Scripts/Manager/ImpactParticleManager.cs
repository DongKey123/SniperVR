using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactParticleManager : Singleton<ImpactParticleManager>
{
	public void Initialized()
	{
		Clear();

		string defaltForder = "FX/ImpactForWorld/";
		_StoneFXFrefab = Resources.Load( defaltForder + "impactConcrete" ) as GameObject;
		_GrassFXFrefab = Resources.Load( defaltForder + "impactGlass" ) as GameObject;
		_MetalFXFrefab = Resources.Load( defaltForder + "impactMetal" ) as GameObject;
		_WoodFXFrefab = Resources.Load( defaltForder + "impactWood" ) as GameObject;

		
		for ( int i = 0; i < 15; i++ )
		{
			_StoneObjPool.Add( CreateFX( _StoneFXFrefab ) );
			_GrassObjPool.Add( CreateFX( _GrassFXFrefab ) );
			_MetalObjPool.Add( CreateFX( _MetalFXFrefab ) );
			_WoodObjPool.Add( CreateFX( _WoodFXFrefab ) );
		}
	}

	public void Clear()
	{
		_StoneObjPool.Clear();
		_GrassObjPool.Clear();
		_MetalObjPool.Clear();
		_WoodObjPool.Clear();
	}

	public void PlayParticle(Vector3 position, Vector3 normal, int layer)
	{
		if ( layer == LayerMask.NameToLayer( "Stone" ) )
		{
			PlayParticleForMaterial( position, normal, _StoneObjPool );
		}
		else if ( layer == LayerMask.NameToLayer( "Grass" ) )
		{
			PlayParticleForMaterial( position, normal, _GrassObjPool );
		}
		else if ( layer == LayerMask.NameToLayer( "Metal" ) )
		{
			PlayParticleForMaterial( position, normal, _MetalObjPool );
		}
		else if ( layer == LayerMask.NameToLayer( "Wood" ) )
		{
			PlayParticleForMaterial( position, normal, _WoodObjPool );
		}

		return;
	}

	GameObject CreateFX( GameObject frefab )
	{
		GameObject ret = Instantiate( frefab );
		ret.transform.SetParent( transform );
		ret.SetActive( false );
		return ret;
	}

	void PlayParticleForMaterial( Vector3 position, Vector3 normal, List<GameObject> MaterialList )
	{
		GameObject ret = null;

		for ( int i = 0; i < MaterialList.Count; i++ )
		{
			if ( MaterialList[i].activeSelf == false )
			{
				ret = MaterialList[i];
				break;
			}
		}

		ret.transform.position = position;
		ret.GetComponent<ParticleChildRotate>().Rotate( Quaternion.LookRotation( normal ) );
		ret.SetActive( true );
	}

	GameObject _StoneFXFrefab;
	GameObject _GrassFXFrefab;
	GameObject _MetalFXFrefab;
	GameObject _WoodFXFrefab;

	List<GameObject> _StoneObjPool = new List<GameObject>();
	List<GameObject> _GrassObjPool = new List<GameObject>();
	List<GameObject> _MetalObjPool = new List<GameObject>();
	List<GameObject> _WoodObjPool = new List<GameObject>();
}

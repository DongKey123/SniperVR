using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSplatRender : MonoBehaviour
{
	[SerializeField]
	Vector3 _RandomMinPos;

	[SerializeField]
	Vector3 _RandomMaxPos;

	[SerializeField]
	int		_AppearAmount;

	[SerializeField]
	float	_AppearDelay;

	[SerializeField]
	GameObject _BloodFrefab;

	[SerializeField]
	List<Texture2D> _UsedBloodTextures;

	bool			_play;
	int				_objOpenIndex;
	float			_nowTime;

	Vector3			_RandomMiddlePos;
	
	// Use this for initialization
	void Start ()
	{
		_RandomMiddlePos = _RandomMaxPos + _RandomMinPos;
		_RandomMiddlePos *= 0.5f;

		GameObject Blood;

		Material frefabMat = _BloodFrefab.GetComponent<Renderer>().sharedMaterial;
		Material copyMat;
		
		float x, y, z;
		int tI;

		List<GameObject> createBloods = new List<GameObject>();

		for ( int i = 0; i < _AppearAmount; i++ )
		{
			Blood = Instantiate( _BloodFrefab );

			x = Random.Range( _RandomMinPos.x, _RandomMaxPos.x );
			z = Random.Range( _RandomMinPos.z, _RandomMaxPos.z );

			if ( i > _AppearAmount / 2 )
			{
				y = Random.Range( _RandomMinPos.y, _RandomMiddlePos.y );
			}
			else
			{
				y = Random.Range( _RandomMiddlePos.y, _RandomMaxPos.y );
			}

			tI = Random.Range( 0, _UsedBloodTextures.Count );

			copyMat = Instantiate( frefabMat );
			copyMat.mainTexture = _UsedBloodTextures[tI];

			Blood.GetComponent<Renderer>().sharedMaterial = copyMat;

			Blood.transform.localPosition = new Vector3( x, y , Mathf.Round( z ));
			Blood.SetActive( false );

			createBloods.Add( Blood );
		}

		createBloods.Sort( delegate ( GameObject a, GameObject b )
		{
			if ( a.transform.localPosition.z < b.transform.localPosition.z )
				return 1;
			else if ( a.transform.localPosition.z > b.transform.localPosition.z )
				return -1;
			return 0;
		});

		Vector3 lpos;
		foreach ( GameObject blood in createBloods )
		{
			lpos = blood.transform.localPosition;
			blood.transform.parent = transform;
			blood.transform.localPosition = lpos;
		} 
			
		_play = false;
		_objOpenIndex = 0;
		_nowTime = 0;
	}

	public void Update()
	{
		if ( _play == false )
			return;

		if ( _objOpenIndex >= transform.childCount )
			return;

		_nowTime += Time.deltaTime;

		if ( _nowTime >= _AppearDelay )
		{
			_nowTime -= _AppearDelay;
			transform.GetChild( _objOpenIndex ).gameObject.SetActive( true );
			_objOpenIndex++;
		}

	}

	public void Play()
	{
		_play = true;
	}
}

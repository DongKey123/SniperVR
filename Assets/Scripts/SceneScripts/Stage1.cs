using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1 : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		_isStartShotRiffle = false;
		_GUIText._Lock = true;
		_GUIText.LoadScript( "Texts/Stage1" );

		StartCoroutine( "Tutorial" );
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Tutorial()
	{
		_GUIText.TextDone += RiffleShotStart;
		
		while ( _GUIFrontScreen.IsFading )
		{
			yield return new WaitForEndOfFrame();
		}

		_GUIText._Lock = false;
		_GUIText.gameObject.SetActive( true );

		while ( !_isStartShotRiffle )
		{
			yield return new WaitForEndOfFrame();
		}

		_SniperRifle.SetActive( true );
		_GUIText.gameObject.SetActive( false );

		//nextScene
	}

	void RiffleShotStart()
	{
		_isStartShotRiffle = true;
	}

	public Dongkey.CameraFade		_GUIFrontScreen;
	public Paradox.ScreenOverayText _GUIText;

	public GameObject				_SniperRifle;

	bool							_isStartShotRiffle;
}

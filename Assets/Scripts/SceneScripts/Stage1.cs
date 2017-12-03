using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage1 : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		_isStartShotRiffle = false;

		_GUIText._Lock = true;
		_GUIText.LoadScript( "Texts/Stage1" );

		_maxTargetAmount = _TargetObjParentTransform.childCount;
		_shotTargetAmount = 0;

		for ( int i = 0; i < _maxTargetAmount; i++ )
		{
			if ( _TargetObjParentTransform.GetChild( i ) != null )
			{
				if ( _TargetObjParentTransform.GetChild( i ).GetComponent<TargetPanel>() != null )
					_TargetObjParentTransform.GetChild( i ).GetComponent<TargetPanel>().Over += AddShotTargetAmount;
			}
		}

		StartCoroutine( "Tutorial" );
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Tutorial()
	{
		while ( _GUIFrontScreen.IsFading )
		{
			yield return new WaitForEndOfFrame();
		}

		_GUIText.PageDown += CheckGameStart;
		_GUIText._Lock = false;
		_GUIText.gameObject.SetActive( true );

		while ( !_isStartShotRiffle )
		{
			yield return new WaitForEndOfFrame();
		}

		_SniperRifle.SetActive( true );

		while ( _shotTargetAmount < _maxTargetAmount )
		{
			yield return new WaitForEndOfFrame();
		}

		_GUIText._Lock = false;
		_GUIText.gameObject.SetActive( true );
		_GUIText.TextDone += FrontScreenFadeOut;
	}

	void RiffleShotStart()
	{
		_isStartShotRiffle = true;
	}

	void AddShotTargetAmount()
	{
		_shotTargetAmount++;
	}

	void CheckGameStart()
	{
		if ( _GUIText.GetCurrentScriptIndex() >= 4 )
		{
			_GUIText.PageDown -= CheckGameStart;
			_GUIText.gameObject.SetActive( false );
			_GUIText._Lock = true;
			_isStartShotRiffle = true;
		}
	}

	void FrontScreenFadeOut()
	{
		_GUIFrontScreen.OnFadeComplete += GoNextLevel;
		_GUIFrontScreen.FadeOut();
	}

	void GoNextLevel()
	{
		SceneManager.LoadScene( "Stage2" );
	}


	public Dongkey.CameraFade		_GUIFrontScreen;
	public Paradox.ScreenOverayText _GUIText;

	public GameObject				_SniperRifle;

	[SerializeField]
	private Transform				_TargetObjParentTransform;

	bool							_isStartShotRiffle;

	int								_maxTargetAmount;
	int								_shotTargetAmount;

}

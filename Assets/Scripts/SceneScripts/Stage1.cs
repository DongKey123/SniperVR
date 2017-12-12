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

		Transform child = null;
		for ( int i = 0; i < _maxTargetAmount; i++ )
		{
			child = _TargetObjParentTransform.GetChild( i );
			if ( child != null )
			{
				if ( child.GetComponent<TargetPanel>() != null )
				{
					if ( child.name.Contains("9") || child.name.Contains( "10" ) || child.name.Contains( "11" ) )
					{
						_TargetListFront.Add( child.gameObject );
					}
					else if( child.name.Contains( "6" ) || child.name.Contains( "7" ) || child.name.Contains( "8" ) )
					{
						_TargetListFar.Add( child.gameObject );
					}
					child.GetComponent<TargetPanel>().Over += AddShotTargetAmount;
				}
			}
		}

		//랜덤 타겟 일어남 체크();
		//_maxTargetAmount = _RandomAwakeAmount + 1;
		_maxTargetAmount = _RandomAwakeAmount;

		StartCoroutine( "Tutorial" );
	}
	
	// Update is called once per frame
	void Update ()
	{
		if ( _delayTime > 0 )
		{
			_delayTime -= Time.deltaTime;
		}
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
		// 사격
		for ( int i = 0; i < _TargetListFront.Count; i++ )
		{
			_TargetListFront[i].GetComponent<TargetPanel>().WakeUp();
		}

		while ( _shotTargetAmount < 1 )
			yield return new WaitForEndOfFrame();

		_shotTargetAmount = 0;

		for ( int i = 0; i < _TargetListFront.Count; i++ )
		{
			_TargetListFront[i].GetComponent<TargetPanel>().FlipBackTarget();
		}

		//타겟 모두 내려가는것 대기.
		_delayTime = _ShotWaitDelay;

		while ( _delayTime > 0 )
			yield return new WaitForEndOfFrame();

		// 조준경 사용 사격
		_GUIText.NextTextFromAcessText( true );

		for ( int i = 0; i < _TargetListFar.Count; i++ )
		{
			_TargetListFar[i].GetComponent<TargetPanel>().WakeUp();
		}

		while ( _shotTargetAmount < 1 )
			yield return new WaitForEndOfFrame();

		_shotTargetAmount = 0;

		for ( int i = 0; i < _TargetListFar.Count; i++ )
		{
			_TargetListFar[i].GetComponent<TargetPanel>().FlipBackTarget();
		}

		//타겟 모두 내려가는것 대기.
		_delayTime = _ShotWaitDelay;

		while ( _delayTime > 0 )
			yield return new WaitForEndOfFrame();

		//랜덤 n 사격
		_GUIText.NextTextFromAcessText( true );
		
		int randomIndex = -1;
		int currentAmount = _RandomAwakeAmount;
		TargetPanel value = null;
		//타겟 솟아오르기;
		while ( true )
		{
			if ( currentAmount <= 0 )
				break;

			randomIndex = Random.Range( 0, _TargetObjParentTransform.childCount );
			value = _TargetObjParentTransform.GetChild( randomIndex ).GetComponent<TargetPanel>();

			if ( value.IsChooseRandomWake() )
				continue;

			value.WakeUp(true);
			currentAmount--;
		}
		
		while ( _shotTargetAmount < _maxTargetAmount )
		{
			yield return new WaitForEndOfFrame();
		}

		_GUIText.NextTextFromAcessText( true );

		//nextGame
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
		if ( _GUIText.GetCurrentScriptIndex() >= 3 )
		{
			_GUIText.PageDown -= CheckGameStart;
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

	float _delayTime;
	public float _ShotWaitDelay = 1f;

	public Dongkey.CameraFade		_GUIFrontScreen;
	public Paradox.ScreenOverayText _GUIText;

	public GameObject				_SniperRifle;

	[SerializeField]
	private Transform				_TargetObjParentTransform;

	[SerializeField]
	private int						_RandomAwakeAmount;

	bool							_isStartShotRiffle;

	int								_maxTargetAmount;
	int								_shotTargetAmount;

	List<GameObject>				_TargetListFront = new List<GameObject>();
	List<GameObject>				_TargetListFar = new List<GameObject>();

}

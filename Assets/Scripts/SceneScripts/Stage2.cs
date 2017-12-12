using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage2 : MonoBehaviour
{
	void OnEnable()
	{
		FootStepManager.Instance.Initialized();
		ImpactParticleManager.Instance.Initialized();
	}

	void OnDisable()
	{
		if( FootStepManager.Instance != null)
			FootStepManager.Instance.Clear();
		if( ImpactParticleManager.Instance != null)
			ImpactParticleManager.Instance.Clear();
	}

	// Use this for initialization
	void Start()
	{
		_GUIText._Lock = true;
		_GUIText.LoadScript( "Texts/Stage2" );
		
		_maxMonsterAmount = _MonsterHaveTransform.childCount;
		_killMonsterAmount = 0;
		for ( int i = 0; i < _maxMonsterAmount; i++ )
		{
			_MonsterHaveTransform.GetChild( i ).GetComponent<Zombie>().OnDown += AddKillMonsterAmount;
		}

		StartCoroutine( "Game" );
	}

	IEnumerator Game()
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

		for ( int i = 0; i < _maxMonsterAmount; i++ )
		{
			_MonsterHaveTransform.GetChild( i ).gameObject.SetActive(true);
		}

		while ( _killMonsterAmount < _maxMonsterAmount )
			yield return new WaitForEndOfFrame();

		_GUIText.PageDown += CheckBossStart;
		_GUIText._Lock = false;
		_GUIText.gameObject.SetActive( true );

		while ( !_isEnterBossRound )
			yield return new WaitForEndOfFrame();

		//boss
		_Boss.gameObject.SetActive( true );
		_Boss.OnDead += BossClear;
		//
		while ( !_isClearBoss )
			yield return new WaitForEndOfFrame();

		_GUIText._Lock = false;
		_GUIText.TextDone += FrontScreenFadeOut;
		_GUIText.gameObject.SetActive( true );
	}
	
	void AddKillMonsterAmount()
	{
		_killMonsterAmount++;
	}

	void CheckGameStart()
	{
		if ( _GUIText.GetCurrentScriptIndex() >= 5 )
		{
			_GUIText.PageDown -= CheckGameStart;
			_GUIText._Lock = true;
			_GUIText.gameObject.SetActive( false );
			_isStartShotRiffle = true;
		}
	}

	void CheckBossStart()
	{
		if ( _GUIText.GetCurrentScriptIndex() >= 7 )
		{
			_GUIText.PageDown -= CheckBossStart;
			_GUIText._Lock = true;
			_GUIText.gameObject.SetActive( false );
			_isEnterBossRound = true;
		}
	}

	void BossClear()
	{
		//보스의 개 초기화. 
		_Boss.AllKillSummons();
		_isClearBoss = true;
	}

	void FrontScreenFadeOut()
	{
		_GUIFrontScreen.OnFadeComplete += GoNextLevel;
		_GUIFrontScreen.FadeOut();
	}
	void GoNextLevel()
	{
		SceneManager.LoadScene( "Ending" );
	}

	public Dongkey.CameraFade _GUIFrontScreen;
	public Paradox.ScreenOverayText _GUIText;

	public GameObject _SniperRifle;

	[SerializeField]
	private Transform _MonsterHaveTransform;

	[SerializeField]
	private Boss _Boss;

	bool _isStartShotRiffle = false;
	bool _isEnterBossRound = false;

	bool _isClearBoss = false;
	
	int _maxMonsterAmount;
	int _killMonsterAmount;
}

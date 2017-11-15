using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

namespace Dongkey
{
    public class CameraFade : MonoBehaviour {

        public event Action OnFadeStart;    // 페이드 시작시 이벤트
        public event Action OnFadeComplete; // 페이드 완료시 이벤트

        [SerializeField]
        private Image _FadeImage;
        [SerializeField]
        private Color _FadeColor = Color.black;
        [SerializeField]
        private float _FadeDuration = 2.0f;
        [SerializeField]
        private bool _FadeInOnSceneLoad = false;  //씬 로드시 페이드 인이 발생하는 지 여부
        [SerializeField]
        private bool _FadeInOnStart = false;      //시작시 페이드인이 발생하는지

        private bool _IsFading = false;
        private float _FadeStartTime;
        private Color _FadeOutColor;

        public bool IsFading{ get { return _IsFading; } }

        void Awake()
        {
            _FadeImage.enabled = true;
            //SceneManager.sceneLoaded += SceneManager_sceneLoaded;

            _FadeOutColor = new Color(_FadeColor.r, _FadeColor.g, _FadeColor.b, 0f);
        }

        private void OnEnable()
        {
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
        }

        // Use this for initialization
        void Start () {
            if(_FadeInOnStart)
            {
                _FadeImage.color = _FadeColor;
                FadeIn();
            }
        }
	
	    // Update is called once per frame

        public void FadeIn()
        {
            FadeIn(_FadeDuration);
        }

        public void FadeIn(float duration)
        {
            if (_IsFading)
                return;

            StartCoroutine(BeginFade(_FadeColor, _FadeOutColor, duration));
        }

        public void FadeOut()
        {
            FadeOut(_FadeDuration);
        }

        public void FadeOut(float duration)
        {
            if (_IsFading)
                return;

            StartCoroutine(BeginFade(_FadeOutColor, _FadeColor, duration));
        }



        private IEnumerator BeginFade(Color startCol, Color endCol , float duration)
        {
            _IsFading = true;
            float timer = 0f;

            if (OnFadeStart != null)
                OnFadeStart();

            while ( timer <= duration)
            {
                _FadeImage.color = Color.Lerp(startCol, endCol, timer / duration);

                timer += Time.deltaTime;
                yield return null;
            }

            _FadeImage.color = endCol;

            _IsFading = false;

            if (OnFadeComplete != null)
                OnFadeComplete();
        
        }

        private void SceneManager_sceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            if (_FadeInOnSceneLoad)
            {
                _FadeImage.color = _FadeColor;
            }
        }

        void OnDestroy()
        {
            //SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
        }

    }

}
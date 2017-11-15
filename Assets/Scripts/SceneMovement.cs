using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Paradox
{
	public class SceneMovement : MonoBehaviour
	{
		[SerializeField]
		private string _NextSceneName;
		[SerializeField]
		private Dongkey.CameraFade _FadeOutImage;

        // is use fade
        public bool UseFade = false;

	// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{
		}

		public void LoadScene()
		{                        
            if (UseFade)
            {
                if (_FadeOutImage)
                    _FadeOutImage.FadeOut();
                StartCoroutine("DoFadeNextScene");
            }
            else
            {
                // load scene without fade effect
                if (Application.HasProLicense())
                {
                    SceneManager.LoadSceneAsync(_NextSceneName);
                }
                else
                {
                    SceneManager.LoadScene(_NextSceneName);
                }
            }
		}

		private IEnumerator DoFadeNextScene()
		{
			if ( _FadeOutImage )
			{
				_FadeOutImage.FadeOut();
				while ( _FadeOutImage.IsFading )
				{
					yield return new WaitForEndOfFrame();
				}
			}
			UnityEngine.SceneManagement.SceneManager.LoadScene( _NextSceneName );
		}
	}

}

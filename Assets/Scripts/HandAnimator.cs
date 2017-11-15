using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Paradox
{
	public class HandAnimator : MonoBehaviour
	{
		[SerializeField]
		Animator _HandAniamtor;
		
		public void Grab( InteractiveModelData.InteractiveObjectType grabType)
		{
			switch ( grabType )
			{
				case InteractiveModelData.InteractiveObjectType.MILKPITCHER:
					_HandAniamtor.CrossFade( "GrabMilkPicher", 0.05f );
					break;
				case InteractiveModelData.InteractiveObjectType.MILKPACK:
					_HandAniamtor.CrossFade( "GrabMilk", 0.05f );
					break;
				case InteractiveModelData.InteractiveObjectType.MACHINE_PORTERFILTER:
					_HandAniamtor.CrossFade( "PorterFilterGirp", 0.05f );
					break;
				case InteractiveModelData.InteractiveObjectType.TAMPER:
					_HandAniamtor.CrossFade( "TemperGrip", 0.05f );
					break;
				default:
					_HandAniamtor.CrossFade( "DefaultGrip", 0.05f );
					break;
			}
		}

		public void Put()
		{
			_HandAniamtor.CrossFade( "hand_idle_A", 0.05f );
		}
	}
}

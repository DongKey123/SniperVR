using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dongkey
{
    public class Reticle : MonoBehaviour
    {
        [SerializeField]
        private float _DefaultDistance = 3f;    //레티클이 놓이는 카메라로부터의 기본 거리.
        [SerializeField]
        private bool _UseNormal;                //레티클을 표면에 평행하게 놓아야하는지 여부. (ex. 3D 원에 맞췄을때 원의 노말값에 따라 회전시킬지)              
        [SerializeField]
        private Image _Image;                   //레티클 이미지
        [SerializeField]
        private Transform _ReticleTR;
        [SerializeField]
        private Transform _Camera;

        private Vector3 _OriginScale;        //레티클 스케일이 변경되기 때문에 저장
        private Quaternion _OriginRot;       //레티클 회전값이 변경되기 때문에 저장

        public bool UseNormal
        {
            set { _UseNormal = value; }
            get { return _UseNormal; }            
        }

        public Transform ReticleTransform
        {
            get { return _ReticleTR; }
        }

        void Awake()
        {
            _OriginScale = _ReticleTR.localScale;
            _OriginRot = _ReticleTR.localRotation;
        }

        void Start()
        {
            _ReticleTR = _Image.transform;
        }

        public void Hide()
        {
            _Image.enabled = false;
        }

        public void Show()
        {
            _Image.enabled = true;
        }
            
        public void SetPosition()
        {
            //레티클을 기본위치로 수정
            _ReticleTR.position = _Camera.position + _Camera.forward * _DefaultDistance;

            _ReticleTR.localScale = _OriginScale * _DefaultDistance;

            _ReticleTR.localRotation = _OriginRot;
        }

        public void SetPosition(RaycastHit hit)
        {
            _ReticleTR.position = hit.point;
            _ReticleTR.localScale = _OriginScale * hit.distance;

            if (_UseNormal)
                _ReticleTR.rotation = Quaternion.FromToRotation(Vector3.forward, hit.normal);
            else
                _ReticleTR.localRotation = _OriginRot;
        }
    }
}



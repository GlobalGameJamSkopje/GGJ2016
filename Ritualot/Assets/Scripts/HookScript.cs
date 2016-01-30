using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

namespace Assets.Scripts
{
    public class HookScript : MonoBehaviour
    {
        private float _boxSpeed = 1f;
        private float _forceSpeed = 0.3f;
        private bool _flag = true;

        private bool _canRotate = true;
        private bool _canShowForce = false;

        private float _winAngle = -0.25f;
        private float _winAngleThreshold = 0.05f;
        private float _winForce = 0.7f;
        private float _winForceThreshold = 0.1f;
        
        private bool _forwardForce = true;

        public Image ForceImage;

        void Start()
        {
            ForceImage.enabled = false;
        }

        void Update()
        {
            ForceImage.fillAmount = GetForceAmount();
            SetForwardForceFlag();

            ShowHideForceImage();

            if (_canRotate)
                DoBoxRotation();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _canRotate = false;
                _canShowForce = true;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                _canRotate = true;
                _canShowForce = false;

                if (IsCorrectAngle() && IsCorrectForce())
                    Debug.Log("Bravo go pogodi agolot i force-to" + transform.rotation.z + "  " + ForceImage.fillAmount);
                else
                    Debug.Log("BOT");
            }
        }

        private bool IsCorrectForce()
        {
            return ForceImage.fillAmount >= _winForce - _winForceThreshold
                    && ForceImage.fillAmount <= _winForce + _winForceThreshold;
        }
        private bool IsCorrectAngle()
        {
            return transform.rotation.z > _winAngle - _winAngleThreshold
                    && transform.rotation.z < _winAngle + _winAngleThreshold;
        }

        private void DoBoxRotation()
        {
            Quaternion boxRotation = transform.rotation;

            boxRotation.z += _boxSpeed * Time.deltaTime * (_flag ? -1 : 1);
            transform.rotation = boxRotation;

            if (Math.Abs(transform.rotation.z) > 0.5f)
                _flag = !_flag;
        }

        private void ShowHideForceImage()
        {
            ForceImage.enabled = _canShowForce;

            if (!_canShowForce)
                ForceImage.fillAmount = 0;
        }

        private void SetForwardForceFlag()
        {
            if (_forwardForce && ForceImage.fillAmount >= 0.99f)
                _forwardForce = false;
            else
            {
                if (ForceImage.fillAmount <= 0.01f)
                {
                    _forwardForce = true;
                }
            }
        }

        private float GetForceAmount()
        {
            float forceFillAmount = ForceImage.fillAmount;
            forceFillAmount += _forceSpeed * Time.deltaTime * (_forwardForce ? 1 : -1);
            Mathf.Clamp01(forceFillAmount);

            return forceFillAmount;
        }
    }
}



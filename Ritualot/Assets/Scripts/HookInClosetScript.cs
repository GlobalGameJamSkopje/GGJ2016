using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class HookInClosetScript : MonoBehaviour
    {
        private bool _flag = true;
        private GameObject _parent;
        private float _speed = 0.3f;
        public GameObject QueenWakeUp;

        void Start()
        {
            _parent = transform.parent.gameObject;
        }

        void Update()
        {
            Quaternion currentRotation = transform.rotation;
            currentRotation.z += _speed * Time.deltaTime * (_flag ? 1 : -1);
            transform.rotation = currentRotation;

            if (System.Math.Abs(transform.rotation.z) > 0.25)
                _flag = !_flag;

            _parent.transform.Translate(0, Input.GetAxis("Vertical") * 10f * Time.deltaTime, 0);
        }
        public void OnCollisionEnter2D(Collision2D target)
        {
            QueenWakeUp.SetActive(true);
        }
    }
}


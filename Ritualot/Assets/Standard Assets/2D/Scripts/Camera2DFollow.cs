using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class Camera2DFollow : MonoBehaviour
    {
        public Transform Player1, Player2;
        private Transform _target;
        private bool _flag;
        public float damping = 1;
        public float lookAheadFactor = 3;
        public float lookAheadReturnSpeed = 0.5f;
        public float lookAheadMoveThreshold = 0.1f;

        private float m_OffsetZ;
        private Vector3 m_LastTargetPosition;
        private Vector3 m_CurrentVelocity;
        private Vector3 m_LookAheadPos;

        public GameObject EndScreen, CharacterSelect;
        public Animator CharacterSelectedAnimator;


        // Use this for initialization
        private void Start()
        {
            Player1.GetComponent<Platformer2DUserControl>().enabled = true;
            Player2.GetComponent<Platformer2DUserControl>().enabled = false;
            _target = Player1;
            m_LastTargetPosition = _target.position;
            m_OffsetZ = (transform.position - _target.position).z;
            transform.parent = null;
        }


        // Update is called once per frame
        private void Update()
        {
            // only update lookahead pos if accelerating or changed direction
            float xMoveDelta = (_target.position - m_LastTargetPosition).x;

            bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

            if (updateLookAheadTarget)
            {
                m_LookAheadPos = lookAheadFactor*Vector3.right*Mathf.Sign(xMoveDelta);
            }
            else
            {
                m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime*lookAheadReturnSpeed);
            }

            Vector3 aheadTargetPos = _target.position + m_LookAheadPos + Vector3.forward*m_OffsetZ;
            Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);

            transform.position = newPos;

            m_LastTargetPosition = _target.position;
        }
        
        public void ChangePlayer()
        {
            if (_flag)
            {
                _target = Player1;
                Player1.GetComponent<Platformer2DUserControl>().enabled = true;
                Player2.GetComponent<Platformer2DUserControl>().enabled = false;
            }
               
           
            else
            {
                _target = Player2;
                Player1.GetComponent<Platformer2DUserControl>().enabled = false;
                Player2.GetComponent<Platformer2DUserControl>().enabled = true;
            }
                

            _flag = !_flag;
        }
        public void Cheat()
        {
            EndScreen.SetActive(true);

            Player1.GetComponent<Platformer2DUserControl>().enabled = false;
            Player2.GetComponent<Platformer2DUserControl>().enabled = false;
            //Code for Finnised anim ( place it on canvas) 
            Debug.Log("Code for Finnised anim ( place it on canvas) ");


        }
        public void ActivateCharacterSelect()
        {
            EndScreen.SetActive(false);
            CharacterSelect.SetActive(true);
        }
        
        public void ActivateCharacterSelected()
        {
            CharacterSelectedAnimator.SetTrigger("Do");
        }

    }
}

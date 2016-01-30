using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class HookScript : MonoBehaviour
    {
        private bool _left = true;
        private bool _canRotate = true;
        private bool _rightAngle = false;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
         
            if(_canRotate)
            {
                if (_left)
                {
                    Debug.Log(transform.rotation.z);
                    Quaternion temp = transform.rotation;
                    temp.z += 1f * Time.deltaTime;
                    transform.rotation = temp;
                    if (transform.rotation.z > 0.5f)
                    {
                        _left = false;
                    }
                }
                else if (!_left)
                {          
                    Debug.Log(transform.rotation.z);
                    Quaternion temp = transform.rotation;
                    temp.z -= 1f * Time.deltaTime;
                    transform.rotation = temp;
                    if (transform.rotation.z < -0.5f)
                    {
                        _left = true;
                    }
                }

            }   
            

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _canRotate = false;
                if (transform.rotation.z <= -0.2f && transform.rotation.z >= -0.3f)
                {
                    //Debug.Log("Ah pogodi");
                    _rightAngle = true;
                    
                }
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                _canRotate = true;
            }
            if(_rightAngle)
            {
                _canRotate = false;
                Debug.Log("Bravo go pogodi agolot" + transform.rotation.z);
                _rightAngle = false;

            }
        }
    }
}



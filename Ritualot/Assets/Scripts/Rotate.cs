using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class Rotate : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(0, 0, 360f * Time.deltaTime);
        }
    }

}

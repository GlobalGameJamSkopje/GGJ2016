using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class PlatformPlayer : MonoBehaviour
    {
        void OnCollisionEnter2D(Collision2D target)
        {
            if (target.gameObject.tag == Enums.Tags.MovingPlatform.ToString())
                transform.parent = target.gameObject.transform;
        }
        
        void OnCollisionExit2D(Collision2D target)
        {
            if (target.gameObject.tag == Enums.Tags.MovingPlatform.ToString())
                transform.parent = null;
        }
    }
}


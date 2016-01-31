using UnityEngine;

namespace Assets.Scripts
{
    public class DittaRoomCheckComplete : MonoBehaviour
    {
        public GameObject Player;


        public void CheckComplete()
        {
            Player.GetComponent<HookScript>().CheckIfHit();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEditor;

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

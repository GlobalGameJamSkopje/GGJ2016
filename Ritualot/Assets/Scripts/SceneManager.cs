using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class SceneManager : MonoBehaviour
    {
        public GameObject Intro, CharacterInfo, MissionMenu;

        public void ActivateCharacterInfo(bool instantText)
        {
            Intro.SetActive(false);
            CharacterInfo.SetActive(true);
            MissionMenu.SetActive(false);

            if (instantText)
                CharacterInfo.GetComponentInChildren<RpgTextWritter>().InstantGuiText();                          
        }
        public void ActivateMissionMenu()
        {
            Intro.SetActive(false);
            CharacterInfo.SetActive(false);
            MissionMenu.SetActive(true);            
        }
        public void LoadRunner()
        {
            Application.LoadLevel(1);
        }
    }
}

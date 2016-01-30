using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class HomeSceneManager : MonoBehaviour
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
            SceneManager.LoadScene("RunnerScene");  
        }
    }
}

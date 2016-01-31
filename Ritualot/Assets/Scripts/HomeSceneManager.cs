using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class HomeSceneManager : MonoBehaviour
    {
        public GameObject Intro, CharacterIntro, CharacterInfo, MissionMenu, StockingIntro;
        public GameObject StockingIntroCharacterText, StockingIntroChooseCharacter, StockingIntroCharacterChosen;
        public GameObject CharacterButton;
        public GameObject FirstMissionText;

        public void ActivateCharacterIntro()
        {
            CharacterIntro.SetActive(true);

            Intro.SetActive(false);
            CharacterInfo.SetActive(false);
            MissionMenu.SetActive(false);
            StockingIntro.SetActive(false);
        }
        public void ActivateCharacterInfo(bool instantText)
        {
            CharacterInfo.SetActive(true);

            CharacterIntro.SetActive(false);
            Intro.SetActive(false);
            MissionMenu.SetActive(false);
            StockingIntro.SetActive(false);

            if (instantText)
                CharacterInfo.GetComponentInChildren<RpgTextWritter>().InstantGuiText();                          
        }
        public void ActivateMissionMenu()
        {
            MissionMenu.SetActive(true);

            CharacterInfo.SetActive(false);
            CharacterIntro.SetActive(false);
            Intro.SetActive(false);            
            StockingIntro.SetActive(false);
        }
        public void ActivateStockingIntro()
        {
            StockingIntro.SetActive(true);

            MissionMenu.SetActive(false);
            CharacterInfo.SetActive(false);
            CharacterIntro.SetActive(false);
            Intro.SetActive(false);            
        }
        public void ActivateStockingIntroChooseCharacter()
        {
            ActivateStockingIntro();

            CharacterButton.GetComponent<Button>().interactable = true;

            StockingIntroChooseCharacter.SetActive(true);
            StockingIntroCharacterText.SetActive(false);
            StockingIntroCharacterChosen.SetActive(false);
        }
        public void ActivateStockingIntroCharacterChoosen()
        {
            ActivateStockingIntro();

            CharacterButton.GetComponent<Button>().interactable = false;

            StockingIntroCharacterChosen.SetActive(true);
            StockingIntroCharacterText.SetActive(false);
            StockingIntroChooseCharacter.SetActive(false);            
        }

        public void LoadRunner()
        {
            SceneManager.LoadScene("RunnerScene");  
        }
        public void Start()
        {
            if(GameManager.Instance.Finished)
            {
                ActivateMissionMenu();
                FirstMissionText.SetActive(true);
            }
        }
    }
}

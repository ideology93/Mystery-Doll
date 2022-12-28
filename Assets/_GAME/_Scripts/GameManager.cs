using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NLO
{


    public class GameManager : MonoBehaviour
    {
        [SerializeField] BaggieController bc;
        [SerializeField] CameraManager cm;

        [SerializeField] GameObject phase3_ui, checkmark;
        private static GameManager _instance;
        [SerializeField] GameObject step1, step2, step3, step4, infinity, upgradeUI;
        [SerializeField] private bool phase0, phase1, phase2, phase3;
        [SerializeField] GameObject content;
        public GameObject objectIssueDELETEIT;
        public List<GameObject> fluxyList = new List<GameObject>();





        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                    Debug.LogError("Game Manager is null");
                return _instance;
            }
        }
        public bool Phase0 { get => phase0; set => phase0 = value; }
        public bool Phase1 { get => phase1; set => phase1 = value; }
        public bool Phase2 { get => phase2; set => phase2 = value; }
        public bool Phase3 { get => phase3; set => phase3 = value; }


        private void Awake()
        {
            _instance = this;
            PlayerPrefs.SetInt("currentItem", 14);

        }

        public void Exit()
        {
            Application.Quit();
        }
        public void StartPhaseThree()
        {
            StartCoroutine(p3());
        }
        public void StartPhaseTwo()
        {
            StartCoroutine(p15());
        }
        public void StartBaggiePhase()
        {
            if (PlayerPrefs.GetInt("currentItem") <= 16)
            {
                
                StartCoroutine(p2());
                Invoke("ChangeAlpha", 0.4f);
            }
            else
            {
                bc.item = 3;

                StartPhaseThree();
            }
        }
        public IEnumerator p2()
        {
            yield return new WaitForSeconds(0.2f);
            GameManager.Instance.Phase1 = false;
            GameManager.Instance.Phase2 = true;
            cm.PhaseTwoCamera();

            step2.SetActive(false);
            step3.SetActive(true);
            yield return new WaitForSeconds(0.3f);
            ShutShitOff();

        }
        public IEnumerator p15()
        {
            yield return new WaitForSeconds(0.2f);
            cm.PhaseUpgrade();
            infinity.SetActive(false);
            Invoke("activateUI", 0.7f);
            yield return new WaitForSeconds(0.3f);
            ShutShitOff();

        }
        public IEnumerator p3()
        {

            if (bc.item >= 3)
            {

                yield return new WaitForSeconds(0.2f);
                GameManager.Instance.Phase2 = false;
                GameManager.Instance.Phase3 = true;
                cm.PhaseThreeCamera();
                checkmark.SetActive(true);
                phase3_ui.SetActive(true);
                step1.SetActive(false);
                step2.SetActive(false);
                step3.SetActive(false);
                step4.SetActive(true);

                Debug.Log("Unlocking");
                for (int i = 0; i < PlayerPrefs.GetInt("currentItem") - 1; i++)
                {
                    content.transform.GetChild(i).gameObject.SetActive(true);
                    bc.itemsToUnlock[i].gameObject.SetActive(true);
                }
            }
            yield return new WaitForSeconds(0.2f);
            ShutShitOff();
        }
        public void ShutShitOff()
        {
            foreach (GameObject item in fluxyList)
            {
                item.SetActive(false);
            }
        }
        public void activateUI()
        {
            upgradeUI.SetActive(true);
        }
        public void ChangeAlpha()
        {
            bc.ChangePlaneAlpha();
        }


    }
}
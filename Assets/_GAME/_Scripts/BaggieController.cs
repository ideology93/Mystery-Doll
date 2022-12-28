using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NLO.Tweens;
using HighlightPlus;
using DG.Tweening;

namespace NLO
{
    public class BaggieController : MonoBehaviour
    {
        [SerializeField] Transform openedBaggies;
        [SerializeField] GameObject phase3_ui;
        [SerializeField] CameraManager cameraManager;
        public List<Sprite> spritesToUnlock = new List<Sprite>();
        public List<GameObject> itemsToUnlock = new List<GameObject>();
        public GameObject itemUI;
        public Material planeMaterial;
        public Color targetColor;
        public int item = 0;
        public List<Baggie> baggies = new List<Baggie>();
        // private void OnEnable()
        // {
        //     EventManager.StartListening(GameEvents.BaggieSelected, delegate { SelectBaggie(); });
        // }
        // private void OnDisable()
        // {
        //     EventManager.StopListening(GameEvents.BaggieSelected, delegate { SelectBaggie(); });
        // }
        private void Start()
        {

        }
        public void SelectBaggie(Baggie baggie)
        {

            if (baggie.isSelected)
            {
                baggie.GetComponent<Animator>().Play("Open");
            }
            if (!baggie.isSelected)
            {
                baggie.GetComponent<Rigidbody>().isKinematic = true;
                baggie.transform.SetParent(openedBaggies);
                baggie.gameObject.GetComponent<Move>().PlayTween();
                baggie.gameObject.GetComponent<Rotate>().PlayTween();
                baggie.transform.GetChild(0).gameObject.SetActive(true);
                baggie.isSelected = true;
                return;
            }

        }
        public void DeParent()
        {
            openedBaggies.GetChild(0).gameObject.SetActive(false);
            openedBaggies.GetChild(0).SetParent(null);
        }
        public void ToggleHighlight()
        {
            foreach (var item in baggies)
            {
                if (item.GetComponent<HighlightEffect>().enabled)
                    item.GetComponent<HighlightEffect>().enabled = false;
                else
                    item.GetComponent<HighlightEffect>().enabled = true;
            }
        }
         public void ChangePlaneAlpha()
        {
            planeMaterial.DOColor(targetColor, 0.3f).Play();

        }

    }
}

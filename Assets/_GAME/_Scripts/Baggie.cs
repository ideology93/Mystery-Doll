using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NLO.Tweens;
namespace NLO
{
    public class Baggie : MonoBehaviour
    {
        public BaggieController bc;
        public bool isSelected;
        private int itemCount;
        public static int fakesprite;
        private void Start()
        {

            fakesprite = 0;
            }
        public void DoThisShitPlease()
        {
            StartCoroutine(Shit());
            Debug.Log("Shit");
            // bc.itemUI.SetActive(true);


            // Sprite sprite = bc.spritesToUnlock[PlayerPrefs.GetInt("currentItem")];
            // GameObject item = bc.itemsToUnlock[PlayerPrefs.GetInt("currentItem")];

            // item.SetActive(true);

            // bc.itemUI.transform.GetChild(0).
            // transform.GetChild(0).
            // GetComponent<Image>().sprite = sprite;
            // bc.itemUI.transform.GetChild(0).
            // transform.GetChild(0).GetComponent<Image>().SetNativeSize();

            // PlayerPrefs.SetInt("currentItem", PlayerPrefs.GetInt("currentItem") + 1);

            // if (PlayerPrefs.GetInt("currentItem") >= bc.itemsToUnlock.Count)
            // {
            //     bc.item = 3;
            // }

            // else
            //     bc.item++;

        }
        public IEnumerator Shit()
        {
            yield return new WaitForSeconds(1f);
            bc.itemUI.SetActive(true);
            Debug.Log("fakesprite index : " + fakesprite);

            // Sprite sprite = bc.spritesToUnlock[PlayerPrefs.GetInt("currentItem")];
            GameObject item = bc.itemsToUnlock[PlayerPrefs.GetInt("currentItem")];
            Sprite sprite = FakeClothes.Instance.sprites[fakesprite];

            fakesprite++;



            item.SetActive(true);

            bc.itemUI.transform.GetChild(0).
            transform.GetChild(0).
            GetComponent<Image>().sprite = sprite;

            bc.itemUI.transform.GetChild(0).
            transform.GetChild(0).GetComponent<Image>().SetNativeSize();

            PlayerPrefs.SetInt("currentItem", PlayerPrefs.GetInt("currentItem") + 1);

            if (PlayerPrefs.GetInt("currentItem") >= bc.itemsToUnlock.Count)
            {
                bc.item = 3;
            }
            else
                bc.item++;


        }

    }
}

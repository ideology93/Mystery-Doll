using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NLO.Tweens;
using DG.Tweening;
using UnityEngine.UI;
using System;

namespace NLO
{
    public class Upgrade : MonoBehaviour
    {
        public List<GameObject> models = new List<GameObject>();
        public List<GameObject> hair = new List<GameObject>();
        public GameObject thinnerui, hairui;
        public int modelInt = 0;
        public int hairInt = 0;
        public Text topRightText, hairText, thinText;



        public void ChangeModel()
        {
            Debug.Log("Changing model");
            Destroy(models[0], 0.05f);
            modelInt++;
            models[modelInt - 1].SetActive(false);
            models[modelInt].SetActive(true);
            int value = Int32.Parse(thinText.text);
            int newVal = value+1000;
            string topRightGetText = topRightText.text.Substring(0, 2);
            int newTopRightValue = Int32.Parse(topRightGetText) -1;
            topRightText.text = newTopRightValue.ToString() + " K";
            thinText.text = newVal.ToString();
            
        }
        public void ChangeHair()
        {
            Debug.Log("Changing hair");

            hairInt++;
            hair[hairInt - 1].SetActive(false);
            hair[hairInt].SetActive(true);
            int value = Int32.Parse(hairText.text);
            int newVal = value+1000;
            string topRightGetText = topRightText.text.Substring(0, 2);
            int newTopRightValue = Int32.Parse(topRightGetText) -1;
            topRightText.text = newTopRightValue.ToString() + " K";
            hairText.text = newVal.ToString();
        }
        public void ScaleAndChange()
        {
            models[modelInt].GetComponent<Scale>().PlayTween();
        }
        public void Disable()
        {
            models[modelInt].SetActive(false);
        }
        public void IncreasePrice()
        {

        }

    }

}

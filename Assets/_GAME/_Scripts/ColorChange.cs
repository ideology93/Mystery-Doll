using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
namespace NLO
{


    public class ColorChange : MonoBehaviour
    {
        [SerializeField] Color endColor;
        [Range(0, 10)]
        [SerializeField] float duration;
        [SerializeField] private Color _startColor;
        [SerializeField] private Material _FresnelColor, _TopColor, _LiquidColor, texMaterial;
        public Material opaqueMat;


        private void Start()
        {

            _startColor =
            GetComponent<Renderer>().
            material.
            GetColor("_LiquidColor");


        }
        public void ChangeColor()
        {
            StartCoroutine(ChangeWaterColor());

        }
        private IEnumerator ChangeWaterColor()
        {
            float tick = 0f;
            while (GetComponent<Renderer>().material.GetColor("_LiquidColor") != endColor)
            {
                tick += Time.deltaTime * 1;
                GetComponent<Renderer>().material.SetColor("_LiquidColor", Color.Lerp(_startColor, endColor, tick));
                GetComponent<Renderer>().material.SetColor("_TopColor", Color.Lerp(_startColor, endColor, tick));
                GetComponent<Renderer>().material.SetColor("_FresnelColor", Color.Lerp(_startColor, endColor, tick));
                yield return null;
            }
            GetComponent<Renderer>().material = opaqueMat;
            for (int i = 0; i < 100; i++)
            {

                float j = (float)i / 100;
                GetComponent<Renderer>().material.SetFloat("_Transparency", j);
                yield return new WaitForSeconds(0.005f);
            }
            EventManager.TriggerEvent(GameEvents.BarbieStirred, new Dictionary<string, object> { });
            // for (int i = 0; i < 10; i++)
            // {

            //     float j = (float)i/10  ;

            //     GetComponent<Renderer>().material.SetFloat("_XSlowness",  GetComponent<Renderer>().material.GetFloat("_XSlowness")-j);
                
            //     yield return new WaitForSeconds(0.1f);
            // }

        }

    }
}
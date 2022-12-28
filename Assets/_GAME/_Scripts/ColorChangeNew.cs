using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NLO
{
    public class ColorChangeNew : MonoBehaviour
    {

        [SerializeField] Color endColor;
        [Range(0, 10)]
        [SerializeField] float duration, _startFresnel, _endFresnel = -10, _startNormalStrength, _endNormalStrength = 1;
        [SerializeField] private Color _startColor, _endColor, _FresnelColor, _FresnelStartColor;
        [SerializeField] private Material _TopColor, _LiquidColor, texMaterial;
        public Color col = new Color(255, 0, 255, 1);
        public Material opaqueMat;
        public Material dollMaterial;


        private void Start()
        {
            Color col = new Color(255, 0, 255);
            // _FresnelStartColor = GetComponent<Renderer>().material.GetColor("_FresnelColor");
            _startNormalStrength = GetComponent<Renderer>().material.GetFloat("_NormalStrength");
            _startFresnel = GetComponent<Renderer>().material.GetFloat("_FresnelWeakness");
            _startColor =
            GetComponent<Renderer>().
            material.
            GetColor("_ShallowColor");

            // GetComponent<Renderer>().material.SetColor("_FresnelColor", new Color(133,242,255,1));




        }
        public void ChangeColor()
        {
            StartCoroutine(ChangeWaterColor());

        }
        private IEnumerator ChangeWaterColor()
        {

            float tick = 0f;
            float tickf = 0f;

            while (GetComponent<Renderer>().material.GetColor("_ShallowColor") != _endColor)
            {
                tick += Time.deltaTime * 0.5f;
                tickf += Time.deltaTime * 1;
                GetComponent<Renderer>().material.SetColor("_ShallowColor", Color.Lerp(_startColor, _endColor, tick));
                GetComponent<Renderer>().material.SetColor("_FresnelColor", Color.Lerp(_FresnelStartColor, col, tickf));
                GetComponent<Renderer>().material.SetFloat("_FresnelWeakness", GetComponent<Renderer>().material.GetFloat("_FresnelWeakness") - tick / 10);

                yield return null;
            }
            GameManager.Instance.StartPhaseTwo();
            EventManager.TriggerEvent(GameEvents.BarbieStirred, new Dictionary<string, object> { });
            for (int i = 0; i < 10; i++)
            {

                float j = (float)i / 10;

                yield return new WaitForSeconds(0.1f);
            }


        }
    }
}

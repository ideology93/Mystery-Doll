using System.Collections;
using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine.UI;


namespace NLO.Tweens
{
    public class WaterFill : MonoBehaviour
    {
        [Range(0.1f, 10)]
        [SerializeField] float fillDuration;
        [SerializeField] float endFill;
        [SerializeField] float fillValue;
        public CameraManager cm;

        [SerializeField] GameObject barbieUnrevealed;

        [SerializeField] GameObject waterPitcher;
        [SerializeField] GameObject btn;
        [SerializeField] ParticleSystem waterParticle;
        [SerializeField] Vector3 fillStartPosition;
        [SerializeField] Transform fillEndPosition;
        [SerializeField] Image fill;
        public GameObject slider;
        public GameObject upgradeUI;
        float fillvalue;
       
        private float _currentFill;
        private float startFill;
        float _elapsed = 0.00f;
        private Renderer _rend;
        public bool isButtonPressed { get; set; }


        void Start()
        {
            fill.fillAmount=0;
            GameManager.Instance.Phase0 = true;
            fillStartPosition = transform.position;
        }

        public void FillCup()
        {
            StartCoroutine(Fill());
        }
        public IEnumerator Fill()
        {
            while (_elapsed < fillDuration && isButtonPressed)
            {
                fillvalue += Time.deltaTime;
                transform.position = Vector3.Lerp(fillStartPosition, fillEndPosition.position, _elapsed / fillDuration);
                _elapsed += Time.deltaTime;
                // _rend.material.SetFloat("_Fill", fillValue);
                fill.fillAmount = fillvalue;
                yield return null;  
                if (_elapsed >= fillDuration)
                {

                    EventManager.TriggerEvent(GameEvents.WaterFilled, new Dictionary<string, object> { });

                    ControlPhase();

                }
            }
            isButtonPressed = false;
            
            Debug.Log("Changed cham");
            
        }
        public void ControlPhase()
        {
            waterPitcher.GetComponent<Rotate>().Rewind();
            waterPitcher.GetComponent<Move>().PlayTween();
            waterParticle.Stop();
            cm.PhaseOnePointFive();
            slider.SetActive(false);
            btn.SetActive(false);
            
            
        }
    }
}

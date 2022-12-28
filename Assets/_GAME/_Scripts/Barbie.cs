using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NLO.Tweens;
namespace NLO
{

    public class Barbie : MonoBehaviour
    {
        public bool isMoved;
        [SerializeField] GameObject revealedBarbie;

        private void OnEnable()
        {
            EventManager.StartListening(GameEvents.WaterFilled, delegate { GetComponent<Move>().PlayTween(); });
            EventManager.StartListening(GameEvents.BarbieStirred, delegate { ChangeBarbies(); });

        }
        private void OnDisable()
        {
            EventManager.StopListening(GameEvents.WaterFilled, delegate { GetComponent<Move>().PlayTween(); });
            EventManager.StopListening(GameEvents.BarbieStirred, delegate { ChangeBarbies(); });

        }   

        private void ChangeBarbies()
        {
            this.gameObject.SetActive(false);
            revealedBarbie.SetActive(true);
            EventManager.TriggerEvent(GameEvents.BarbieDone, new Dictionary<string, object> { });
        }
    }
}

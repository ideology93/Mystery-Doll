using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NLO.Tweens;

namespace NLO
{
    public class BarbieRevealed : MonoBehaviour
    {
        public bool isLifted;

        private void OnEnable()
        {
            EventManager.StartListening(GameEvents.BarbieDone, delegate { GetComponent<Move>().PlayTween(); });

        }
        private void OnDisable()
        {
            EventManager.StopListening(GameEvents.BarbieDone, delegate { GetComponent<Move>().PlayTween(); });

        }

    }
}

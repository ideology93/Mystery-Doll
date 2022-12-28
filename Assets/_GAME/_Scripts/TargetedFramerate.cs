using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NLO
{
    public class TargetedFramerate : MonoBehaviour
    {
        private void Awake()
        {
            Application.targetFrameRate = 60;
        }
    }
}

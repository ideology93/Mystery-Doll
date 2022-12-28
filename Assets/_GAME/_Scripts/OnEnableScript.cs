using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NLO
{
    public class OnEnableScript : MonoBehaviour
    {
        public ParticleSystem ps1, ps2;
        // Start is called before the first frame update
        public virtual void OnEnable()
        {
            ps1.Play();
            ps2.Play();
        }
    }
}

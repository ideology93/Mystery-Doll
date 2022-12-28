using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using NLO.Tweens;   

namespace NLO
{
    public class FakeClothes : GloballyAccessibleBase<FakeClothes>
    {
        public int i = 0;
        public List<GameObject> clothes = new List<GameObject>();
        public List<Sprite> sprites = new List<Sprite>();
        public GameObject baggie;
        public Vector3 DownBaggiePosition = new Vector3(3.32500005f,0.509000003f,-1.273f);
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                clothes[i].SetActive(true);
                i++;
                baggie.transform.DOLocalMove(DownBaggiePosition, 0.6f).Play();
            }
        }
    }
}

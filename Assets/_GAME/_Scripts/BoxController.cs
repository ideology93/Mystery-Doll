using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NLO
{
    public class BoxController : GloballyAccessibleBase<BoxController>
    {
        [SerializeField] public GameObject topBoxes;
        [SerializeField] public Transform spawnTop;
        [SerializeField] public GameObject bottomBoxes;
        [SerializeField] public Transform spawnBottom;
        public Color targetColor;
        public Transform targetPosition;
        public Transform spawnPositions;
        float speed = 0.2f;
        public GameObject plane;
        public bool isSelected;
        

       
        private void Update()
        {
            MoveBoxes();
        }

        public void MoveBoxes()
        {
            topBoxes.transform.Translate(Vector3.left * Time.deltaTime * speed, Space.Self);
            bottomBoxes.transform.Translate(Vector3.right * Time.deltaTime * speed, Space.Self);
        }
        public void ResetPosition(GameObject obj, string pos)
        {
            if (pos == "Top")
            {
                obj.transform.position = spawnTop.position;
            }
            else if (pos == "Bottom")
                obj.transform.position = spawnBottom.position;
        }
        public void ToggleController()
        {
            if (this.enabled)
                this.enabled = false;
            else
                this.enabled = true;
        }
    }

}

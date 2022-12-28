using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NLO
{
    public class ColorInfo : MonoBehaviour
    {
        public Color col;
        public Texture tex;
        private PaintController paintController;
        private void Start()
        {
            paintController = GameObject.Find("GameManager").GetComponent<PaintController>();
            
        }
        public void SetColor()
        {
            if (col != null)
                paintController.col = this.col;
                
             if (tex != null){

                
                paintController.tex = this.tex; }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NLO
{
    public class PaintController : MonoBehaviour
    {

        public GameObject itemToPaint;
        public Color col;
        public Texture tex;
        public Material matToEdit;


        public void PaintItem()
        {
            if (matToEdit == null)
            {
                itemToPaint.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", col);

            }
        }
        public void ApplyTexture()
        {
            itemToPaint.GetComponent<MeshRenderer>().material.SetTexture("_BaseMap", tex);
        }
        public void SetItemToPaint(GameObject itemToPaint)
        {
            this.itemToPaint = itemToPaint;
        }

    }
}

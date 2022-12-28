using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NLO.Tweens;
using UnityEngine.EventSystems;
using HighlightPlus;
namespace NLO
{


    public class RayCast : MonoBehaviour
    {
        public PaintController paintController;
        public BaggieController baggieController;
        [SerializeField] Camera mainCamera;
        public FakeClothes fk;
        RaycastHit hit;

        private Ray ray;

        void Update()
        {
            //change phase 

            if (Input.GetMouseButtonDown(0))
            {
                CastRay();
            }


        }
        public void CastRay()
        {
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(GameManager.Instance.Phase1);
                if (GameManager.Instance.Phase1)
                {
                    foreach (var move in hit.transform.gameObject.GetComponents<Move>())
                    {

                        if (move.TweenTag == "MoveDown" && !hit.transform.gameObject.GetComponent<Barbie>().isMoved)
                        {
                            move.PlayTween();
                            hit.transform.gameObject.GetComponent<Barbie>().isMoved = true;

                        }
                    }
                }
                if (GameManager.Instance.Phase2)
                {
                    if (hit.transform.tag == "Baggie")
                    {
                        if (!hit.transform.GetComponent<Baggie>().isSelected)
                            baggieController.ToggleHighlight();
                        baggieController.SelectBaggie(GimmeTheBaggie());
                        fk.baggie = hit.transform.gameObject;


                    }

                }
                if (GameManager.Instance.Phase3)
                {

                    if (!EventSystem.current.IsPointerOverGameObject())
                    {
                        if (hit.transform.gameObject.layer != 7)
                        {
                            paintController.itemToPaint = hit.transform.gameObject;
                        }

                    }

                }
                if (GameManager.Instance.Phase0)
                {
                    if (hit.transform.tag == "Box" && hit.transform.GetComponent<Box>().isOpenable && BoxController.Instance.isSelected)
                    {
                        Debug.Log("We're here");
                        hit.transform.GetComponent<Box>().anim.enabled = true;
                        hit.transform.GetComponent<Box>().anim.Play("Lid");
                    }
                    if (hit.transform.tag == "Box" && !BoxController.Instance.isSelected)
                    {
                        hit.transform.GetComponent<Box>().DoStuff();
                        BoxController.Instance.isSelected = true;


                    }


                }

            }
        }
        public Baggie GimmeTheBaggie()
        {
            if (hit.transform.tag == "Baggie")
            {
                return hit.transform.gameObject.GetComponent<Baggie>();
                
            }
            else
                return null;
        }

    }
}
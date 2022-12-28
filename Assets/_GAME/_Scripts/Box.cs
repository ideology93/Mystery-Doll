using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using NLO.Tweens;
namespace NLO
{
    public class Box : MonoBehaviour
    {
        public bool isTop;
        public GameObject plane;
        public bool isMoving;
        public Vector3 targetpos;
        public Color col;
        public Color targetColor;
        public Material planeMaterial;
        // public static bool isSelected;
        private bool colorIsChanged;
        public bool isOpenable;
        public Animator anim;
        public GameObject doll;
        public Transform targetParent;
        public CameraManager cm;
        public Move move;
        public GameObject doll_replacement;
        public GameObject waterPitcher;
        public GameObject step1, step2;


        private void Start()
        {
            targetpos = new Vector3(-4.40000057f, 2.03999996f, -1.66400003f);
            plane = BoxController.Instance.plane;
            planeMaterial = plane.GetComponent<Renderer>().material;
            col = plane.GetComponent<Renderer>().material.color;
            targetColor = BoxController.Instance.targetColor;
            anim = GetComponent<Animator>();
            isOpenable = false;


        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "BoxColliderTop")
            {
                Debug.Log("moved top");
                BoxController.Instance.ResetPosition(this.gameObject, "Top");
            }
            else if (other.tag == "BoxColliderBottom")
            {
                Debug.Log("moved bottom");
                BoxController.Instance.ResetPosition(this.gameObject, "Bottom");
            }
        }
        public void DoStuff()
        {
            transform.parent = BoxController.Instance.spawnPositions;
            isMoving = true;
            StartCoroutine(LerpPosition(BoxController.Instance.targetPosition.position, BoxController.Instance.targetPosition.rotation, 0.6f));
            // transform.position = Vector3.Lerp(transform.position, BoxController.Instance.targetPosition.position, 3);
            BoxController.Instance.ToggleController();
        }
        IEnumerator LerpPosition(Vector3 targetPosition, Quaternion targetRotation, float duration)
        {
            float time = 0;

            Vector3 startPosition = transform.position;
            Quaternion startRotation = transform.rotation;
            while (time < duration)
            {
                if (time >= 0.5f && !colorIsChanged)
                {
                    planeMaterial.DOColor(targetColor, 0.3f).Play();
                    colorIsChanged = true;
                }

                transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
                transform.rotation = Quaternion.Lerp(startRotation, targetRotation, time / duration);
                time += Time.deltaTime;

                yield return null;
            }

            transform.position = targetPosition;
            transform.rotation = targetRotation;
            isOpenable = true;

        }
        public void ChangeBarbieParent()
        {
            if (BoxController.Instance.isSelected)
            {
                targetColor.a = 0;
                // doll.transform.SetParent(targetParent.transform);
                this.GetComponent<Animator>().enabled = false;
                cm.PhaseZeroCamera();
                Invoke("ChangePlaneAlpha", 0.5f);


            }
        }
        public void ChangePlaneAlpha()
        {
            planeMaterial.DOColor(targetColor, 0.3f).Play().OnComplete(() => ChangeBarbies());
            Invoke("p2", 0.3f);
            waterPitcher.SetActive(true);
            step1.SetActive(false);
            step2.SetActive(true);
            // doll.transform.parent=null;
            // PlayThisTween(doll_replacement);
        }
        // public void P2()
        // {
        //     cm.PhaseOneCamera();
        // }
        public void ChangeBarbies()
        {
            doll_replacement.SetActive(true);
            doll.SetActive(false);
        }
        public void PlayThisTween(GameObject obj)
        {
            foreach (var move in obj.gameObject.GetComponents<Move>())
            {

                if (move.TweenTag == "MoveIn")
                {
                    move.PlayTween();
                    obj.transform.gameObject.GetComponent<Barbie>().isMoved = true;

                }
            }
        }



    }
}

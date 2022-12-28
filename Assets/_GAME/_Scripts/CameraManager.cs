using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


namespace NLO
{
    public class CameraManager : MonoBehaviour
    {
        private Camera main;
        public GameObject baggies;
        public GameObject doll;
        public Transform dollPosition;
        public GameObject phaseZero;
        public GameObject phaseOne;
        public GameObject phaseOnePointFive, phaseOnePointSix;
        public GameObject phaseTwo;
        public GameObject phaseThree;
        public GameObject phaseUpgrade;

        public GameObject phaseFour;
        public GameObject phaseFourFive;
        public GameObject phaseTwoPointFive;

        void Start()
        {
            main = Camera.main;
        }
        public void PhaseZeroCamera()
        {
            StartCoroutine(LerpPosition(phaseZero.transform.position, phaseZero.transform.rotation, 0.5f));
            StartCoroutine(MoveDoll(dollPosition.transform.position, dollPosition.transform.rotation, 0.5f));
        }
        public void PhaseOneCamera()
        {
            StartCoroutine(LerpPosition(phaseOne.transform.position, phaseOne.transform.rotation, 1));


        }
        public void PhaseOnePointFive()
        {
            StartCoroutine(LerpPosition(phaseOnePointFive.transform.position, phaseOnePointFive.transform.rotation, 1));

        }
        public void PhaseOnePointSix()
        {
            StartCoroutine(LerpPosition(phaseOnePointSix.transform.position, phaseOnePointSix.transform.rotation, 0.3f));
        }
        public void PhaseTwoCamera()
        {
            // StartCoroutine(LerpPosition(phaseTwo.transform.position, phaseTwo.transform.rotation, 1));
            main.transform.DORotateQuaternion(phaseTwo.transform.rotation, 1f).Play();
            main.transform.DOMove(phaseTwo.transform.position, 1f, false).Play().OnComplete(() => DropBaggies());
        }

        public void PhaseThreeCamera()
        {
            StartCoroutine(LerpPosition(phaseThree.transform.position, phaseThree.transform.rotation, 0.2f));
        }
        public void PhaseUpgrade()
        {
            StartCoroutine(LerpPosition(phaseUpgrade.transform.position, phaseUpgrade.transform.rotation, 0.5f));
        }
        public void PhaseFourCamera()
        {
            phaseFour.SetActive(true);
            phaseFour.transform.DOLocalRotate(phaseFourFive.transform.position, 2f, RotateMode.Fast);
            phaseFour.transform.DOMove(phaseFourFive.transform.position, 2.5f, false);
        }
        IEnumerator LerpPosition(Vector3 targetPosition, Quaternion targetRotation, float duration)
        {
            float time = 0;
            Vector3 startPosition = main.transform.position;

            Quaternion startRotation = main.transform.rotation;
            while (time < duration)
            {
                main.transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
                main.transform.rotation = Quaternion.Lerp(startRotation, targetRotation, time / duration);
                time += Time.deltaTime;
                yield return null;
            }
            main.transform.position = targetPosition;
            main.transform.rotation = targetRotation;
        }
        public IEnumerator MoveDoll(Vector3 targetPosition, Quaternion targetRotation, float duration)
        {
            float time = 0;
            Vector3 startPosition = doll.transform.position;

            Quaternion startRotation = doll.transform.rotation;
            while (time < duration)
            {
                doll.transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
                doll.transform.rotation = Quaternion.Lerp(startRotation, targetRotation, time / duration);
                time += Time.deltaTime;
                yield return null;
            }
            doll.transform.position = targetPosition;
            doll.transform.rotation = targetRotation;
        }
        public void DropBaggies()
        {
            baggies.SetActive(true);
        }
    }
}

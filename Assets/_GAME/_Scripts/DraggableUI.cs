using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NLO
{
    public class DraggableUI : MonoBehaviour

    {
        public ClothesManager cm;
        public Canvas canvas;
        public GameObject parent;
        public Vector2 startPos;
        private RectTransform rtransform;
        public Vector2 parentStartPos;
        private float ypos = -1500;
        public string objName, itemToFind;
        public GameObject desiredObject;
        private int siblingIndex, previousSiblingIndex;
          public GameObject equippedItems;
      
        private void Start()
        {
            equippedItems = GameObject.Find("EquippedItems");
            siblingIndex = transform.GetSiblingIndex();
            rtransform = GetComponent<RectTransform>();
            parent = transform.parent.gameObject;
            startPos = rtransform.anchoredPosition;
            parentStartPos = transform.parent.GetComponent<RectTransform>().anchoredPosition;
            objName = gameObject.name;

        }
        public void PointerDown_Handler(BaseEventData data)
        {

            transform.SetParent(canvas.gameObject.transform);
            itemToFind = (objName).ToString();
        }
        public void DragHandler(BaseEventData data)
        {

            PointerEventData pointerData = (PointerEventData)data;
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)canvas.transform, pointerData.position, canvas.worldCamera, out position);
            transform.position = canvas.transform.TransformPoint(position);
        }
        public void PointerUp_Handler(BaseEventData data)
        {
            if (rtransform.anchoredPosition.y < ypos)
            {
                SetParent();
            }

            else
            {

                
                cm.EquipClothes(itemToFind, parent, gameObject, siblingIndex, parentStartPos);
                transform.gameObject.SetActive(false);
                transform.SetParent(equippedItems.transform);
                LayoutRebuilder.ForceRebuildLayoutImmediate(transform as RectTransform);
            }
        }

        public void SetParent()
        {
            
            transform.SetParent(parent.transform);
            transform.SetSiblingIndex(siblingIndex);
            transform.parent.GetComponent<RectTransform>().anchoredPosition = parentStartPos;
            LayoutRebuilder.ForceRebuildLayoutImmediate(transform as RectTransform);

        }
    }

}

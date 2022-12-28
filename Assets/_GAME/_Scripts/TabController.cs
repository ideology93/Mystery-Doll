using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
namespace NLO
{
    public class TabController : MonoBehaviour
    {
        Color colorToActivate;
        Color colorToDeactivate;
        [SerializeField] ScrollbarController bars;
        private void Start()
        {
            Image img = GetComponent<Image>();
            colorToActivate = img.color;
            colorToDeactivate = img.color;
            colorToActivate.a = 1;
            colorToDeactivate.a = 0.5f;

        }
        [SerializeField] private List<GameObject> tabs = new List<GameObject>();
        public void SwitchTabs(BaseEventData eventData)
        {
            int index = EventSystem.current.currentSelectedGameObject.transform.GetSiblingIndex();
            Debug.Log("Tab index is : " + index);
            for (int i = 0; i < tabs.Count; i++)
            {

                if (i == index)
                {
                    bars.bars[index].SetActive(true);
                    
                    tabs[index].GetComponent<Image>().color = colorToActivate;
                }
                else
                {
                    bars.bars[i].SetActive(false);
                    tabs[i].GetComponent<Image>().color = colorToDeactivate;
                }
            }


        }


    }
}

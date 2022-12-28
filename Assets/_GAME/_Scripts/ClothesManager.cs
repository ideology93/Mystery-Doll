using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NLO
{
    public class ClothesManager : MonoBehaviour
    {
        public List<GameObject> clothesTwo = new List<GameObject>();

        public Texture tex;
        public GameObject equippedItems;



        public void EquipClothes(string name, GameObject parent, GameObject sprite, int siblingIndex, Vector2 parentStartPos)
        {
            // go through list of all available clothes
            foreach (var item in clothesTwo)
            {
                
                if (item.name == name)
                {
                    Debug.Log("Item in list: " + item.name + " requested item name : " + name);
                    for (int i = 0; i < item.transform.parent.childCount; i++)
                    {
                        Debug.Log("Parent name of item is: " +  item.transform.parent.name);
                        if (item.transform.parent.GetChild(i).gameObject.activeSelf)
                        {
                            Debug.Log("Found object name is : "+item.transform.parent.GetChild(i).gameObject.name);
                            for (int j = 0; j < equippedItems.transform.childCount; j++)
                            {
                               
                                if (equippedItems.transform.GetChild(j).tag == sprite.tag)
                                {
                                    equippedItems.transform.GetChild(j).gameObject.SetActive(true);     
                                    LayoutRebuilder.ForceRebuildLayoutImmediate(equippedItems.transform.GetChild(j).transform as RectTransform);
                                    Debug.Log("jesus christ help : "+ equippedItems.transform.GetChild(j).transform.name);
                                    equippedItems.transform.GetChild(j).transform.SetParent(parent.transform);
                                }
                                Debug.Log("Here");
                            }

                            item.transform.parent.GetChild(i).gameObject.SetActive(false);
                        }
                    }
                    if (item.activeSelf)
                    {
                        MeshRenderer rend = item.GetComponent<MeshRenderer>();
                        if (rend == null)
                        {
                            Debug.Log("Item is : " + item.name);
                            item.transform.GetChild(0).GetComponent<MeshRenderer>().material.SetColor("_BaseColor", Color.white);
                            item.transform.GetChild(0).GetComponent<MeshRenderer>().material.SetTexture("_BaseMap", tex);
                            item.transform.GetChild(0).GetComponent<MeshRenderer>().material.SetTexture("_MainTex", tex);
                        }

                    }
                    else
                        item.SetActive(true);
                    Debug.Log(item.name);
                    return;
                }

            }

        }
    }
}

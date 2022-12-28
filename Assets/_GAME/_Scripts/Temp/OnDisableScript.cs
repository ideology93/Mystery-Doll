using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDisableScript : MonoBehaviour
{
    [SerializeField] GameObject go;
    [SerializeField] ParticleSystem ps1, ps2;
    //attach this to a button to make it do something once its disabled, easier to control gameflow
    public virtual void OnDisable()
    {
        this.go.SetActive(true);
    }
    
}

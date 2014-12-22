using System;
using UnityEngine;
using System.Collections;

// Can't display hp of something that has none!
[RequireComponent(typeof (Damagable))]
public class HealthBar : MonoBehaviour
{
    private Damagable damagable;
    // The actual healthbar gameobject
    private GameObject barObject;


    private void Start()
    {
        damagable = GetComponent<Damagable>();
    }

    private void Update()
    {
        if (!damagable) {
            throw new Exception("HealthBar component is attached to an enemy without the damagable behaviour");
        }
        if (damagable.Hp != damagable.MaxHp) {
            barObject.SetActive(true);
            
        }
        else {
            barObject.SetActive(false);
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMachine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // if (other.TryGetComponent(out CollectedCoffee collectedCoffee))
        // {
        //     collectedCoffee.AddStrawbery();
        // }

        if (other.CompareTag("Collected"))
        {
            other.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
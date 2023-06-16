using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMachine : MonoBehaviour
{
    private Animator animcherry;

    private void Start()
    {
        animcherry = GetComponent<Animator>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        animcherry.SetBool("Active", false);

        if (other.gameObject.CompareTag("Chocolate"))
        {
            PlayerController.Instance.UpdateMoney(10);

            other.transform.GetChild(3).gameObject.SetActive(true);
            other.gameObject.tag = "Cherry";
            animcherry.SetBool("Active", true);
            return;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        animcherry.SetBool("Active", false);
    }
}

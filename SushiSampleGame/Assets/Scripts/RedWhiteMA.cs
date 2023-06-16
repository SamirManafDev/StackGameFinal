using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RedWhiteMA : MonoBehaviour
{
    private Animator anim;
   

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        anim.SetBool("Active", true);

        
        if (other.gameObject.CompareTag("Collected"))
        {
            PlayerController.Instance.UpdateMoney(4);

            other.transform.GetChild(0).gameObject.SetActive(true);
            other.gameObject.tag = "RedCream";
            
            return;
        }
        if (other.gameObject.CompareTag("RedCream"))
        {
            PlayerController.Instance.UpdateMoney(6);

            other.transform.GetChild(1).gameObject.SetActive(true);
            other.gameObject.tag = "WhiteCream";
            return;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("Active", false);
    }
}

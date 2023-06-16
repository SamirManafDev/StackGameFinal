using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocolateMA : MonoBehaviour
{
    private Animator animChoco;

    private void Start()
    {
        animChoco = GetComponent<Animator>();
       
    }
    private void OnTriggerEnter(Collider other)
    {
        animChoco.SetBool("Active", false);
        if (other.gameObject.CompareTag("WhiteCream"))
        {
            PlayerController.Instance.UpdateMoney(8);

            animChoco.SetBool("Active", true);
            other.transform.GetChild(2).gameObject.SetActive(true);
            other.gameObject.tag = "Chocolate";
            
            return;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        animChoco.SetBool("Active", false);
    }
}

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SellMachine : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private Transform endTransform;
    [SerializeField] private TextMeshProUGUI Score;
    private float _money;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collected"))
        {
            _money += 2;
            PlayerController.Instance.UpdateMoney(-2);

            StackHolder.Instance.coffeeList.Remove(other.transform);
            other.transform.DOMove(endTransform.position,1f);
            Score.text = _money.ToString() + "$";
        }
        if (other.gameObject.CompareTag("RedCream"))
        {
            _money += 4;
            PlayerController.Instance.UpdateMoney(-4);

            StackHolder.Instance.coffeeList.Remove(other.transform);
            other.transform.DOMove(endTransform.position, 1f);
            Score.text = _money.ToString();
        }
        if (other.gameObject.CompareTag("WhiteCream"))
        {
            _money += 6;
            PlayerController.Instance.UpdateMoney(-6);

            StackHolder.Instance.coffeeList.Remove(other.transform);
            other.transform.DOMove(endTransform.position, 1f);
            Score.text = _money.ToString();
        }
        if (other.gameObject.CompareTag("Chocolate"))
        {
            PlayerController.Instance.UpdateMoney(-8);

            _money += 8;
            StackHolder.Instance.coffeeList.Remove(other.transform);
            other.transform.DOMove(endTransform.position, 1f);
            Score.text = _money.ToString();
        }
        if (other.gameObject.CompareTag("Cherry"))
        {
            _money += 10;
            StackHolder.Instance.coffeeList.Remove(other.transform);
            other.transform.DOMove(endTransform.position, 1f);
            Score.text = _money.ToString();
        }
        
        _particleSystem.Play();
    }
}

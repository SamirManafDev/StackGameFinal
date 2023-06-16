using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CollectedCoffee collectedCoffee))
        {
            _particleSystem.Play();
            int index = StackHolder.Instance.coffeeList.IndexOf(other.transform);

            for (int i = Mathf.Max(1, index); i < StackHolder.Instance.coffeeList.Count; i++)
            {
                Transform coffee = StackHolder.Instance.coffeeList[i];

                coffee.tag = "Collectable";

                Vector3 jumpPosition = coffee.position + new Vector3(Random.Range(-4, 4), 0, Random.Range(-4, 4));

                StackHolder.Instance.coffeeList.Remove(coffee);

                coffee.DOJump(jumpPosition, 0.5f, 1, 0.3f);
            }
        }
    }
}
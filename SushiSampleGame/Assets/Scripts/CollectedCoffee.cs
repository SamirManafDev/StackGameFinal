using Unity.VisualScripting;
using UnityEngine;

public class CollectedCoffee : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            other.AddComponent<CollectedCoffee>();
            other.tag = "Collected";
            StackHolder.Instance.coffeeList.Add(other.transform);
            PlayerController.Instance.UpdateMoney(2);

            //UIManager.Instance.UpdateCoinValue();

            StackHolder.Instance.AnimateCollectables();
        }
    }
}

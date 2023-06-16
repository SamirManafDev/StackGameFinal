using System;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float verticalSpeed;
    [SerializeField] private float speed;
    [SerializeField] private float lerpSpeed;
    [SerializeField] private Vector3 stackOffset;
    [SerializeField] private TMP_Text moneyText;


    [SerializeField] List<Transform> handTransforms;

    bool isEnd;

    public static PlayerController Instance;

    public int money;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        StackHolder.Instance.coffeeList.Add(transform.GetChild(0));
    }

    void Update()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0f, verticalSpeed) * (speed * Time.deltaTime);

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -8f, 8f),
            transform.position.y,
            transform.position.z);
        if (isEnd)
            return;

        FollowStack();
    }

    public void UpdateMoney(int price)
    {
        money += price;
        moneyText.text = money.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            other.AddComponent<CollectedCoffee>();
            StackHolder.Instance.coffeeList.Add(other.transform);

            //UIManager.Instance.UpdateCoinValue();
            PlayerController.Instance.UpdateMoney(2);

            other.tag = "Collected";
            StackHolder.Instance.AnimateCollectables();
        }
        else if (other.CompareTag("Finish"))
        {
            isEnd = true;
            speed = 0;
            for (int i = 1; i < StackHolder.Instance.coffeeList.Count; i++)
            {
                Transform currentPos = StackHolder.Instance.coffeeList[i].transform;

                currentPos.DOMove(handTransforms[UnityEngine.Random.Range(0, handTransforms.Count)].position, 0.5f);

            }
        }
    }

    private void FollowStack()
    {
        for (int i = 1; i < StackHolder.Instance.coffeeList.Count; i++)
        {
            Vector3 prevPos = StackHolder.Instance.coffeeList[i - 1].transform.position + stackOffset;
            Vector3 currentPos = StackHolder.Instance.coffeeList[i].transform.position;

            StackHolder.Instance.coffeeList[i].transform.position =
                Vector3.Lerp(currentPos, prevPos, lerpSpeed * Time.deltaTime);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Umaru : MonoBehaviour
{
    [SerializeField] private TextMeshPro coinText;
    [SerializeField] private float speed;
    [SerializeField] private List<CoinDestory> coinList;
    [SerializeField] List<Transform> doorTransform;

    private int coinAmount;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.UpArrow)))
        {
            transform.position += new Vector3(0, 1, 0) * speed;
        }
        if (Input.GetKeyDown(KeyCode.S) || (Input.GetKeyDown(KeyCode.DownArrow)))
        {
            transform.position += new Vector3(0, -1, 0) * speed;
        }
        if (Input.GetKeyDown(KeyCode.A) || (Input.GetKeyDown(KeyCode.RightArrow)))
        {
            transform.position += new Vector3(1, 0, 0) * speed;
        }
        if (Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            transform.position += new Vector3(-1, 0, 0) * speed;
        }
        CoinScore();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            doorInteract();
        }
    }
    private void CoinScore()
    {
        foreach (CoinDestory coin in coinList)
        {
            if (coin != null)
            {
                float coinPickDistance = 1f;
                if (Vector3.Distance(transform.position, coin.transform.position) < coinPickDistance)
                {
                    AddCoin();
                    coin.SelfDestory();
                }
            }
        }
    }
    private void doorInteract()
    {
      
        for (int i = 0; i < doorTransform.Count; i++)
        {
            Transform currdoor = doorTransform[i];
            //same with for each above

            float interactDistance = 1f;
            if (Vector3.Distance(transform.position, currdoor.transform.position) < interactDistance)
            {
                switch (currdoor.name)
                {
                    case "Door":
                        AddCoin();
                        AddCoin();
                        break;
                    case "Door1":
                        AddCoin();
                        AddCoin();
                        AddCoin();
                        break;
                }

            }
        }
    }
    private void AddCoin()
    {
        coinAmount++;
        coinText.text = coinAmount.ToString();
    }

}

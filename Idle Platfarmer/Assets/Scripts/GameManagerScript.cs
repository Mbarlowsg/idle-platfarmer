using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player
{
    public static float Money = 0; // Player Money
    public static float Mps = 1f; // Money Per Second
}

public class GameManagerScript : MonoBehaviour
{
    private TextMeshProUGUI _playerMoney;

    // Start is called before the first frame update
    void Start()
    {
        _playerMoney = GameObject.Find("Player Money").GetComponent<TextMeshProUGUI>();
        StartCoroutine(MoneyTimer());
    }

    // Update is called once per frame
    void Update()
    {
        _playerMoney.text = $"Money: {Player.Money}";
    }

    IEnumerator MoneyTimer()
    {
        Player.Money += Player.Mps;
        print(Player.Money);
        yield return new WaitForSeconds(1f);
        StartCoroutine(MoneyTimer());
    }
}

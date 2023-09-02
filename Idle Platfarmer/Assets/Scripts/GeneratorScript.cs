using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GeneratorScript : MonoBehaviour
{
    // Logic
    private bool _isPlayerOnTop;

    // Instance Properties
    [SerializeField]
    private int _type;

    [SerializeField]
    private float _basePrice,
        _moneyMultiplier;

    private Generator instance = new Generator();

    // Start is called before the first frame update
    void Awake()
    {
        instance.Type = _type;
        instance.GeneratorCount = 1;
        instance.BasePrice = _basePrice;
        instance.CurrentCost = _basePrice;
        instance.MoneyMultiplier = _moneyMultiplier;
        GeneratorManagerScript.AddGeneratorToList(instance);
        Debug.Log(instance);
    }

    void Start() { }

    // Update is called once per frame
    void Update()
    {
        if (_isPlayerOnTop && Input.GetKeyDown(KeyCode.E) && Player.Money >= instance.CurrentCost)
        {
            instance.UpgradeGenerator();
            Debug.Log(instance);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        _isPlayerOnTop = true;
        print("ontop");
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        _isPlayerOnTop = false;
        print("off");
    }
}

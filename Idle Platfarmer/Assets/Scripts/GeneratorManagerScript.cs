using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Generator
{
    public int Type;
    public float BasePrice,
        CurrentCost,
        MoneyMultiplier,
        MoneyPerSecond;
    public int GeneratorCount;

    public void UpgradeGenerator()
    {
        Player.Money -= CurrentCost;
        GeneratorCount++;
        CurrentCost = (float)Math.Ceiling(BasePrice * Math.Pow(1.15, GeneratorCount));
    }
}

public class GeneratorManagerScript : MonoBehaviour
{
    public static List<Generator> GeneratorList = new List<Generator>();

    private static int totalGeneratorCount;

    // Start is called before the first frame update
    void Awake()
    {
        totalGeneratorCount = 0;
    }

    void Start()
    {
        InvokeRepeating("AddMoneyPerSecond", 1f, 1f);
    }

    // Update is called once per frame
    void Update() { }

    void AddMoneyPerSecond()
    {
        float moneyGenerated = 0;
        foreach (var generatorInstance in GeneratorList)
        {
            // moneyGenerated += CalculateMoneyPerSecond(generatorInstance);
            moneyGenerated += generatorInstance.MoneyMultiplier * generatorInstance.GeneratorCount;
            print(moneyGenerated);
        }
        Player.Money += moneyGenerated;
        print(Player.Money);
    }

    public float CalculateMoneyPerSecond(Generator generatorInstance)
    {
        generatorInstance.MoneyPerSecond =
            generatorInstance.MoneyMultiplier * generatorInstance.GeneratorCount;
        return generatorInstance.MoneyPerSecond;
    }

    public static void AddGeneratorToList(Generator instance)
    {
        GeneratorList.Add(instance);
        totalGeneratorCount++;
    }
}

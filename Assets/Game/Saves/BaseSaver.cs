using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSaver : MonoBehaviour
{
    public static void UpdateCoinsSaves(int coinsValue)
    {
        PlayerPrefs.SetInt("Coins", coinsValue);
    }

    public static int GetCoinsSaves =>
        PlayerPrefs.GetInt("Coins");

    public static void UpdateCongratulatorySaves()
    {
        PlayerPrefs.SetInt("Congratulatory", 1);
    }

    public static int GetCongratulatorySaves =>
        PlayerPrefs.GetInt("Congratulatory");



}

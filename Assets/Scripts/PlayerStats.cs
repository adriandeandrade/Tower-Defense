using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

    public static int Money;
    public static int Lives;
    public static int Rounds;

    [SerializeField] private int startMoney = 400;
    [SerializeField] private int startLives = 20;
    
    void Start()
    {
        Money = startMoney;
        Lives = startLives;
        Rounds = 0;
    }
}

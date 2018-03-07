using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    [SerializeField] private Text moneyText;

    private void Update()
    {
        moneyText.text = PlayerStats.Money.ToString() + "$";
    }
}

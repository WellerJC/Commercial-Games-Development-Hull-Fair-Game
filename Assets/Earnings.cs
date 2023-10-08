using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Earnings : MonoBehaviour
{
    [SerializeField]
    public int moneyLeft;

    public TextMeshProUGUI mPlayerFinanceTextBox;

    private void Update()
    {
        mPlayerFinanceTextBox.text = "Money made:\r\n" + "£" + moneyLeft.ToString();
    }

    public void ProcedeWithTransaction(int cost)
    {
        moneyLeft = moneyLeft - cost;
    }
}

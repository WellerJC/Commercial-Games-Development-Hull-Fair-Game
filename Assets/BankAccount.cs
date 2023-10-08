using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BankAccount : MonoBehaviour
{
    [SerializeField]
    public int moneyLeft;

    public TextMeshProUGUI mPlayerFinanceTextBox;

    private void Update()
    {
        mPlayerFinanceTextBox.text = "£" + moneyLeft.ToString();
    }

    public void ProcedeWithTransaction(int cost)
    {
        moneyLeft = moneyLeft - cost;
    }
}

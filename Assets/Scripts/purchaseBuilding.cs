using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class purchaseBuilding : MonoBehaviour
{
    public GameObject bankAccount;
    public GameObject building;
    public GameObject costerror;
    public AudioSource error, purchase;
    public int buildingCost;
    public TextMeshProUGUI costText;

    private void Start()
    {
        costText.text = "£" + buildingCost.ToString();
    }

    public void AttemptPurchase()
    {
        if(buildingCost > bankAccount.GetComponent<BankAccount>().moneyLeft)
        {
            error.Play();
            costerror.SetActive(true);
        }
        else
        {
            purchase.Play();
            BuildingSystem.Instantiate(building);
            bankAccount.GetComponent<BankAccount>().ProcedeWithTransaction(buildingCost);
        }
    }
}

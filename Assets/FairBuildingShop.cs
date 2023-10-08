using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairBuildingShop : MonoBehaviour
{
    public GameObject mBuildingShopUI;

    // Start is called before the first frame update
    void Start()
    {
        mBuildingShopUI.SetActive(false);
    }

    public void OpenBuildingShopUI()
    {
        mBuildingShopUI.SetActive(true);
    }

    public void CloseBuildingShopUI()
	{
        mBuildingShopUI.SetActive(false);
	}
}

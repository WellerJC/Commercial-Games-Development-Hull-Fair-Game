using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyingRides : MonoBehaviour
{
    public int mPlayerFinance = 9000;

	//Dynamic cost of Rides
	public int mDodgemsPrice = 200;
	public int mDropperPrice = 200;
	public int mFerrisWheelPrice = 200;
	public int mHookADuckPrice = 200;
	public int mHelterSkelterPrice = 200;
	public int mSimulatorPrice = 200;
	public int mMerryGoRoundPrice = 200;
	public int mStarFlyerPrice = 200;
	public int mPirateShipPrice = 200;

	//Text Box for PLayer Finance in GameScene
	public TextMeshProUGUI mPlayerFinanceTextBox;

	//Text Boxes of the Prices in Building Shop
	public TextMeshProUGUI mDodgemsPriceText;
	public TextMeshProUGUI mDropperPriceText;
	public TextMeshProUGUI mFerrisWheelPriceText;
	public TextMeshProUGUI mHookADuckPriceText;
	public TextMeshProUGUI mHelterSkelterPriceText;
	public TextMeshProUGUI mSimulatorPriceText;
	public TextMeshProUGUI mMerryGoRoundPriceText;
	public TextMeshProUGUI mStarFlyerPriceText;
	public TextMeshProUGUI mPirateShipPriceText;

	//Fair ride GameObjects from Scenes Folder
	public GameObject mDodgems;
	public GameObject mDropper;
	public GameObject mFerrisWheel;
	public GameObject mHookADuck;
	public GameObject mHelterSkelter;
	public GameObject mSimulator;
	public GameObject mMerryGoRound;
	public GameObject mStarFlyer;
	public GameObject mPirateShip;

	public FairBuildingShop UIController;
	public BuildingSystem buildingSystem;

	private void Start()
	{
		mDodgemsPriceText.text = "£" + mDodgemsPrice.ToString();
		mDropperPriceText.text = "£" + mDropperPrice.ToString();
		mFerrisWheelPriceText.text = "£" + mFerrisWheelPrice.ToString();
		mHookADuckPriceText.text = "£" + mHookADuckPrice.ToString();
		mHelterSkelterPriceText.text = "£" + mHelterSkelterPriceText.ToString();
		mSimulatorPriceText.text = "£" + mSimulatorPriceText.ToString();
		mMerryGoRoundPriceText.text = "£" + mMerryGoRoundPriceText.ToString();
		mStarFlyerPriceText.text = "£" + mStarFlyerPriceText.ToString();
		mPirateShipPriceText.text = "£" + mPirateShipPriceText.ToString();
	}
	private void Update()
	{
		mPlayerFinanceTextBox.text = "£" + mPlayerFinance.ToString();
	}
	public void BuyDodgems()
	{
		if( mPlayerFinance - mDodgemsPrice > 0)
		{
			mPlayerFinance -= mDodgemsPrice;
			CloseStoreAndBuild(mDodgems);
		}

		
	}
    public void BuyDropper()
    {
        if (mPlayerFinance - mDropperPrice > 0)
        {
            mPlayerFinance -= mDropperPrice;
            CloseStoreAndBuild(mDropper);
        }


    }
    public void CloseStoreAndBuild(GameObject building)
	{
		UIController.CloseBuildingShopUI();
		buildingSystem.Building = building;
	}
}

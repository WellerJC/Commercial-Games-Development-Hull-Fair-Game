using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatingSystem : MonoBehaviour
{
    public GameObject star1, star2, star3, star4, star5;
    public Earnings overall;
    public PlayPauseClock clock;
    // Start is called before the first frame update
    void Start()
    {
        clock.AlterClock();
        overall = GameObject.FindGameObjectWithTag("BankAcoount").GetComponent<Earnings>();

        if (overall.moneyLeft > 5000)
        {
            star1.SetActive(true);
            if (overall.moneyLeft > 10000)
            {
                star2.SetActive(true);
                if(overall.moneyLeft > 15000)
                {
                    star3.SetActive(true);
                    if(overall.moneyLeft > 20000)
                    {
                        star4.SetActive(true);
                        if(overall.moneyLeft > 25000)
                        {
                            star5.SetActive(true);
                        }
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

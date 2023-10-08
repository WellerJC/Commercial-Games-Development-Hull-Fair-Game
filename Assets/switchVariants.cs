using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchVariants : MonoBehaviour
{
    public GameObject animated;
    public GameObject nonanimated;
    public DigitalClock dc;
    // Start is called before the first frame update
    void Start()
    {
        dc = GameObject.FindGameObjectWithTag("DigitalClock").GetComponent<DigitalClock>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dc.phase == false)
        {
            animated.SetActive(true);
            nonanimated.SetActive(false);
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DigitalClock : MonoBehaviour
{
    TimeManager tm;
    TextMeshProUGUI display;
    public bool phase = true;
    public GameObject outro;
    // Start is called before the first frame update
    void Start()
    {
        tm = FindObjectOfType<TimeManager>();
        display = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        display.text = tm.Clock24Hour();
        if(display.text == "18:00")
        {
            if (phase == true)
            {
                Debug.Log("Phase 1 finished");
                phase = false;
            }
          
        }
        else if(display.text == "23:59")
        {
            if (phase == false)
            {
                outro.SetActive(true);
            }
        }
    }
}

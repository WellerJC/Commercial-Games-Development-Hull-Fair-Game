using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPauseClock : MonoBehaviour
{

    public void AlterClock()
    {
        TimeManager dc = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();
        if(dc.enabled == false)
        {
            dc.enabled = true;
        }
        else if(dc.enabled == true)
        {
            dc.enabled = false;
        }
    }
}

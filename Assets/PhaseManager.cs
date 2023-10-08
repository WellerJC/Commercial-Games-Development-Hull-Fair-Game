using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PhaseManager : MonoBehaviour
{
    public Material skyMaterial, openPhase;
    public GameObject popup, tilemap, button1, button2;
    public DigitalClock dc;
    public bool alert = true, end = false;
    public AudioSource prep;
    public AudioSource open, crowd;
    // Start is called before the first frame update
    void Start()
    {        
        dc = GameObject.FindGameObjectWithTag("DigitalClock").GetComponent<DigitalClock>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dc.phase == false && alert == true)
        {
            prep.Pause(); open.Play(); crowd.Play();
            RenderSettings.skybox = skyMaterial;
            tilemap.GetComponent<TilemapRenderer>().material = openPhase;
            popup.SetActive(true); button1.SetActive(false); button2.SetActive(false);
            alert = false;
        }

        
    }
    
}

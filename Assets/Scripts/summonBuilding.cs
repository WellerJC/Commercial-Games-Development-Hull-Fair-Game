using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class summonBuilding : MonoBehaviour
{
    public GameObject gameObject, spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateObject()
    {
        GameObject building = Instantiate(gameObject);
        building.transform.position = spawnPoint.transform.position;
    }
}

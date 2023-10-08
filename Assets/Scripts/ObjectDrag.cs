using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDrag : MonoBehaviour
{
    private Vector3 offset;
    private CameraManager cameraManager;
    public GameObject buildingSystem;
    public PlaceableObject thisObject;

    private void Start()
    {
        buildingSystem = GameObject.FindGameObjectWithTag("BuildingSystem");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if(buildingSystem.GetComponent<BuildingSystem>().objectToPlace = thisObject)
            {
                transform.Rotate(0, 90, 0);
            }
        }
    }

    private void OnMouseDown()
    {
        buildingSystem.GetComponent<BuildingSystem>().objectToPlace = thisObject;
        offset = transform.position - BuildingSystem.GetMouseWorldPosition();
    }

    private void OnMouseDrag()
    {
        cameraManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraManager>();
        cameraManager.enabled = false;     
        Vector3 pos = BuildingSystem.GetMouseWorldPosition() + offset;
        transform.position = BuildingSystem.current.SnapCoordinateToGrid(pos);
    }

    private void OnMouseUp()
    {
        cameraManager.enabled = true;
    }
}

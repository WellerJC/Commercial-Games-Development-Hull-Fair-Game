using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingSystem : MonoBehaviour
{
    public static BuildingSystem current;

    public GridLayout gridLayout;
    private Grid grid;
    [SerializeField] private Tilemap MainTilemap;
    [SerializeField] private TileBase whiteTile;
    [SerializeField] private TileBase redTile;

    public GameObject Building;

    public PlaceableObject objectToPlace;

    public AudioSource error, construction;
    #region Unity Methods

    private void Awake()
    {
        current = this;
        grid = gridLayout.gameObject.GetComponent<Grid>();
    }

    private void Update()
    {
        
        if (objectToPlace)
        {
            // User Confirms Placement
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (CanBePlaced(objectToPlace))
                {
                    objectToPlace.Place(); construction.Play();
                    Vector3Int start = gridLayout.WorldToCell(objectToPlace.GetStartPosition());
                    MainTilemap.BoxFill(start, whiteTile, start.x, start.y, start.x + objectToPlace.Size.x, start.y + objectToPlace.Size.y);
                }
                else
                {
                    error.Play();
                    Vector3Int start = gridLayout.WorldToCell(objectToPlace.GetStartPosition());
                    MainTilemap.BoxFill(start, redTile, start.x, start.y, start.x + objectToPlace.Size.x, start.y + objectToPlace.Size.y);
                }
                // Change System to Update Live, Showing Green Tiles if the Building is Placeable and Red is not. All Other Tiles Show as White. Think Editor Mode://
            }
            // User Cancels Placement
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                Destroy(objectToPlace.gameObject);
            }

            // Following Needs Reworking, Destroying "PlaceableObject" Just Prevents The Object from Being Placed. Either Remove the GameObject or Return it to Original Position.
        }
    }

    #endregion

    #region Utils

    public static Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            return raycastHit.point;
        }
        else
        {
            return Vector3.zero;
        }
    }

    public Vector3 SnapCoordinateToGrid(Vector3 position)
    {
        Vector3Int cellPos = gridLayout.WorldToCell(position);
        position = grid.GetCellCenterWorld(cellPos);
        return position;
    }

    private static TileBase[] GetTilesBlock(BoundsInt area, Tilemap tilemap)
    {
        TileBase[] array = new TileBase[area.size.x * area.size.y * area.size.z];
        int counter = 0;

        foreach (var v in area.allPositionsWithin)
        {
            Vector3Int pos = new Vector3Int(v.x, v.y, 0);
            array[counter] = tilemap.GetTile(pos);
            counter++;
        }

        return array;
    }

    #endregion

    #region Building Placement

    public void InitializeWithObject(GameObject buildingPrefab)
    {
        Vector3 position = SnapCoordinateToGrid(new Vector3(0,-0.2f,0));

        GameObject obj = Instantiate(buildingPrefab, position, Quaternion.identity);
        objectToPlace = obj.GetComponent<PlaceableObject>();
        obj.AddComponent<ObjectDrag>();
    }

    private bool CanBePlaced(PlaceableObject placeableObject)
    {
        BoundsInt area = new BoundsInt();
        area.position = gridLayout.WorldToCell(objectToPlace.GetStartPosition());
        area.size = placeableObject.Size;
        area.size = new Vector3Int(area.size.x + 1, area.size.y + 1, area.size.z);

        TileBase[] baseArray = GetTilesBlock(area, MainTilemap);

        foreach (var b in baseArray)
        {
            if (b == whiteTile)
            {
                return false;
            }
        }

        return true;
    }
    #endregion
}
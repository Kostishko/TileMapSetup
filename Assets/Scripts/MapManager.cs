using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// TileMap controller
public class MapManager : MonoBehaviour
{

    // List of all tile layers
    [SerializeField] private List<Tilemap> mapList;
    
    void Awake()
    {
        // Create root reference for MapManager
        GameManager<MapManager>.manager=this;
    }

    void Update()
    {
        // check tile system for example
        if(Input.GetMouseButtonUp(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint( Input.mousePosition);
            Instantiate(GetTileData(mousePosition));
            print(GetTileData(mousePosition).description);
        }
    }


    // return sum of all tile effects from all layers on specific position
    public CustomTileData GetTileData (Vector2 worldPosition)
    {       
        //  for scriptable object doesn't work usual instantinate
        CustomTileData _currentTileData = ScriptableObject.CreateInstance<CustomTileData>();
        
        // data from tile of first layer. Now it more look like workaround
        if(GetTileBase(worldPosition,mapList[0]) is CustomRuleTile firstTile)
        {   
            _currentTileData =  firstTile.customTileData.CopyTileData();
        }
        //start from second layer
        for (int i=1; i<=mapList.Count-1; i++)
        {                
            var baseTile = GetTileBase(worldPosition, mapList[i]);
            
            if (baseTile !=null )
            {
                if (baseTile is CustomRuleTile tile)
                {   
                    _currentTileData.DataPlusData(tile.customTileData);
                }
            }
        }      
        
        // take a tile
        TileBase GetTileBase(Vector2 pos, Tilemap map) 
        {
            Vector3Int gridPosition = map.WorldToCell(worldPosition);   
            return map.GetTile(gridPosition);
        }


        return _currentTileData;

    }







}

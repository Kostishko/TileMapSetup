using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu (fileName = "New Rule Tile", menuName = "Tiles/Rule Tile")]
public class CustomRuleTile : RuleTile
{

    [SerializeField] public CustomTileData customTileData;

    //[SerializeField] public float defence, speed;
    public Color setColor;

    
    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        base.GetTileData(position, tilemap, ref tileData);

        // add Color control
        tileData.color = setColor;
        tileData.flags = TileFlags.LockColor;
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="newTileData", menuName ="Tiles/newTileData")]
// CustomData of every cell in special class for return that data to unit
public class CustomTileData : ScriptableObject 
{
    
[SerializeField] public float defence, speed;
[SerializeField] public string description;



public CustomTileData DataPlusData ( CustomTileData DataTwo)
{
    this.defence+=DataTwo.defence;
    this.speed+=DataTwo.speed;
    this.description+= ", "+ DataTwo.description;
    return this;
}


// copy data in other instance. 
public CustomTileData CopyTileData ()
{
    var copyData = ScriptableObject.CreateInstance<CustomTileData>();
    copyData.defence = this.defence;
    copyData.speed = this.speed;
    copyData.description  =this.description;

    return copyData;
}



}

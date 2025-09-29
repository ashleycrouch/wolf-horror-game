using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "NewTile", menuName = "Tiles/Example Tile")]
public class OurTile : TileBase
{
    public Sprite sprite;

    ScriptableObject storyData;

    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        tileData.sprite = sprite;
        // You can also set other properties like color, transform, game object, etc.
        // tileData.color = Color.white;
        // tileData.transform = Matrix4x4.identity;
        // tileData.gameObject = null;
    }

    public override bool GetTileAnimationData(Vector3Int position, ITilemap tilemap, ref TileAnimationData tileAnimationData)
    {
        // Return true if your tile has animation, and set animation data here
        return false;
    }


    public override void RefreshTile(Vector3Int position, ITilemap tilemap)
    {
        // Override this to refresh neighboring tiles if needed
        tilemap.RefreshTile(position);
    }
}

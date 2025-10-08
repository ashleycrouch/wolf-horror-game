using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.UI;

public enum WolfPack
{
    None,       // Default
    White_Wolf, // Player,
    Dena,       // Alpha,
    Kovan,      // Beta,
    Mekki,      // Scout,
    Benti,      // Artemis,
    Tomak       // Apollo
}

[CreateAssetMenu(fileName = "New Wolf", menuName = "Dialogue/Wolf")]
public class Wolf : Speaker
{
    public WolfPack packname;
    public void Initialize(string nickname, Sprite headshot, WolfPack packname)
    {
        base.Initialize(nickname, headshot);
        this.packname = packname;
    }
}

using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.UI;

public enum WolfPack
{
    None,
    Player,
    Alpha,
    Beta,
    Scout,
    Artemis,
    Apollo
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

using UnityEngine;

public enum WolfPack
{
    None,
    Alpha,
    Beta
}

[CreateAssetMenu(fileName = "Wolf", menuName = "Scriptable Objects/Wolf")]
public class Wolf : ScriptableObject
{
    public string nickname;
    public WolfPack packname;
    public Sprite headshot;
    public Wolf(string nickname, WolfPack packname, Sprite headshot)
    {
        this.nickname = nickname;
        this.packname = packname;
        this.headshot = headshot;
    }
}

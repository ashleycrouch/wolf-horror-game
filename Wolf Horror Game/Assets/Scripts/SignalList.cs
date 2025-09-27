using deVoid.Utils;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.PlayerSignals
{
    public class PlayerHealthChange : ASignal<int> { }
    public class PlayerHealthUpdate : ASignal<int> { }
    public class PlayerDeath : ASignal<GameObject> { }
}

namespace Project.UISignals
{

}

namespace Project.WorldSignals
{

}

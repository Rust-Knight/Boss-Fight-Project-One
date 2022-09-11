using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Slower : Enemy
{
    protected override void PlayerImpact(Player player)
    {
        player.Kill();
    }
}

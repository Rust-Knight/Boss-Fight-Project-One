using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : CollectibleBase
{
    protected override void Collect(Player player)
    {
        //player.IncreaseHealth(_healthAdded);
        //ScoreManager.instance.AddPoint();
        player.addCoinPoints();
    }

    
}

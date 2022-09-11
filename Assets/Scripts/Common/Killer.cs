using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : Enemy 
{
    protected override void PlayerImpact(Player player)

    //protected: Allow a member item to only be accessed from internal or derived source.

    //private: Allow a member item to only be accessed from its owner.

    // If one is protected, they both need to be.

    {
        // base.PlayerImpact(Player); Calling base.MethodName() will run everything in the base method, and then do additional things that you specify            
        player.Kill(); // calling the player kill function from the player script 
    }
}

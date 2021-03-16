using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogPlayers : MonoBehaviour
{
    
    public void zCatch()
    {
        var player = this.gameObject.name;
        Debug.Log(player + " Catch");
    }

    public void zSpit()
    {
        var player = this.gameObject.name;
        Debug.Log(player + " Spit");
    }
}

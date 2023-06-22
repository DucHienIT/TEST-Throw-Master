using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSpawner : Spawner
{
    private static StoneSpawner instance;
    public static StoneSpawner Instance { get { return instance; } }

    public static string stone_1 = "Stone_1";


    protected override void Awake()
    {
        base.Awake();
        if (StoneSpawner.instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        StoneSpawner.instance = this;
    }

}

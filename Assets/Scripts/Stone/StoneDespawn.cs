using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneDespawn : DespawnByDistance
{
    public override void DespawnObject()
    {
        StoneSpawner.Instance.Despawn(transform.parent);
    }
}

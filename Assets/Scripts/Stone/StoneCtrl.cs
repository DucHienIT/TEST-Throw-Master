using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneCtrl : DucHienMonoBehaviour
{
    [SerializeField] protected StoneFly stoneFly;
    public StoneFly StoneFly { get { return this.stoneFly; } }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadStoneFly();
    }
    protected virtual void LoadStoneFly()
    {
        if (this.stoneFly != null) return;
        this.stoneFly = GetComponentInChildren<StoneFly>();
        Debug.Log("LoadStoneFly: " + this.stoneFly);
    }
}

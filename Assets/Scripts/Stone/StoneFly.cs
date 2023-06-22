using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneFly : DucHienMonoBehaviour
{
    [SerializeField] protected float moveSpeed = 1f;
    [SerializeField] protected Vector3 direction = Vector3.right;

    protected virtual void Update()
    {
        transform.parent.Translate(this.direction * this.moveSpeed * Time.deltaTime);
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        this.moveSpeed = 7f;
    }
    public virtual void ChangeRotationFly(Vector3 value)
    {
        direction = value;
    }
}

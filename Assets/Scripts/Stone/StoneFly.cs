using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StoneFly : DucHienMonoBehaviour
{
    [SerializeField] protected float moveSpeed = 1f;
    [SerializeField] protected Vector3 movementDirection = Vector3.right;

    protected virtual void Update()
    {
        transform.parent.Translate(this.movementDirection * this.moveSpeed * Time.deltaTime);
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        this.moveSpeed = 7f;
    }
    

}

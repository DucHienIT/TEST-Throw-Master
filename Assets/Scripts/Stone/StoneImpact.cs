using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class StoneImpact : DucHienMonoBehaviour
{
    [SerializeField] protected BoxCollider2D boxCollider2D;
    [SerializeField] protected Rigidbody2D rigidbody2D;

    [SerializeField] protected StoneCtrl stoneCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
        this.LoadRigidbody();
        this.LoadStoneCtrl();
    }
    protected virtual void LoadStoneCtrl()
    {
          if (this.stoneCtrl != null) return;
        this.stoneCtrl = transform.parent.GetComponent<StoneCtrl>();
        Debug.Log("LoadStoneCtrl: " + this.stoneCtrl);
    }    

    protected virtual void LoadSphereCollider()
    {
        if (this.boxCollider2D != null) return;
        this.boxCollider2D = GetComponent<BoxCollider2D>();
        this.boxCollider2D.isTrigger = true;
        Debug.Log("LoadSphereCollider: " + this.boxCollider2D);
    }

    protected virtual void LoadRigidbody()
    {
        if (this.rigidbody2D != null) return;
        this.rigidbody2D = GetComponent<Rigidbody2D>();
        this.rigidbody2D.isKinematic = true;
        Debug.Log("LoadRigidbody: " + this.rigidbody2D);
    }
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (CheckIsEnemy(other.transform))
        {
            StoneSpawner.Instance.Despawn(transform.parent);
            return;
        }

        if (other.CompareTag("verticalWall"))
        {
            ChangeRotation(180f);
            return;
        }
        ChangeRotation(0f);

    }

    protected virtual bool CheckIsEnemy (Transform transform)
    {
        if (transform.parent.name == "Enemy")
        {
            return true;
        }
        return false;
    }

    protected virtual void ChangeRotation(float value)
    {
        
        float angle = -transform.parent.rotation.eulerAngles.z + value;
        transform.parent.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

}


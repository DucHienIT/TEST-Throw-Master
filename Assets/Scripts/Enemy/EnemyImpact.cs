using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyImpact : DucHienMonoBehaviour
{
    [SerializeField] protected BoxCollider2D boxCollider2D;
    [SerializeField] protected Rigidbody2D rigidbody2D;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBoxCollider2D();
        this.LoadRigidbody();
    }
    protected virtual void LoadBoxCollider2D()
    {
        if (this.boxCollider2D != null) return;
        this.boxCollider2D = GetComponent<BoxCollider2D>();
        this.boxCollider2D.isTrigger = true;
        Debug.Log("LoadBoxCollider2D: " + this.boxCollider2D);
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
        Debug.Log("OnTriggerEnter2D: " + other.transform.name);
        LevelManager.Instance.CompleteLevel();
    }
}

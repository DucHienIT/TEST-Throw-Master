using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterThrow : DucHienMonoBehaviour
{
    [SerializeField] protected bool throwStone = false;
    private Animator animator;
    private bool hasThrown = false; // Biến để kiểm tra xem đã ném đá hay chưa

    protected override void OnEnable()
    {
        base.OnEnable();
        hasThrown = true; 
    }
    protected override void Start()
    {
        animator = transform.parent.GetComponentInChildren<Animator>();
    }

    protected virtual void Update()
    {
        this.SetThrow();
        this.ThrowStone();
    }

    protected virtual void ThrowStone()
    {
        if (!this.throwStone || hasThrown) return; // Kiểm tra đã giữ và thả và chưa ném đá
        animator.SetBool("isThrowing", this.throwStone);

        // Tính toán góc giữa đối tượng bắn và vị trí chuột
        Vector3 direction = this.GetMousePosition() - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        Transform newBullet = StoneSpawner.Instance.Spawn(StoneSpawner.stone_1, transform.position, rotation);
        if (newBullet == null) return;
        newBullet.gameObject.SetActive(true);
        this.throwStone = false;
        hasThrown = true; // Đánh dấu đã ném đá

    }

    protected virtual void SetThrow()
    {
        this.throwStone = InputManager.Instance.IsThrowing;
        if (!this.throwStone)
        {
            hasThrown = false; // Đặt lại biến hasThrown khi không còn giữ nút ném đá
        }
    }
    protected virtual Vector3 GetMousePosition()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return mousePosition;
    }
}

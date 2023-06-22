using UnityEngine;

public class InputManager : DucHienMonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance { get { return instance; } }

    [SerializeField] protected float onTouch;
    public float OnTouch { get { return this.onTouch; } }

    protected bool isHolding = false;
    protected bool isThrowing = false;
    public bool IsThrowing { get { return this.isThrowing; } }

    protected override void Awake()
    {
        base.Awake();
        if (InputManager.instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        InputManager.instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    protected virtual void Update()
    {
        this.GetTouchScreen();
    }

    protected virtual void GetTouchScreen()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isHolding = true;
            isThrowing = false;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (isHolding)
            {
                isThrowing = true;
            }
            isHolding = false;
        }
    }
}

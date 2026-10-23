using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, InputSystem_Actions.IPlayerVActions
{
    private InputSystem_Actions inputAction;
    private InputAction move, jump;
    private Rigidbody2D rb;

    void Start()
    {
        move = InputSystem.actions.FindAction("Move");
        jump = InputSystem.actions.FindAction("Jump");
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 vec = move.ReadValue<Vector2>();
        Vector3 dir = new Vector3(vec.x, 0, vec.y);

        transform.Translate(dir * 10 * Time.deltaTime);
    }

    private void OnEnable()
    {
        inputAction.Enable();
    }

    private void OnDisable()
    {
        inputAction.Disable();
    }

    private void Awake()
    {
        inputAction = new InputSystem_Actions();
        inputAction.PlayerV.SetCallbacks(this);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        if (jump.WasPressedThisFrame())
        {
            rb.gravityScale *= -1;
        }
    }
}
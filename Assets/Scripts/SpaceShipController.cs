using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceShipController : MonoBehaviour
{
    [SerializeField] float linearVelocity = 3f;
    [SerializeField] public InputActionReference move;
    [SerializeField] public InputActionReference shoot;
    [SerializeField] public InputActionReference pause;
    [SerializeField] GameObject prefabShot;
    [SerializeField] Transform shootingPoint;
    Rigidbody2D rb2D;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        move.action.started += OnMove;
        move.action.canceled += OnMove;
        move.action.performed += OnMove;

        shoot.action.started += OnShoot;

        pause.action.performed += OnPause;
    }

    void OnEnable()
    {
        move.action.Enable();
        shoot.action.Enable();
        pause.action.Enable();
    }

    void Update()
    {
        rb2D.linearVelocity = rawMove * linearVelocity;
    }

    void OnDisable()
    {
        move.action.Disable();
        shoot.action.Disable();
        pause.action.Disable();
    }

    Vector2 rawMove = Vector2.zero;
    private void OnMove(InputAction.CallbackContext context)
    {
        rawMove = context.action.ReadValue<Vector2>();
    }

    private void OnShoot(InputAction.CallbackContext context)
    {
        if (Time.timeScale == 0f) return;

        Instantiate(prefabShot, shootingPoint.position, Quaternion.identity);
    }

    private void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            FindFirstObjectByType<PauseMenu>().TogglePause();
        }
    }
}

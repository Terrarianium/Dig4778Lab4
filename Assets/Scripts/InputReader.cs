using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    [SerializeField] private InputActionAsset controls;

    [SerializeField] private string actionMapName = "Gameplay";

    [SerializeField] private string move = "Move";
    [SerializeField] private string shoot = "Shoot";
    [SerializeField] private string resetGame = "Reset";

    private InputAction moveAction;
    private InputAction shootAction;
    private InputAction resetGameAction;

    public Vector2 MoveInput { get; private set; }
    public bool ShootTrigger { get; private set; }
    public bool ResetGameTrigger { get; private set; }


    public static InputReader Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        moveAction = controls.FindActionMap(actionMapName).FindAction(move);
        shootAction = controls.FindActionMap(actionMapName).FindAction(shoot);
        resetGameAction = controls.FindActionMap(actionMapName).FindAction(resetGame);

        RegisterInputAction();

    }

    void RegisterInputAction()
    {
        moveAction.performed += context => MoveInput = context.ReadValue<Vector2>();
        moveAction.canceled += context => MoveInput = context.ReadValue<Vector2>();

        shootAction.performed += context => ShootTrigger = true;
        shootAction.canceled += context => ShootTrigger = false;

        resetGameAction.performed += context => ResetGameTrigger = true;
        resetGameAction.canceled += context => ResetGameTrigger = false;

    }

    private void OnEnable()
    {
        moveAction.Enable();
        shootAction.Enable();
        resetGameAction.Enable();
    }
}

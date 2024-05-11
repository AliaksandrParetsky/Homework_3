using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private TouchControls touchControls;
    private CreateScene createScene;
    private bool flag;
    private float speed = 10f;

    private void Awake()
    {
        touchControls = new TouchControls();
    }

    private void Start()
    {
        touchControls.Touch.TouchPress.started += ctx => StartTouch(ctx);
        touchControls.Touch.TouchPress.canceled += ctx => EndTouch(ctx);

        createScene = GetComponent<CreateScene>();
    }

    private void Update()
    {
        if (flag)
        {
            createScene.starSparrows[SelectObj.index].transform.RotateAround(createScene.starSparrows[SelectObj.index].transform.position,
                Vector3.up, speed * Time.deltaTime);
        }
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        flag = true;
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        flag = false;

        createScene.starSparrows[SelectObj.index].transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    private void OnEnable()
    {
        touchControls.Enable();
    }

    private void OnDisable()
    {
        touchControls.Disable();
    }
}

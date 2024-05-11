using UnityEngine;
using UnityEngine.UI;

public class SelectObj : MonoBehaviour
{
    [SerializeField] private CreateScene createScene;

    [SerializeField] private Button buttonLeft;
    [SerializeField] private Button buttonRight;

    [HideInInspector] public static int index = 0;
    private int indexCam2 = 0;

    [HideInInspector] public static bool state = false;

    private float speed = 100f;
    private float compareDistSqr = 0.5f;

    private Vector3 nextPoint;

    private Transform cam2;

    private void Start()
    {
        AddListener();

        transform.position = new Vector3(createScene.starSparrows[index].transform.position.x, 10f, 10f);
        transform.rotation = Quaternion.Euler(45f, 180f, 0f);

        if(transform.childCount > 0)
        {
            cam2 = transform.GetChild(indexCam2);
        }
        else
        {
            Debug.LogError("Childe is null!");
        }
        
        cam2.transform.SetParent(null);
    }

    private void Update()
    {
        if (state)
        {
            transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, 10f, 10f), 
                new Vector3(createScene.starSparrows[index].position.x, 10f, 10f), speed * Time.deltaTime);

            if ((nextPoint - transform.position).sqrMagnitude <= compareDistSqr)
            {
                cam2.position = new Vector3(createScene.starSparrows[index].position.x, 10f, 10f);

                AddListener();

                state = false;

                cam2.transform.SetParent(null);
            }
        }
    }

    private void SetRight()
    {
        index++;

        if (index == createScene.starSparrows.Count)
        {
            index = 0;
        }

        nextPoint = new Vector3(createScene.starSparrows[index].position.x, 10f, 10f);

        SetCam2();

        RemoveListener();

        state = true;
    }

    private void SetLeft()
    {
        index--;

        if (index < 0)
        {
            index = createScene.starSparrows.Count - 1;
        }

        nextPoint = new Vector3(createScene.starSparrows[index].position.x, 10f, 10f);

        SetCam2();

        RemoveListener();

        state = true;
    }

    private void SetCam2()
    {
        cam2.transform.SetParent(gameObject.transform);
        cam2.transform.position = transform.position;
        cam2.transform.rotation = transform.rotation;
    }

    private void RemoveListener()
    {
        buttonLeft?.onClick.RemoveListener(SetLeft);
        buttonRight?.onClick.RemoveListener(SetRight);
    }
    private void AddListener()
    {
        buttonLeft?.onClick.AddListener(SetLeft);
        buttonRight?.onClick.AddListener(SetRight);
    }

    private void OnDisable()
    {
        buttonLeft?.onClick.RemoveListener(SetLeft);
        buttonRight?.onClick.RemoveListener(SetRight);
    }
}

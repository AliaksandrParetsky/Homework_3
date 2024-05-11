using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Button))]
public class SelectColor : MonoBehaviour
{
    [SerializeField] private CreateScene createScene;

    [SerializeField] private Texture2D texture;

    private Button button;

    private void Start()
    {
        if (GetComponent<Image>() && GetComponent<Button>())
        {
            button = GetComponent<Button>();
        }

        AddListener();
    }

    private void SetColor()
    {
        createScene.starSparrows[SelectObj.index].GetComponent<MeshRenderer>().material.mainTexture = texture;
    }

    private void AddListener()
    {
        button?.onClick.AddListener(SetColor);
    }

    private void OnDisable()
    {
        button?.onClick.RemoveListener(SetColor);
    }
}

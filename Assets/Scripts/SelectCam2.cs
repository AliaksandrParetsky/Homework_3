using UnityEngine;

public class SelectCam2 : MonoBehaviour
{
    [SerializeField] CreateScene createScene;

    public void SetCamUp()
    {
        if (!SelectObj.state)
        {
            transform.position = new Vector3(createScene.starSparrows[SelectObj.index].position.x, 10f, 0f);
            transform.rotation = Quaternion.Euler(90f, -180f, 0f);
        }
    }

    public void SetCamDown()
    {
        if (!SelectObj.state)
        {
            transform.position = new Vector3(createScene.starSparrows[SelectObj.index].position.x, -10f, 0f);
            transform.rotation = Quaternion.Euler(-90f, -180f, 0f);
        }
    }

    public void SetCamLeft()
    {
        if (!SelectObj.state)
        {
            transform.position = new Vector3(createScene.starSparrows[SelectObj.index].position.x + 10f, 0f, 0f);
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }
    }

    public void SetCamFace()
    {
        if (!SelectObj.state)
        {
            transform.position = new Vector3(createScene.starSparrows[SelectObj.index].transform.position.x, 10f, 10f);
            transform.rotation = Quaternion.Euler(45f, 180f, 0f);
        }
    }
}

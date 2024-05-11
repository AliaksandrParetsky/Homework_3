using System.Collections.Generic;
using UnityEngine;

public class CreateScene : MonoBehaviour
{
    public List<Transform> starSparrowsPrefabs;

    [HideInInspector] public List<Transform> starSparrows = new List<Transform>();

    [SerializeField] private Transform parentContainer;

    private void Awake()
    {
        CreateObjects();
    }

    private void CreateObjects()
    {
        Quaternion rotation = Quaternion.identity;
        Vector3 position = new Vector3(0f, 0f, 0f);
        float offSet = 30f;

        foreach (Transform starSparrowPrefab in starSparrowsPrefabs)
        {
            if(starSparrowPrefab != null)
            {
                starSparrows.Add(Instantiate(starSparrowPrefab, position, rotation, parentContainer));
                position = position - new Vector3(offSet, 0f, 0f);
            }
            else
            {
                Debug.LogError("Prefab is Null!");
            }
        }
    }
}

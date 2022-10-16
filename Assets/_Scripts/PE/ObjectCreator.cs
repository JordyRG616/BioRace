using UnityEngine;

public class ObjectCreator : MonoBehaviour
{
    public GameObject prefab;
    public GameObject endLevelTrigger;
    public Material material;
    public long length = 3;
    public Vector3 startingPosition = new Vector3(0, 1.5f, 6);

    void Start()
    {
        Vector3 nextPosition = new Vector3(0, 0, 0);
        GameObject prefabClone;

        for (int i = 0; i < length; i++)
        {
            nextPosition += startingPosition;
            prefabClone = Instantiate(prefab, nextPosition, Quaternion.identity);

            if (i == length - 1)
            {
                prefabClone.GetComponent<MeshRenderer>().material = material;

                Instantiate(endLevelTrigger, nextPosition, Quaternion.identity);
            }
        }
    }
}
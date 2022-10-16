using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject prefab;
    public int spawnQuantity = 1000;
    public float spawnInterval = 0f;

    [SerializeField]
    public float rangeX = 100f;
    public float rangeY = 1f;
    public float rangeZ = 100f;

    private void Start()
    {
        for (int i = 0; i < spawnQuantity; i++)
        {
            Invoke("Spawn", spawnInterval);
        }
    }

    void Spawn()
    {
        Vector3 pos = new Vector3(Random.Range(-rangeX, rangeX), Random.Range(-rangeY, rangeY), Random.Range(-rangeZ, rangeZ));
        Instantiate(prefab, pos, Quaternion.identity);
    }
}
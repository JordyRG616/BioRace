using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phyllotaxis : MonoBehaviour
{
    public GameObject prefab;
    public float degree = 137.5f;
    public float scale = 1;
    public int number;
    public float prefabScale = 1;
    private Vector3 phylloTaxisPosition;

    public Transform impacto;
    public float minOffset;
    public float maxOffset;

    public Vector3 CalculatePhyllotaxis(float degree, float scale, int count)
    {
        double angle = count * (degree * Mathf.Deg2Rad);
        float r = scale * Mathf.Sqrt(count);
        float x = r * (float)System.Math.Cos(angle);
        float y = 0f;
        float z = r * (float)System.Math.Sin(angle);
        Vector3 v3 = new Vector3(x, y, z);

        return v3;
    }

    public void Generate(Vector3 offset)
    {
        phylloTaxisPosition = CalculatePhyllotaxis(degree, scale, number);

        GameObject prefabClone = Instantiate(prefab);

        float x = Random.Range(minOffset, maxOffset);
        float y = -1f;
        float z = 0f;
        Vector3 xOffset = new Vector3(x, y, z);

        prefabClone.transform.position = new Vector3(phylloTaxisPosition.x + offset.x, phylloTaxisPosition.y + offset.y, phylloTaxisPosition.z + offset.z);
        prefabClone.transform.localScale = new Vector3(prefabScale, prefabScale, prefabScale);

        prefabClone.GetComponent<TargetMovement>().target = impacto.position + xOffset;

        number++;
    }
}

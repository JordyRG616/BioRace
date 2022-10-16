using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTarget : MonoBehaviour
{
    private Phyllotaxis m_Phyllotaxis;
    private float newTimeCount = 0f;
    private float oldTimeCount = 0f;
    private float contTime = 0f;

    [SerializeField]
    public Transform carro;
    public float incrementPerTime = 5f;
    public float tempoDecorrido;

    // Start is called before the first frame update
    void Start()
    {
        m_Phyllotaxis = GetComponent<Phyllotaxis>();
    }

    // Update is called once per frame
    void Update()
    {
        newTimeCount += incrementPerTime * Time.deltaTime;
        tempoDecorrido = (int)contTime;
        contTime += 1f * Time.deltaTime;

        if ((int)newTimeCount > (int)oldTimeCount)
        {
            float x = Random.Range(carro.position.x - Random.Range(0f, 1f), carro.position.x + Random.Range(0f, 1f));
            float y = Random.Range(carro.position.y - Random.Range(0f, 1f), carro.position.y + Random.Range(0f, 1f));
            float z = Random.Range(carro.position.z - Random.Range(0f, 1f), carro.position.z + Random.Range(0f, 1f));
            Vector3 offset = new Vector3(x, y+6, z);

            m_Phyllotaxis.Generate(offset);
        }

        oldTimeCount = (int)newTimeCount;
    }
}
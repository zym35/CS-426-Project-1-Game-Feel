using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public GameObject square, circle;
    public float rate;
    public float x, y;

    private void Awake()
    {
        Random.InitState((int)Time.time);
    }

    private IEnumerator Start()
    {
        while (true)
        {
            if (UIManager.Instance.isGameRunning)
            {
                int type = Random.Range(0, 2);
                Vector3 pos = new Vector3(Random.Range(-x, x), Random.Range(-y, y), 0);
                Instantiate(type == 0 ? circle : square, pos, Quaternion.identity, transform);
            }
            yield return new WaitForSeconds(1 / rate);
        }
    }
}

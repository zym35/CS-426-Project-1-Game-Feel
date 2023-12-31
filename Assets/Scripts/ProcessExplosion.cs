using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessExplosion : MonoBehaviour
{
    
    private List<GameObject> Boxes;
    private List<GameObject> ToRemove;
    private Vector3 Origin;
    float Timer = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if(Timer >= 2f)
        {
            Destroy(gameObject);
            return;
        }
        ToRemove = new List<GameObject>();
        foreach (GameObject box in Boxes)
        {
            if (box == null) continue;
            if(Vector3.Distance(box.transform.localPosition, Origin) <= Mathf.Min(2.0f, Timer * 3.0f))
            {
                ToRemove.Add(box);
                Vector3 Direction = box.transform.localPosition - Origin;
                float Magnitude = Direction.magnitude;
                Direction.Normalize();
                box.GetComponent<Rigidbody2D>().AddForce(Direction * 300.0f * (1 / Time.timeScale) / Mathf.Max(Magnitude, 0.6f));
            }
        }

        foreach (GameObject remove in ToRemove)
        {
            Boxes.Remove(remove);
        }
    }

    public void Initialize(List<GameObject> BoxesInput, Vector3 OriginInput)
    {
        Boxes = new List<GameObject>(BoxesInput);
        Origin = OriginInput;
    }
}

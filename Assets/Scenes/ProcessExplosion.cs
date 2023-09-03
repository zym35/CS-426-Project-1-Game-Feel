using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessExplosion : MonoBehaviour
{
    
    private List<GameObject> Boxes;
    private List<GameObject> ToRemove;
    private Vector3 Origin;
    float Timer;

    // Start is called before the first frame update
    void Start()
    {
        Timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if(Timer >= 2.0f)
        {
            Object.Destroy(this.gameObject);
        }
        ToRemove = new List<GameObject>();
        foreach (GameObject box in Boxes)
        {
            if(Vector3.Distance(box.transform.localPosition, Origin) <= Mathf.Min(2.0f, Timer * 3.0f))
            {
                ToRemove.Add(box);
                Vector3 Direction = box.transform.localPosition - Origin;
                float Magnitude = Direction.magnitude;
                Direction.Normalize();
                box.GetComponent<Rigidbody2D>().AddForce(Direction * (500.0f / Magnitude));
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

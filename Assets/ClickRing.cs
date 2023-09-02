using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickRing : MonoBehaviour
{
    float GlobalTimer;
    private float fixedDeltaTime;
    AudioSource audioData;
    public AudioClip ExplosionSFX;
    List<GameObject> Boxes;

    // Start is called before the first frame update
    void Start()
    {
        GlobalTimer = 0.0f;
        this.fixedDeltaTime = Time.fixedDeltaTime;
        audioData = GetComponent<AudioSource>();

        Boxes = new List<GameObject>();
        foreach (Transform child in GameObject.Find("MovableObjects").transform)
        {
            if (null == child)
                continue;
            Boxes.Add(child.gameObject);
            Physics2D.IgnoreCollision(child.gameObject.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        GlobalTimer += Time.deltaTime;
        if(GlobalTimer >= 0.2f && Time.timeScale < 1.0f)
        {
            Time.timeScale += 0.05f;
            Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
        }
    }

    void OnMouseDown()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Explosion(mousePosition);
    }

    public void Explosion(Vector3 Origin)
    {
        SimpleSonarShader_Object parent = GetComponent<SimpleSonarShader_Object>();
        if (parent)
        {
            audioData.PlayOneShot(ExplosionSFX, 0.7f);
            Time.timeScale = 0.2f;
            Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
            GlobalTimer = 0.0f;
            parent.StartSonarRing(Origin, 100.0f);
            foreach (GameObject box in Boxes)
            {
                Debug.Log("Sending Sonar Ring");
                Vector3 Direction = box.transform.localPosition - Origin;
                float Magnitude = Direction.magnitude;
                Direction.Normalize();
                box.GetComponent<Rigidbody2D>().AddForce(Direction * (500.0f / Magnitude));
            }
        }
    }
}

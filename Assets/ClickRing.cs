using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickRing : MonoBehaviour
{
    float GlobalTimer;
    private float fixedDeltaTime;
    AudioSource audioData;
    public AudioClip ExplosionSFX;
    List<GameObject> Boxes = new List<GameObject>();

    public void AddToList(GameObject obj)
    {
        Boxes.Add(obj);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        GlobalTimer = 0.0f;
        this.fixedDeltaTime = Time.fixedDeltaTime;
        audioData = GetComponent<AudioSource>();
        
        // foreach (Transform child in GameObject.Find("MovableObjects").transform)
        // {
        //     if (null == child)
        //         continue;
        //     
        //     Physics2D.IgnoreCollision(child.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        // }
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
        Debug.Log("" + mousePosition.x + " " + mousePosition.y);

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
            GameObject ExplosionProcessor = new GameObject();
            ExplosionProcessor.AddComponent<ProcessExplosion>().Initialize(Boxes, Origin);

        }
    }
}

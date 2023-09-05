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

    public void RemoveFromList(GameObject obj)
    {
        Boxes.Remove(obj);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        GlobalTimer = 0.0f;
        this.fixedDeltaTime = Time.fixedDeltaTime;
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GlobalTimer += Time.deltaTime;
        if(UIManager.Instance.enableSlowMo && GlobalTimer >= 0.04f && Time.timeScale < 1.0f)
        {
            Time.timeScale += 0.2f;
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
            if (UIManager.Instance.enableSlowMo)
            {
                Time.timeScale = 0.15f;
                Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
                GlobalTimer = 0.0f;
            }
            
            parent.StartSonarRing(Origin, 100.0f);
            GameObject ExplosionProcessor = new GameObject();
            ExplosionProcessor.AddComponent<ProcessExplosion>().Initialize(Boxes, Origin);

        }
    }
}

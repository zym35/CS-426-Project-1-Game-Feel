using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ExplosiveObject : MonoBehaviour
{
    public bool isCircle;
    public int life = 3;

    private void Start()
    {
        SetColor(isCircle ? UIManager.Instance.circleColor : UIManager.Instance.squareColor);
        FindObjectOfType<ClickRing>().AddToList(gameObject);
        GetComponentInChildren<TrailRenderer>().enabled = UIManager.Instance.enableTrail;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.transform.CompareTag("ExplosiveObject"))
            return;
        if (isCircle == other.gameObject.GetComponent<ExplosiveObject>().isCircle)
        {
            if (--life < 0)
            {
                FindObjectOfType<ClickRing>().RemoveFromList(gameObject);
                Destroy(gameObject);
                return;
            }
            
            FindObjectOfType<ClickRing>().Explosion(other.contacts[0].point);
        }
    }

    public void SetColor(Color c)
    {
        GetComponent<SpriteRenderer>().color = c;
        GetComponentInChildren<TrailRenderer>().startColor = c;
        GetComponentInChildren<TrailRenderer>().endColor = UIManager.Instance.backgroundColor;
    }
}

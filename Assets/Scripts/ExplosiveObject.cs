using System;
using UnityEngine;

public class ExplosiveObject : MonoBehaviour
{
    public bool isCircle;

    private void Start()
    {
        SetColor(isCircle ? UIManager.Instance.circleColor : UIManager.Instance.squareColor);
        FindObjectOfType<ClickRing>().AddToList(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.transform.CompareTag("ExplosiveObject"))
            return;
        if (isCircle == other.gameObject.GetComponent<ExplosiveObject>().isCircle)
        {
            //Explode code
        }
    }

    public void SetColor(Color c)
    {
        GetComponent<SpriteRenderer>().color = c;
        GetComponentInChildren<TrailRenderer>().startColor = c;
        GetComponentInChildren<TrailRenderer>().endColor = UIManager.Instance.backgroundColor;
    }
}

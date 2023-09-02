using UnityEngine;

public class ExplosiveObject : MonoBehaviour
{
    public bool isCircle;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (isCircle == other.gameObject.GetComponent<ExplosiveObject>().isCircle)
        {
            //Explode code
        }
    }

    public void SetColor(Color c)
    {
        GetComponent<SpriteRenderer>().color = c;
        GetComponentInChildren<TrailRenderer>().startColor = new Color(c.r, c.g, c.b, 0.5f);
    }
}

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
}

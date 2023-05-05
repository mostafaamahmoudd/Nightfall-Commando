using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float Health = 50f;

    public void TakeDamage (float amount)
    {
        Health -= amount;
        if(Health <= 0f)
        {
            Die ();
        }
    }

    private void Die ()
    {
        Destroy (gameObject);
    }
}

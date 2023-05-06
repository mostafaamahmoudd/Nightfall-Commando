using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Health = 100f;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage (float amount)
    {
        Health -= amount;
        if(Health <= 0f)
        {
            Die ();
        }
        else
        {
            animator.SetTrigger("Damage");
        }
    }

    private void Die ()
    {
        animator.SetTrigger("Die");
        GetComponent<Collider>().enabled = false;
        Destroy(gameObject, 8f);
    }
}

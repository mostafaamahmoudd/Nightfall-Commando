using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float damage = 10f;
    [SerializeField] private float range = 100f;
    [SerializeField] private float FireRate = 15;

    [SerializeField] private Camera fpsCamera;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private AudioSource audio;
    [SerializeField] private GameObject hitEffect;

    private float nextTimeToFire = 0;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / FireRate;
            Shoot();
            audio.Play();
        }
    }

    private void Shoot ()
    {
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.tag);

            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }

        GameObject impactGO =  Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impactGO, 1f);
    }
}

using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float fireRate = 0.2f;
    public Bullet bullet;
    public Transform spawnBullet;

    private bool canShoot = true;

    void Update()
    {
        if (Input.GetButton("Fire1") && canShoot)
        {
            StartCoroutine(SpawnBullet());
        }
    }

    IEnumerator SpawnBullet()
    {
        canShoot = false;
        Instantiate(bullet, spawnBullet.position, transform.rotation);

        yield return new WaitForSeconds(fireRate);

        canShoot = true;
    }
}

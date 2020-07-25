using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    public ChunksData chunksData;
    public float secondsBetweenShoot = 3.75f;

    // Start is called before the first frame update
    void Start()
    {
        secondsBetweenShoot = Random.Range(secondsBetweenShoot - 1, secondsBetweenShoot + 1);
        StartCoroutine(ShootProjectileLoop());
    }

    IEnumerator ShootProjectileLoop()
    {
        for (;;)
        {
            ShootProjectile();
            yield return new WaitForSeconds(secondsBetweenShoot);
        }
    }

    void ShootProjectile()
    {
        Instantiate(GetProjectile(), transform.position, Quaternion.identity);
    }

    GameObject GetProjectile()
    {
        return chunksData.obstacleProjectiles[Random.Range(0, chunksData.obstacleProjectiles.Count)];
    }
}

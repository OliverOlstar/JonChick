using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Shooting : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform muzzle;
    [SerializeField] private float forwardForce;

    [Header("Bullet")]
    [SerializeField] private float bulletsPerSec;
    [SerializeField] private float bulletLife;
    [SerializeField] private float bulletSize;

    public void StartShooting()
    {
        StartCoroutine("meShooting");
    }

    public void StopShooting()
    {
        StopCoroutine("meShooting");
    }

    IEnumerator meShooting()
    {
        while (true)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = muzzle.position;
            bullet.transform.forward = muzzle.forward;
            bullet.transform.localScale *= bulletSize;
            bullet.GetComponent<Rigidbody>().AddForce(new Vector3(transform.forward.x * forwardForce, 0, transform.forward.z * forwardForce), ForceMode.Impulse);
            Destroy(bullet, bulletLife);

            CameraShaker.Instance.ShakeOnce(1, 2, 0.1f, 0.15f);

            yield return new WaitForSeconds(1f / bulletsPerSec);
        }
    }
}

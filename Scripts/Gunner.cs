using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _rateOfFire;

    private readonly bool _isShooting = true;

    private void Start()
    {
        StartCoroutine(CountUpTimeShoot());
    }

    private IEnumerator CountUpTimeShoot()
    {
        var wait = new WaitForSecondsRealtime(_rateOfFire);

        while (_isShooting)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            CreateBullet(direction);

            yield return wait;
        }
    }

    private void CreateBullet(Vector3 direction)
    {
        Bullet newBullet = Instantiate(_bulletPrefab, transform.position + direction, Quaternion.identity);
        newBullet.Init(direction);
    }
}

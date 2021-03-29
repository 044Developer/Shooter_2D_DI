using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerShootController : IInitializable
{
    private PlayerShootData _shootData;
    private BulletBehaviour.Factory _bulletFactory;
    private Queue<GameObject> _bulletPool = new Queue<GameObject>();
    
    [Inject]
    public PlayerShootController(PlayerShootData shootData, BulletBehaviour.Factory bulletFactory)
    {
        _shootData = shootData;
        _bulletFactory = bulletFactory;
    }

    public void Initialize()
    {
        CreateBulletPool();
    }

    private void CreateBulletPool()
    {
        _bulletPool.Clear();
        for (int i = 0; i < _shootData.BulletPoolCount; i++)
        {
            GameObject bullet = _bulletFactory.Create().gameObject;
            bullet.transform.SetParent(_shootData.BulletsPoolHolder);
            bullet.SetActive(false);
            _bulletPool.Enqueue(bullet);
        }
    }

    public void ShootBullet(Queue<GameObject> bulletPool)
    {
        GameObject bullet = bulletPool.Dequeue();
        bullet.transform.position = _shootData.PlayerShootPosition.position;
        bullet.SetActive(true);
        bullet.transform.SetParent(null);
    }
}

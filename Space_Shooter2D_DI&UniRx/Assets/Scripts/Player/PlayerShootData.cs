using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerShootData 
{
    [Header("Bullet Pool Settings")]
    [SerializeField]
    private BulletBehaviour _bullet;
    [SerializeField]
    private int _bulletPoolCount;
    [SerializeField]
    private Transform _bulletsPoolHolder;

    [Header("Bullet Values")]
    [SerializeField]
    private int _playerShootRate;
    [SerializeField]
    private Transform _playerShootPosition;

    public BulletBehaviour BulletPrefab { get => _bullet; }
    public int BulletPoolCount { get => _bulletPoolCount; }
    public Transform BulletsPoolHolder { get => _bulletsPoolHolder; }
    public float PlayerShootRate { get => _playerShootRate; }
    public Transform PlayerShootPosition { get => _playerShootPosition; }
}

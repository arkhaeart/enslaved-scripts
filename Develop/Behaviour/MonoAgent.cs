using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MonoAgent : MonoBehaviour,IPoolable<IMemoryPool>
{
    [SerializeField] private SpriteRenderer mainRenderer;
    [SerializeField] private new Rigidbody2D rigidbody;
    [SerializeField] private new Collider2D collider;
    private IMemoryPool pool;
    public void OnDespawned()
    {
        pool.Despawn(this);
        pool = null;
    }

    public void OnSpawned(IMemoryPool pool)
    {
        this.pool = pool;
    }

    public class Factory:PlaceholderFactory<MonoAgent>
    {

    }
    public class Pool : MonoPoolableMemoryPool<IMemoryPool,MonoAgent>
    {

    }
}

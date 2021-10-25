using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderRange : MonoBehaviour
{
    [SerializeField] float _maxRange;
    [SerializeField] Transform[] _pos = new Transform[4];

    BoxCollider2D[] _colliders = new BoxCollider2D[4];

    private void Start()
    {
        SetUp();
    }

    void SetUp()
    {
        for (int count = 0; count < _pos.Length; count++)
        {
            _colliders[count] = gameObject.AddComponent<BoxCollider2D>();
            _colliders[count].offset = _pos[count].position;

            if (0 == count % 2) _colliders[count].size = new Vector2(1, _maxRange);
            else _colliders[count].size = new Vector2(_maxRange, 1);
        }
    }
}

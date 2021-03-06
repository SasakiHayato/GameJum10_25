using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _speed;
    Rigidbody2D _rb;
    GlazeSytem _glaze;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;

        SetUp();
    }

    void Update()
    {
        if (GameManager.Instance().CurrentState != GameState.IsGame) return;

        float rate = 1;

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Jump") && _glaze.Go) _glaze.GoBom();

        if (Input.GetButton("Fire3"))
            rate = 2;

        _rb.velocity = new Vector2(h, v).normalized * _speed / rate;
    }

    void SetUp()
    {
        GameObject glaze = new GameObject("Glaze");
        _glaze = glaze.AddComponent<GlazeSytem>();
        _glaze.Player = gameObject;
        _glaze.SetUp();
        CircleCollider2D circle = glaze.AddComponent<CircleCollider2D>();
        circle.isTrigger = true;
        circle.radius = 0.5f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            GameManager.Instance().ChangeGameState(GameState.Died);
            GameManager.Instance().Died();
        }
    }
}

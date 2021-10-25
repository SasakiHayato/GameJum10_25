using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float m_speed;
    private float m_angle;
    private float m_curve;
    private Rigidbody2D m_rb;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        transform.Rotate(0, 0, m_angle);
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, m_curve);
        Vector2 v = transform.rotation * Vector2.up;
        m_rb.velocity = v * m_speed;
    }

    public void SetParam(float speed, float angle)
    {
        m_speed = speed;
        m_angle = angle;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Eria"))
        {
            Destroy(gameObject);
        }
    }
}

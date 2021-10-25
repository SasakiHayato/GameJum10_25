using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float m_speed;
    private Vector2 m_angle;
    private Rigidbody2D m_rb;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(m_angle);
        m_angle.Normalize();
        m_rb.velocity = m_angle * m_speed;
    }

    public void SetParam(float speed, Vector2 angle)
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muzzle : MonoBehaviour
{
    private enum Type {single,way}
    private enum ShotPosition {x,y}
    private delegate void Types();
    [SerializeField] Type m_type = Type.single;
    [SerializeField] ShotPosition m_sPos = ShotPosition.x;
    [SerializeField] GameObject m_bulletPrefab;
    [SerializeField] float m_speed = 1f;
    [SerializeField] float m_fireInterval = 1f;
    [SerializeField] bool m_isPlayer = false;
    [SerializeField] Vector2 m_angle;
    private float m_randomRange = 5f;
    private GameObject m_player;
    private Types[] m_types;
    private float m_timer = 99;

    void Start()
    {
        m_player = GameObject.FindWithTag("Player");
        SetTypes();
    }

    void Update()
    {
        m_timer += Time.deltaTime;
        if (m_timer > m_fireInterval)
        {
            m_timer = 0;
            m_types[(int)m_type]();
        }
        m_fireInterval += 0.00001f;
    }

    private void SetTypes()
    {
        m_types = new Types[2];
        m_types[0] = Single;
        m_types[1] = Way;
    }

    private void Single()
    {
        SetAngle();
        Shot();
    }

    private void Way()
    {

    }

    private void Shot()
    {
        Vector2 pos;
        if (m_sPos == ShotPosition.x)
        {
            pos = new Vector2(transform.position.x, Random.Range(transform.position.y - m_randomRange, transform.position.y + m_randomRange));
        }
        else
        {
            pos = new Vector2(Random.Range(transform.position.x - m_randomRange, transform.position.x + m_randomRange), transform.position.y);
        }
        
        Bullet b = Instantiate(m_bulletPrefab, pos, Quaternion.identity).GetComponent<Bullet>();
        b.SetParam(m_speed, m_angle);
    }

    private void SetAngle()
    {
        if (m_isPlayer)
        {
            if (!m_player) { m_player = GameObject.FindWithTag("Player"); }
            Vector2 v = m_player.transform.position - this.transform.position;
            float angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        }
    }
}

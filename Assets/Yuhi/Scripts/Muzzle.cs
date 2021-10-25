using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muzzle : MonoBehaviour
{
    private enum Type {single,way}
    private enum ShotPosition {none,x,y}
    private delegate void Types();
    [SerializeField, Tooltip("弾のタイプ")]
    Type m_type = Type.single;
    [SerializeField, Tooltip("撃つ方向")]
    ShotPosition m_sPos = ShotPosition.x;
    [SerializeField, Tooltip("弾のプレハブ")]
    GameObject m_bulletPrefab;
    [SerializeField, Tooltip("最低速度")]
    float m_lowSpeed = 1f;
    [SerializeField, Tooltip("最高速度")]
    float m_topSpeed = 1f;
    [SerializeField, Tooltip("発射間隔")]
    float m_fireInterval = 1f;
    [SerializeField, Tooltip("発射間隔が短くなる周期")]
    float m_addFireInterval = 1f;
    [SerializeField, Tooltip("発射間隔が短くなる大きさ")]
    float m_addRange = 0.01f;
    [SerializeField, Tooltip("自機狙いにするかどうか")]
    bool m_isPlayer = false;
    [SerializeField, Tooltip("発射方向")]
    float m_angle;
    [SerializeField, Tooltip("曲がるすごさ")]
    float m_curve = 0;
    private float m_randomRange = 5f;
    private GameObject m_player;
    private Types[] m_types;
    private float m_timer = 99;
    private float m_fireTimer = 0;

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

        m_fireTimer += Time.deltaTime;
        if (m_fireTimer > m_addFireInterval)
        {
            m_fireTimer = 0;
            m_fireInterval -= m_addRange;
        }
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
        else if (m_sPos == ShotPosition.y)
        {
            pos = new Vector2(Random.Range(transform.position.x - m_randomRange, transform.position.x + m_randomRange), transform.position.y);
        }
        else
        {
            pos = transform.position;
        }
        float angle = Random.Range(m_angle - 30, m_angle + 30);
        Bullet b = Instantiate(m_bulletPrefab, pos, Quaternion.identity).GetComponent<Bullet>();
        float speed = Random.Range(m_lowSpeed, m_topSpeed);
        float curve = Random.Range(-m_curve, m_curve);
        b.SetParam(speed, angle, curve);
    }

    private void SetAngle()
    {
        if (m_isPlayer)
        {
            if (!m_player) { m_player = GameObject.FindWithTag("Player"); }
            Vector2 v = m_player.transform.position - this.transform.position;
            float angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
            m_angle = angle - 90;
            //transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        }
    }
}

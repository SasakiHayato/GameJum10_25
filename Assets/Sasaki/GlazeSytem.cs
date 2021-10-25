using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlazeSytem : MonoBehaviour
{
    public bool Go { get; private set; } = false;
    int _glazePoint = 0;

    public GameObject Player { set { _player = value; } }
    GameObject _player;
    GameObject _glaze;
    Image _glazeImage;

    void Update()
    {
        transform.position = _player.transform.position;
        _glaze.transform.position = _player.transform.position;
    }

    void Set()
    {
        _glazePoint++;
        _glazeImage.fillAmount = (float)_glazePoint / 10;
        
        if (_glazePoint >= 10) Go = true;
    }

    public void SetUp()
    {
        _glaze = Instantiate((GameObject)Resources.Load("GlazeCanvas"));
        _glazeImage = _glaze.transform.GetChild(0).GetComponent<Image>();
        _glazeImage.fillAmount = 0;
    }

    public void GoBom()
    {
        _glazeImage.fillAmount = 0;
        Go = false;
        _glazePoint = 0;
        GameObject[] get = GameObject.FindGameObjectsWithTag("Bullet");

        foreach (var item in get) Destroy(item);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("触れた");
            Set();
        }
    }
}

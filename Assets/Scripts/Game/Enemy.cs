using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int damage;
    public int Damage
    {
        get
        {
            return damage;
        }
        set
        {
            damage = value;
        }
    }
    [SerializeField] private float speed;
    private Rigidbody2D _compRigidbody;
    private void Start()
    {
        _compRigidbody = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        _compRigidbody.velocity = Vector2.left * speed;
    }
    void Update()
    {
        if (transform.position.x <= -Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).x)
        {
            Destroy(this.gameObject);
        }
    }
}

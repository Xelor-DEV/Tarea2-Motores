using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
public class PlayerMovement : MonoBehaviour
{
    private float verticalDirection;
    private Rigidbody2D _compRigidbody2D;
    [SerializeField]
    private float speed;
    public int player_lives = 4;
    void Start()
    {
        _compRigidbody2D = GetComponent<Rigidbody2D>();
    }
    public void Input(InputAction.CallbackContext context)
    {
        verticalDirection = context.ReadValue<float>();
    }
    void FixedUpdate()
    {
        _compRigidbody2D.velocity = new Vector2(_compRigidbody2D.velocity.x, verticalDirection * speed);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Candy")
        {
            CandyGenerator.instance.ManageCandy(other.gameObject.GetComponent<CandyController>(), this);
        }
        else if (other.tag == "Enemy")
        {
            StartCoroutine(Invulnerability());
        }
    }
    IEnumerator Invulnerability()
    {
        this.gameObject.layer = 6;
        SpriteRenderer sprite = this.gameObject.GetComponent<SpriteRenderer>();
        Color color = sprite.color;
        color.a = 0.5f;
        sprite.color = color;

        yield return new WaitForSeconds(1);
        this.gameObject.layer = 0;

        color.a = 1f;
        sprite.color = color;
    }
}

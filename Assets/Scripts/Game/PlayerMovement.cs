using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
public class PlayerMovement : MonoBehaviour
{
    private float verticalDirection;
    private Rigidbody2D _compRigidbody2D;
    [SerializeField] private GameManagerController gameManager;
    [SerializeField]
    private float speed;
    [SerializeField] public int player_lives;
    [SerializeField] private Transform centerPosition;
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
            AudioManagerController.Instance.PlaySfx(4);
            CandyGenerator.instance.ManageCandy(other.gameObject.GetComponent<CandyController>(), this);
        }
        else if (other.tag == "Enemy")
        {
            AudioManagerController.Instance.PlaySfx(3);
            AudioManagerController.Instance.PlaySfx(3);
            if (player_lives <= 0)
            {
                gameManager.SceneChange("GameOver");
            }
            else
            {
                player_lives = player_lives - other.GetComponent<Enemy>().Damage;
                if (player_lives <= 0)
                {
                    gameManager.SceneChange("GameOver");
                }
                transform.position = centerPosition.position;
                StartCoroutine(Invulnerability());
            }
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

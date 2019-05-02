using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Rigidbody2D rb2;
    private SpriteRenderer sprite;

    public GameObject effect;

	private GameObject partner;
    private GameObject m;
    private Manager mscript;
    private Player ps;
	
	public string nextScene;

	public bool win;


    public Transform groundCheck;
    public float groundCheckRadius = .1f;
    public LayerMask whatIsGround;
    public bool isGrounded = false;

    public float moveSpeed = 10;
    public float jumpForce = 10;
    public float airSpeed = 6;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "End")
        {
			win = true;
        } else if (collision.transform.tag == "Hazard")
        {
            Instantiate(effect, transform.position, transform.rotation);
            mscript.restartLevel();
            Destroy(ps);
            //Destroy(rb2);
            rb2.velocity = new Vector2(0, 0);
            Destroy(this.gameObject);
            //Scene s = SceneManager.GetActiveScene();
            //SceneManager.LoadScene(s.name);
        }
    }

	private void OnTriggerExit2D(Collider2D collision)
    {
		if(collision.transform.tag == "End")
        {
			win = false;
        } 
	}
    void Start()
    {
        if(name == "P1")
        {
            partner = GameObject.Find("P2");
        } else
        {
            partner = GameObject.Find("P1");
        }
        m = GameObject.Find("Manager");
        mscript = (Manager)m.GetComponent(typeof(Manager));
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        ps = partner.GetComponent<Player>();
        rb2 = partner.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        float x = Input.GetAxisRaw("Horizontal"); // * Time.deltaTime;

        if (win && ps.win)
		{
			SceneManager.LoadScene(nextScene);
		}


        if (x > 0)
        {
            sprite.flipX = false;
        }
        else if (x < 0)
        {
            sprite.flipX = true;
        }

        if (isGrounded)
        {
            rb.velocity = new Vector2(x * moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(x * airSpeed, rb.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }


    }
}

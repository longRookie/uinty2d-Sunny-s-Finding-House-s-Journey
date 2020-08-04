using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{

    public AudioClip hitClip;
    private Rigidbody2D rbody;
    public float speed = 5f;
    private bool canJump;//是否可以跳跃

    private bool canJump2;//修复一个bug:长时间碰墙，导致OnCollider2D判定失败，出现几率不大，但可以卡出来
    private float canJump2Time = 5f;
    private float canJump2Timer = 0;

    public Animator anim;
    public Collider2D coll;
    public LayerMask ground;

    public float Jumpforce;

    //生命系统
    private int maxHealth = 3;

    private int currentHealth;//当前生命值

    private float invincibleTime = 2f; //无敌时间2s

    private float invincibleTimer;

    private bool isInvincible;

    public int MyCurrentHealth
    {
        get
        {
            return currentHealth;
        }
    }

    public int MyMaxHealth
    {
        get
        {
            return maxHealth;
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = 2;
        invincibleTimer = 0;
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        UIManager.instance.UpdateHealthBar(currentHealth, maxHealth);
    }

    // Update is called once per frame
    private void Update()
    {
        Movement();
        SwitchAnim();
        //-----无敌时间
        //-----无敌时间
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
            }
        }
        if (currentHealth == 0)
        {
            exitGame();
        }
    }

    private void Movement()
    {
        if (!canJump)
        {
            canJump2Timer += Time.deltaTime;
        }

        if (canJump2Timer > canJump2Time)
        {
            canJump = true;
            canJump2Timer = 0;
        }
        float horizonmentmove = Input.GetAxis("Horizontal");
        float facedirection = Input.GetAxisRaw("Horizontal");
        if (horizonmentmove != 0)
        {
            rbody.velocity = new Vector2(horizonmentmove * speed, rbody.velocity.y);
            anim.SetFloat("running", Mathf.Abs(facedirection));
        }

        if (facedirection != 0)
        {
            transform.localScale = new Vector2(facedirection, transform.localScale.y);
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (canJump)
            {
                anim.SetBool("jumping", true);
                canJump = false;
                rbody.velocity = new Vector2(rbody.velocity.x, Jumpforce);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)  // 碰撞检测
    {
        canJump = true;
    }

    private void SwitchAnim()
    {
        anim.SetBool("idle", false);
        if (anim.GetBool("jumping"))
        {
            if (rbody.velocity.y < 0)
            {
                anim.SetBool("jumping", false);
                anim.SetBool("falling", true);
            }
        }
        else if (coll.IsTouchingLayers(ground))
        {
            anim.SetBool("falling", false);
            anim.SetBool("idle", true);
        }
    }

    public void exitGame()
    {
        SceneManager.LoadScene("EndScene");
    }

    public void ChangeHealth(int amount)
    {
        //如果玩家受到伤害
        if (amount < 0)
        {
            if (isInvincible)
            {
                return;
            }
            AudioManager.instance.AudioPlay(hitClip);
            isInvincible = true;
            invincibleTimer = invincibleTime;
        }
        //玩家的生命值约束到0 和最大值之间
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(MyCurrentHealth + "/" + MyMaxHealth);

        UIManager.instance.UpdateHealthBar(currentHealth, maxHealth);

    }


}
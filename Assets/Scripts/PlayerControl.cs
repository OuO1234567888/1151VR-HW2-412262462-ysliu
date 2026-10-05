using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private AudioSource audioSource;
    private int HP = 3;
    private float moveSpeed = 8f;
    private float jumpSpeed = 5f;
    private float movement; // 實際橫向速度
    private bool isGround = true;
    private bool isEnd = false;
    private Vector3[] rebirthPos;
    private int currentRebirthIndex = 0;
    public TextMeshProUGUI HP_Text;
    public GameObject endShow;
    public TextMeshProUGUI message;
    public AudioClip savePointSound; // 存檔點音效檔
    public AudioClip hurtSound; // 存檔點音效檔
    public AudioClip winSound;       // 勝利音效
    public AudioClip loseSound;      // 失敗音效
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        rebirthPos = new Vector3[2];
        rebirthPos[currentRebirthIndex] = gameObject.transform.position;
        endShow.SetActive(false);
        HP_Text.SetText("HP:" + HP);
        Time.timeScale = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if(isEnd == true) return;
        
        if (Input.GetKey(KeyCode.D)) // 往右
        {
            anim.SetBool("isMove", true);
            gameObject.transform.localScale = new Vector3(1, 1, 1); // 面向右
            movement = moveSpeed;
        }
        else if(Input.GetKey(KeyCode.A)) // 往左
        {
            anim.SetBool("isMove", true);
            gameObject.transform.localScale = new Vector3(-1, 1, 1); // 面向左
            movement = -moveSpeed;
        }
        else // 停止
        {
            
            anim.SetBool("isMove", false);
            movement = 0;
            
        }

        rb.linearVelocityX = movement;

        if (Input.GetKey(KeyCode.Space) && isGround) // 跳
        {
            rb.linearVelocityY = jumpSpeed;
        }
        

        



        if(gameObject.transform.position.y < -10) // 掉落 回重生點
        {
            audioSource.PlayOneShot(hurtSound);
            HP -= 1;
            HP_Text.SetText("HP:" + HP);
            if(HP <= 0)
            {
                audioSource.PlayOneShot(loseSound);
                isEnd = true;
                Time.timeScale = 0;
                message.SetText("You Lose");
                endShow.SetActive(true);
            }

            gameObject.transform.position = rebirthPos[currentRebirthIndex];
            anim.SetTrigger("Rebirth");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGround = true;
        }

        if (collision.CompareTag("SavePoint"))
        {
            Destroy(collision.gameObject);
            audioSource.PlayOneShot(savePointSound);
            ++currentRebirthIndex;
            rebirthPos[currentRebirthIndex] = gameObject.transform.position;
        }

        if (collision.CompareTag("Goal"))
        {
            Destroy(collision.gameObject);
            audioSource.PlayOneShot(winSound);
            isEnd = true;
            Time.timeScale = 0;
            message.SetText("You Win");
            endShow.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGround = false;
        }
    }
}

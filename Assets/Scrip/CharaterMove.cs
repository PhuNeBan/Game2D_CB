using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharaterMove : MonoBehaviour
{
    public Animator animator;
    public bool isLeft = false;
    private bool nen;
    public Rigidbody2D body;
    public GameObject panel1, buttonResume, buttonReStart1,
        textPause, panel2, buttonReStart2, textDeath, PSBrick;
    public TextMeshProUGUI textPoint;
    private int point = 0;
    public int speed = 5;
    public AudioSource main, death;

    void tinhTong(int score)
    {
        point += score;
        textPoint.text = "" +point;
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        main.Play();
        death.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isRuning", false);
        animator.SetBool("isJump", false);
        
        if (Input.GetKey(KeyCode.P))
        {
            Time.timeScale = 0;
            panel1.SetActive(true);
            buttonResume.SetActive(true);
            buttonReStart1.SetActive(true);
            textPause.SetActive(true);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            isLeft = false;
            if (nen)
            {
                animator.SetBool("isRuning", true);
            }
            else
            {
                animator.SetBool("isJump", true);
            }
            transform.Translate(speed * Time.deltaTime, 0, 0);
            Vector2 scale = transform.localScale;
            scale.x *= scale.x > 0 ? 1 : -1;
            transform.localScale = scale;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            isLeft = true;
            if (nen)
            {
                animator.SetBool("isRuning", true);
            }
            else
            {
                animator.SetBool("isJump", true);
            }
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            Vector2 scale = transform.localScale;
            scale.x *= scale.x > 0 ? -1 : 1;
            transform.localScale = scale;
        }
        if (nen == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                animator.SetBool("isRuning", false);
                if (isLeft == true)
                {
                    //dùng Force thay tranlate
                    body.AddForce(new Vector2(0, 400));
                    Vector2 scale = transform.localScale;
                    scale.x *= scale.x > 0 ? -1 : 1;
                    transform.localScale = scale;
                    //nen = false;
                }
                else
                {
                    //dùng Force thay tranlate
                    body.AddForce(new Vector2(0, 400));
                    Vector2 scale = transform.localScale;
                    scale.x *= scale.x > 0 ? 1 : -1;
                    transform.localScale = scale;
                    //nen = false;
                }
                nen = false;

            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Brick")
        {
            nen = true;
        }

        if (collision.gameObject.tag == "EndSceen1")
        {
            SceneManager.LoadScene("Scence_2");
        }
        if (collision.gameObject.tag == "EndSceen2")
        {
            SceneManager.LoadScene("Scence_Home");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "Tren")
        {
            // get name object hit
            var name = collision.attachedRigidbody.name;

            //kill mushroom
            Destroy(GameObject.Find(name));
            tinhTong(5);
        }

        if (collision.gameObject.tag == "Trai" || collision.gameObject.tag == "Spike" 
            || collision.gameObject.tag == "Ho")
        {
            //game over, reload game
            Time.timeScale = 0;
            point = 0;
            panel2.SetActive(true);
            buttonReStart2.SetActive(true);
            textDeath.SetActive(true);
            main.Stop();
            death.Play();
        }

        if (collision.gameObject.tag == "Coin")
        {
            var name = collision.attachedRigidbody.name;
            Destroy(GameObject.Find(name));
            tinhTong(1);
        }

        if (collision.gameObject.tag == "Diamon")
        {
            var name = collision.attachedRigidbody.name;
            Destroy(GameObject.Find(name));
            Instantiate(PSBrick,
                collision.gameObject.transform.position,
                collision.gameObject.transform.localRotation);
            tinhTong(5);
        }
    }
}

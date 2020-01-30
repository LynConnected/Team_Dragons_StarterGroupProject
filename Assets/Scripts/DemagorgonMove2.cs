using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DemagorgonMove2 : MonoBehaviour
{
    public float speed = 0.3f;
    private int point;
    private int lives;
    public Text pointText;
    public Text livesText;
    Vector2 dest = Vector2.zero;
    //Vector2 originalPos;
    public AudioSource pelletSource;
    //public AudioSource damageSource;

    // Start is called before the first frame update
    void Start()
    {
        //originalPos = gameObject.transform.position;
        dest = transform.position;
        point = 3290;
        SetPointText();
        lives = 3;
        SetLivesText();
        pelletSource = GetComponent<AudioSource>();
        //damageSource = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);

        if ((Vector2)transform.position == dest)
        {
            if (Input.GetKey(KeyCode.UpArrow) && valid(Vector2.up))
                dest = (Vector2)transform.position + Vector2.up;
            if (Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right))
                dest = (Vector2)transform.position + Vector2.right;
            if (Input.GetKey(KeyCode.DownArrow) && valid(-Vector2.up))
                dest = (Vector2)transform.position - Vector2.up;
            if (Input.GetKey(KeyCode.LeftArrow) && valid(-Vector2.right))
                dest = (Vector2)transform.position - Vector2.right;
        }

        Vector2 dir = dest - (Vector2)transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("pacdot"))

        {
            pelletSource.Play();
            other.gameObject.SetActive(false);
            point = point + 10;
            SetPointText();
            if (point == 6580)
            {
                SceneManager.LoadScene("WinScreen");
            }
        }
        if (other.gameObject.CompareTag("ghost"))
        {
            //damageSource.Play();
            lives = lives - 1;
            SetLivesText();
            if (lives == 0)
            {
                SceneManager.LoadScene("GameOver");
            }
            //transform.position = originalPos;
        }
    }
    void SetPointText()
    {
        pointText.text = "Points: " + point.ToString();
    }
    void SetLivesText()
    {
        livesText.text = "Lives: " + lives.ToString();
    }
    bool valid(Vector2 dir)
    {
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return (hit.collider == GetComponent<Collider2D>());

    }

}
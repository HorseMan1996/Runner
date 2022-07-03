using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static GameObject player;
    public static GameObject currentPlatform;
    bool canTurn = false;
    Vector3 startPosition;
    public static bool isDead = false;
    Rigidbody rb;

    [SerializeField] GameObject magic;
    [SerializeField] Transform magicStartPos;
    Rigidbody mRb;

    int livesLeft;
    public Texture aliveIcon;
    public Texture deadIcon;
    public RawImage[] icons;

    public TMP_Text highScore;
    [SerializeField] GameObject gameOverPanel;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = this.gameObject;
        CreatePlatform.RunDummy();
        startPosition = player.transform.position;
        isDead = false;
        mRb = magic.GetComponent<Rigidbody>();
        livesLeft = PlayerPrefs.GetInt("lives");

        if (PlayerPrefs.HasKey("highestScore"))
        {
            highScore.text = "High Score: " + PlayerPrefs.GetInt("highestScore");
        }
        else
        {
            highScore.text = "High Score: 0";
        }

        for (int i = 0; i < icons.Length; i++)
        {
            if (i >= livesLeft)
            {
                icons[i].texture = deadIcon;
            }
        }
    }

    void CastMagic()
    {
        magic.transform.position = magicStartPos.position;
        magic.SetActive(true);
        mRb.AddForce(this.transform.forward * 700);
        Invoke("KillMagic", 3f);
    }
    void KillMagic()
    {
        magic.SetActive(false);
        mRb.velocity = Vector3.zero;
    }
    private void OnCollisionEnter(Collision collision)
    {
        currentPlatform = collision.gameObject;
    }

    void RestartGame()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other is BoxCollider && CreatePlatform.lastPlatform.tag != "Tplatform")
        {
            CreatePlatform.RunDummy();
        }

        if (other is SphereCollider)
        {
            canTurn = true;
        }

        if ((other.gameObject.tag == "Fire" || other.gameObject.tag == "wall") && !isDead)
        {
            isDead = true;
            livesLeft--;
            //Dead station
            PlayerPrefs.SetInt("lives", livesLeft);
            if (livesLeft > 0)
            {
                Invoke("RestartGame", 1);
            }
            else
            {
                icons[0].texture = deadIcon;
                gameOverPanel.SetActive(true);

                PlayerPrefs.SetInt("lastscore", PlayerPrefs.GetInt("score"));
                if (PlayerPrefs.HasKey("highestScore"))
                {
                    int hs = PlayerPrefs.GetInt("highestScore");
                    if (hs < PlayerPrefs.GetInt("score"))
                    {
                        PlayerPrefs.SetInt("highestScore", PlayerPrefs.GetInt("score"));
                    }
                }
                else
                {
                    PlayerPrefs.SetInt("highestScore", PlayerPrefs.GetInt("score"));
                }
            }
           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other is SphereCollider)
        {
            canTurn = false;
        }
    }

    void Update()
    {

        if (!PlayerController.isDead)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * 250);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && canTurn)
            {
                this.transform.Rotate(Vector3.up * 90);
                CreatePlatform.dummyTraveller.transform.forward = -this.transform.forward;
                CreatePlatform.RunDummy();

                if (CreatePlatform.lastPlatform.tag != "Tplatform")
                {
                    CreatePlatform.RunDummy();
                }

                this.transform.position = new Vector3(startPosition.x,
                                                        this.transform.position.y,
                                                        startPosition.z);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && canTurn)
            {
                this.transform.Rotate(Vector3.up * -90);
                CreatePlatform.dummyTraveller.transform.forward = -this.transform.forward;
                CreatePlatform.RunDummy();

                if (CreatePlatform.lastPlatform.tag != "Tplatform")
                {
                    CreatePlatform.RunDummy();
                }

                this.transform.position = new Vector3(startPosition.x,
                                            this.transform.position.y,
                                            startPosition.z);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                this.transform.Translate(-0.5f, 0, 0);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                this.transform.Translate(0.5f, 0, 0);
            }
            else if (Input.GetMouseButton(0))
            {
                CastMagic();
            }
        }

    }
}

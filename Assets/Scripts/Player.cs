using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public delegate void OnScoreMessage(int value);
    public static event OnScoreMessage OnScoreUpdate;


    private Rigidbody _rigidbody;
    private int ScoreValue = 0;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;
    [SerializeField] private TMP_Text _scoreText;



    private void Start()
    {
        //init
        _rigidbody = GetComponent<Rigidbody>();
        _scoreText.text = "Score: " + ScoreValue;
        jump = new Vector3(0.0f, 2.0f, 0.0f);

    }

    private void OnCollisionStay(Collision collision)
    {

        isGrounded = true;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {

            Score();
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Target_trigger"))
        {
            Score();
            Destroy(other.gameObject);
        }
    }

    private void Score()
    {
        ScoreValue++;
        showScore(ScoreValue);


        //j'invoque OnScoreUpdate
        OnScoreUpdate?.Invoke(ScoreValue);
    }

    private void showScore(int scoreValue)
    {
        _scoreText.text = "Score: " + scoreValue;
    }

    void Update()
    {

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            _rigidbody.AddForce(Input.GetAxis("Horizontal") * 5f, 0f, Input.GetAxis("Vertical") * 5f);
        }

        /*        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
                {
                    _rigidbody.AddForce(jump * jumpForce, ForceMode.Impulse);

                    isGrounded = false;
                }*/
        //Get Input
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //Add force to rb (Z axis)
            _rigidbody.AddForce(0f, 0f, 20f);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            //Add force to rb
            _rigidbody.AddForce(0f, 0f, -20f);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Add force to rb (Z axis)
            _rigidbody.AddForce(-20f, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Add force to rb
            _rigidbody.AddForce(20f, 0f, 0f);
        }

    }
}

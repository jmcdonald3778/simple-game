using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0; //starting value is 0
    private Rigidbody rb; //private means this variable can only be accessed within this class, Rigidbody is a data type, rb is the name of the variable
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float movementX;
    private float movementY; //floats for precision
    private int count;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //GetComponent is a method that returns a component of type Rigidbody attached to the same GameObject as this script, called on first frame so player can move sphere straight away
        count = 0;
        SetCountText();
        winTextObject.SetActive(false); 
    }
    void OnMove(InputValue movementValue) //void means the function does not return a value, functions input parameters are in (), InputValue is a data type, movementValue is name 
    {   
        // function body/instructions for the function OnMove()
        Vector2 movementVector = movementValue.Get<Vector2>(); //Vector2 is a data type, movementVector is name, Get is a method that returns a value of type Vector2

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString(); //countText is a TextMeshProUGUI object, text is a property of TextMeshProUGUI that sets the displayed text, count.ToString() converts the integer count to a string
        if(count >= 12)
        {
            winTextObject.SetActive(true);

            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }
    void FixedUpdate() // FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup")) //other is the collider that entered the trigger, gameObject is the GameObject that the collider is attached to, CompareTag is a method that checks if the GameObject has a specific tag, "Pickup" is the tag being checked for
            {
                other.gameObject.SetActive(false); //other is the collider that entered the trigger, gameObject is the GameObject that the collider is attached to, SetActive is a method that sets the active state of the GameObject, false means the GameObject is deactivated
                count += 1;
                
                SetCountText();
            }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject); //destroy the currect object (the player)

            winTextObject.SetActive(true); //update the win text to say "You Lose!"
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
        }
    }

}

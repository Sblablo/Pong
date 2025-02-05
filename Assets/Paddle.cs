using Unity.Mathematics.Geometry;
using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    public float maxPaddleSpeed = 10f;
    public float paddleForce = 1f;
    
    InputAction moveAction;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //BoxCollider c = GetComponent<BoxCollider>();
        //float max = c.bounds.max.z;
        //float min = c.bounds.min.z;
        //Debug.Log($"min: {min}, max: {max}");

        moveAction = gameObject.GetComponent<PlayerInput>().actions.FindAction("Paddle");
    }

    // Update is called once per frame
    void Update()
    {
        // Movement actions
        Transform paddleTransform = GetComponent<Transform>();
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        Vector3 newPosition = paddleTransform.position +
                              new Vector3(0, 0, moveValue.y * maxPaddleSpeed * Time.deltaTime);
        //float movementAxis = Input.GetAxis("LeftPaddle");
        //Vector3 force = new Vector3(0f, 0f, 1f) * movementAxis * paddleForce;
        
        //paddleTransform.position += new Vector3(0f, 0f, movementAxis * maxPaddleSpeed * Time.deltaTime);

        //Vector3 newPosition = paddleTransform.position +
                              //new Vector3(0f, 0f, movementAxis * maxPaddleSpeed * Time.deltaTime);
        newPosition.z = Mathf.Clamp(newPosition.z, -7.5f, 7.5f);

        paddleTransform.position = newPosition;


        //Rigidbody rbody = GetComponent<Rigidbody>();
        //rbody.AddForce(force, ForceMode.Force);
    }
}

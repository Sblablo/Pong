using UnityEngine;

public class PowerDown : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            var attachedRigidbody = other.attachedRigidbody;
            Vector3 newVelocity = attachedRigidbody.linearVelocity;
            attachedRigidbody.linearVelocity = -newVelocity;
            
            this.gameObject.SetActive(false);
            Destroy(this);
            Debug.Log("Power Up");
        }
    }
}

using UnityEngine;

public class PowerUp : MonoBehaviour
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
            other.gameObject.transform.localScale = new Vector3(2, 2, 2);
            this.gameObject.SetActive(false);
            Destroy(this);
            Debug.Log("Power Up");
        }
    }
}

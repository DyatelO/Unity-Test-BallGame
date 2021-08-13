using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Camera focalPoint;
    [SerializeField] private GameObject powerupIndicator;    
    
    private Rigidbody rigidBody;
    private float powerUpStrength = PowerUP.upStrength;
    private float speed = 5.0f;
    public static bool powerUpON = false;


    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void LateUpdate() 
    {
        if(powerUpON)
        {
            powerupIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerUpCountdownRoutine());  
        }    
    }

    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");

        rigidBody.AddForce(focalPoint.transform.forward * forwardInput * speed);

        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.GetComponent<Enemy>() && powerUpON)
        {
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRigidBody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse );        

            powerupIndicator.gameObject.SetActive(true);
        }
    }

    public IEnumerator PowerUpCountdownRoutine()
    {
        yield return new WaitForSeconds(3);
        powerUpON = false;
        powerupIndicator.gameObject.SetActive(false); 
    }
}

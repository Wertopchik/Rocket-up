using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

[SelectionBase]
public class Rocket : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audio;
    [SerializeField] float thrust = 20;
    [SerializeField] float rotateSpeed = 5;

    bool isFly = true;

    [SerializeField] AudioClip destroySFX;
    [SerializeField] AudioClip winSFX;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isFly == true)
        {
            AddThrust();
            RotateRocket();
        }


    }

    void AddThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(0, thrust, 0);
            if(audio.isPlaying == false)
            {
                audio.Play();
            }
        }
        else
        {
            audio.Stop();
        }
    }

    void RotateRocket()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.angularVelocity = new Vector3(0, 0, 0);
            transform.Rotate(0, 0, rotateSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.angularVelocity = new Vector3(0, 0, 0);
            transform.Rotate(0, 0, -rotateSpeed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isFly == false) return;
        
        if (collision.transform.tag == "Obstacle")
        {
            StartCoroutine(DestroyRocket());
        }
        if(collision.transform.tag == "Finish")
        {
            StartCoroutine(WinLevel());
        }

    }

    IEnumerator DestroyRocket()
    {
        print("Ракета разрушена");
        isFly = false;
        audio.Stop();
        audio.PlayOneShot(destroySFX);
        yield return new WaitForSeconds(1.5f);
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }

    IEnumerator WinLevel()
    {
        print("Уровень пройден");
        isFly = false;
        audio.Stop();
        audio.PlayOneShot(winSFX);
        yield return new WaitForSeconds(1.5f);
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index + 1);
    }
}

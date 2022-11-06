using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    private bool isOnGround = false;
    private Animator playerAnimator;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudioSource;

    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        playerAudioSource = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver){
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnimator.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudioSource.PlayOneShot(jumpSound, 0.5f);
        }
        
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Ground")){
            isOnGround = true;
            dirtParticle.Play();
        } else if (collision.gameObject.CompareTag("Obstacle")){
            gameOver = true;
            Debug.Log("Game Over !");
            dirtParticle.Stop();
            explosionParticle.Play();
            playerAudioSource.PlayOneShot(crashSound, 0.7f);
            playerAnimator.SetBool("Death_b",true);
            playerAnimator.SetInteger("DeathType_int",1);
        }
    }
}

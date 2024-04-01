using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] private ParticleSystem crashEffect;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private float reloadSceneDelay = 0.5f;
    [SerializeField] private AudioClip crashSFX;

    private PlayerController playerController;
    private AudioSource audioSource;
    private bool hasCrashed = false;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == (int)Mathf.Log(groundLayerMask.value, 2) && !hasCrashed)
        {
            hasCrashed = true;

            crashEffect.Play();
            audioSource.PlayOneShot(crashSFX);

            Invoke("ReloadScene", reloadSceneDelay);
        }
    }

    public bool GetHasCrashed()
    {
        return hasCrashed;
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}

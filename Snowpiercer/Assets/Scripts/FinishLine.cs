using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private ParticleSystem finishEffect;
    [SerializeField] private LayerMask playerLayerMask;
    [SerializeField] private float reloadSceneDelay = 1f;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == (int)Mathf.Log(playerLayerMask.value, 2))
        {
            finishEffect.Play();
            audioSource.Play();

            Invoke("ReloadScene", reloadSceneDelay);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] private ParticleSystem slidingEffect;
    [SerializeField] private LayerMask groundLayerMask;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == (int)Mathf.Log(groundLayerMask.value, 2))
        {
            slidingEffect.Play();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == (int)Mathf.Log(groundLayerMask.value, 2))
        {
            slidingEffect.Stop();
        }
    }

}

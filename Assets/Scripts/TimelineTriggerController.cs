using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelinetTriggerConroller : MonoBehaviour
{
    [SerializeField] private PlayableDirector _timeline;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _timeline.Play();
        }
    }
}

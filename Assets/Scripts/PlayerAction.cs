using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] private GameObject _light;
    [SerializeField] private Image _blindOverlay;
    [SerializeField] private PlayerMovement _playerMovement;

    public void Sniff(InputAction.CallbackContext context)
    {
        if (_light.activeSelf == false) return;

        if (context.performed && _blindOverlay.color.a >= 0.93)
        {
            StartCoroutine(OpenVision());
        }
    }

    private IEnumerator OpenVision()
    {
        Color color = _blindOverlay.color;
        color.a = 0f;
        _blindOverlay.color = color;

        yield return new WaitForSeconds(2f);

        while (_blindOverlay.color.a < 0.93)
        {
            color.a += 0.15f * Time.deltaTime;
            _blindOverlay.color = color;

            yield return null;
        }
    }
}

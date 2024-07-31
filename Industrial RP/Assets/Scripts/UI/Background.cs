using System.Collections;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private GameObject[] _backgrounds;
    [SerializeField] private float _backgroundChangeTime = 5.2f;
    private GameObject _background;
    private void Start()
    {
        StartCoroutine(ChangeBackgroundCoroutine());
    }
    private IEnumerator ChangeBackgroundCoroutine()
    {
        _background = _backgrounds[Random.Range(0, _backgrounds.Length - 1)];
        _background.SetActive(true);
        yield return new WaitForSeconds(_backgroundChangeTime);

        while (true)
        {
            _background.SetActive(false);
            GameObject selectedBackground = _backgrounds[Random.Range(0, _backgrounds.Length - 1)];
            if (selectedBackground.name != _background.name)
            {
                _background = selectedBackground;
                _background.SetActive(true);
                yield return new WaitForSeconds(_backgroundChangeTime);
            }

        }
    }
}

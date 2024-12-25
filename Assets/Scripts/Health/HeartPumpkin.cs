using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]

public class HeartPumpkin : MonoBehaviour
{
    [SerializeField] private float _lerpDuration;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.fillAmount = 1;
    }

    public void ToFill()
    {
        StartCoroutine(FillIn(0, 1, _lerpDuration, FillIn));
    }

    public void ToEmpty()
    {
        StartCoroutine(FillIn(1, 0, _lerpDuration, Destroy));
    }

    private void Destroy(float value)
    {
        _image.fillAmount = value;
        Destroy(gameObject);
    }

    private void FillIn(float value)
    {
        _image.fillAmount = value;
    }

    private IEnumerator FillIn(float startValue, float endValue, float duration, UnityAction<float> lerpingEnd)
    {
        float elapsedTime = 0;
        float nextValue;

        while (elapsedTime < duration)
        {
            nextValue = Mathf.Lerp(startValue, endValue, elapsedTime / duration);
            _image.fillAmount = nextValue;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        lerpingEnd?.Invoke(endValue);
    }
}

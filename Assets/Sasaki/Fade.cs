using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    private static Fade _instance = new Fade();
    public static Fade Instance => _instance;

    void Update()
    {
        if (Instance._isFade) return;

        _time += Time.deltaTime;
        float alfe = _time / Instance._fadeSpeed;
        Instance._group.alpha = Mathf.Lerp(Instance._startVal,Instance._endVal, alfe);
        
        if (alfe > 1f)
        {
            Instance._isFade = true;
            Destroy(Instance._canvas);
            Instance._canvas = null;
        }
    }

    bool _isFade = false;
    public static bool IsFade { get => Instance._isFade; }

    float _startVal, _endVal;
    float _fadeSpeed = 0;
    float _time;

    GameObject _canvas = null;
    Image _fadeImage;
    CanvasGroup _group;

    public static void FadeIn(float fadeSpeed = 1)
    {
        Instance.SetFade(1, 0, fadeSpeed);
    }

    public static void FadeOut(float fadeSpeed = 1)
    {
        Instance.SetFade(0, 1, fadeSpeed);
    }

    void SetFade(float start, float end, float fadeSpeed)
    {
        Instance._isFade = false;
        Instance._startVal = start;
        Instance._endVal = end;
        Instance._fadeSpeed = fadeSpeed;

        CreateCanvas();
        this._time = 0;
        Instance._group.alpha = start;
    }

    void CreateCanvas()
    {
        if (_canvas != null) return;

        GameObject canvasObj = new GameObject("FadeCanvas");
        canvasObj.AddComponent<Fade>();
        Canvas canvas = canvasObj.AddComponent<Canvas>();
        canvas.sortingOrder = 10;
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        CanvasScaler scaler = canvasObj.AddComponent<CanvasScaler>();
        scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        scaler.referenceResolution = new Vector2(800, 600);
        canvasObj.AddComponent<GraphicRaycaster>();

        GameObject imageObj = new GameObject("FadeImage");
        imageObj.transform.SetParent(canvasObj.transform);
        Image image = imageObj.AddComponent<Image>();
        RectTransform rect = image.GetComponent<RectTransform>();
        rect.anchorMin = Vector2.zero;
        rect.anchorMax = Vector2.one;
        rect.offsetMin = Vector2.zero;
        rect.offsetMax = Vector2.zero;
        Instance._group = imageObj.AddComponent<CanvasGroup>();

        Instance._fadeImage = image;
        Instance._fadeImage.color = Color.black;
    }
}

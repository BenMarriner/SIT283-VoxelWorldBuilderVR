using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class ControlLabel : MonoBehaviour
{
    private float _labelScaleMultiplier = 0.001f;
    private Text _textComponent;
    private RectTransform _panelTransform;
    private Image _background;

    public bool visible = true;
    public string labelString = "Control Label";
    public float labelScale = 1.0f;
    public Vector2 panelSize = new Vector2(200.0f, 60.0f);
    public Color backgroundColour = Color.grey;
    public Color textColour = Color.white;
    
    // Start is called before the first frame update
    void Start()
    {
        _textComponent = GetComponentInChildren<Text>();
        _panelTransform = GetComponentInChildren<RectTransform>();
        _background = GetComponentInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.one * labelScale * _labelScaleMultiplier;
        _panelTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, panelSize.x);
        _panelTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, panelSize.y);
        _background.color = backgroundColour;
        _textComponent.text = labelString;
        _textComponent.color = textColour;
        _panelTransform.gameObject.SetActive(visible);
    }
}

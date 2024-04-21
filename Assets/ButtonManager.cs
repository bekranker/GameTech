using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Sprite _downSprite, _upSprite;
    [SerializeField] private Image _image;
    [SerializeField] private RectTransform _myRectT;
    [SerializeField] private TMP_Text _buttonText; 
    [SerializeField] private float _value;


    private Vector3 _startVector;

    void Start()
    {
        _startVector = _buttonText.transform.localPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _myRectT.sizeDelta = new Vector2(26, 9);
        _image.sprite = _downSprite;
        _buttonText.transform.localPosition -= Vector3.up * _value;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _myRectT.sizeDelta = new Vector2(26, 11);
        _image.sprite = _upSprite;
        _buttonText.transform.localPosition = _startVector;
    }
}
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;


public class RollYourDiceHit : MonoBehaviour
{
    [SerializeField] public string HitText;
    [SerializeField] private TMP_Text _hitText;
    [SerializeField] private GameObject _canvas;
    public void GameHit()
    {
        DOTween.Kill(_hitText);
        _canvas.SetActive(true);
        _hitText.alpha = 1;
        _hitText.text = HitText;
        _hitText.transform.DOPunchScale(Vector3.one * 0.01f, 0.2f);
        _hitText.DOFade(0, 2f);
        DOVirtual.DelayedCall(2, () => { _canvas.SetActive(false); });
    }
}
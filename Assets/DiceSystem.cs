using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using DG.Tweening;


public class DiceSystem : MonoBehaviour
{
    [SerializeField] private List<DiceHolder> _dices;
    [SerializeField] private List<Sprite> _diceSpritesMove;
    [SerializeField] private List<Sprite> _diceSpritesCombat;
    [SerializeField] private List<Sprite> _diceSpritesDefence;

    public int SpawnedDiceCount;
    public int Max, Min;
    public float Movement, Combat, Defend;
    public bool CanRoll, DidRoll;
    public int RolledDiceCount, DiceCountInHand;
    public bool CanSetConfigs;

    void Start()
    {
        CanSetConfigs = true;
    }

    public void SetConfigs()
    {
        for (int i = 0; i < _dices.Count; i++)
        {
            if (_dices[i] != null && _dices[i].MyDice != null)
            {
                _dices[i].transform.DORotate(new Vector3(0, 0, 360), 1f, RotateMode.FastBeyond360);
                
                if (_dices[i].MyDice.DiceType.TypeOfDice == TypeOfDices.Movement)
                {
                    SetDiceSpriteMove(_dices[i].MyDice.DiceNumber, _dices[i]._sp);
                    print(_dices[i].MyDice.DiceNumber);
                    Movement += _dices[i].MyDice.DiceNumber;
                }
                else if (_dices[i].MyDice.DiceType.TypeOfDice == TypeOfDices.Combnat)
                {
                    SetDiceSpriteCombat(_dices[i].MyDice.DiceNumber, _dices[i]._sp);
                    print(_dices[i].MyDice.DiceNumber);
                    Combat += _dices[i].MyDice.DiceNumber;
                }
                else if (_dices[i].MyDice.DiceType.TypeOfDice == TypeOfDices.Defence)
                {
                    SetDiceSpriteDefence(_dices[i].MyDice.DiceNumber, _dices[i]._sp);
                    print(_dices[i].MyDice.DiceNumber);
                    Defend += _dices[i].MyDice.DiceNumber;
                }
            }
        }
    }
    public void SetSprites(int i, SpriteRenderer spriteRenderer)
    {
        SetDiceSpriteCombat(i, spriteRenderer);
        SetDiceSpriteDefence(i, spriteRenderer);
        SetDiceSpriteMove(i, spriteRenderer);
    }
    void Update()
    {
        if (DidRoll && RolledDiceCount == DiceCountInHand)
        {
            if (CanSetConfigs)
            {
                SetConfigs();
            
                CanSetConfigs = false;
            }
        }
    }
    public void RollDice()
    {
        if(!CanRoll) return;
        CreateAudio.PlayAudio("ClickSoundEffect", .1f);
        RolledDiceCount = 0;
        Movement = 0;
        Combat = 0;
        Defend = 0;
        CreateAudio.PlayAudio("RollDiceSoundEffect", .5f);
        for (int i = 0; i < _dices.Count; i++)
        {
            if (_dices[i] != null && _dices[i].MyDice != null && _dices[i].DiceHealth > 0)
            _dices[i].MyDice.RollMe();
        }
        CanRoll = false;
    }
    
    private void SetDiceSpriteMove(int i, SpriteRenderer spriteRenderer)
    {
        switch (i)
        {
            case 1:
                spriteRenderer.sprite = _diceSpritesMove[0];
                break;
            case 2:
                spriteRenderer.sprite = _diceSpritesMove[1];
                break;
            case 3:
                spriteRenderer.sprite = _diceSpritesMove[2];
                break;
            case 4:
                spriteRenderer.sprite = _diceSpritesMove[3];
                break;
            case 5:
                spriteRenderer.sprite = _diceSpritesMove[4];
                break;
            case 6:
                spriteRenderer.sprite = _diceSpritesMove[5];
                break;
            default:
                break;
        }
    }
    private void SetDiceSpriteCombat(int i, SpriteRenderer spriteRenderer)
    {
        switch (i)
        {
            case 1:
                spriteRenderer.sprite = _diceSpritesCombat[0];
                break;
            case 2:
                spriteRenderer.sprite = _diceSpritesCombat[1];
                break;
            case 3:
                spriteRenderer.sprite = _diceSpritesCombat[2];
                break;
            case 4:
                spriteRenderer.sprite = _diceSpritesCombat[3];
                break;
            case 5:
                spriteRenderer.sprite = _diceSpritesCombat[4];
                break;
            case 6:
                spriteRenderer.sprite = _diceSpritesCombat[5];
                break;
            default:
                break;
        }
    }
    private void SetDiceSpriteDefence(int i, SpriteRenderer spriteRenderer)
    {
        switch (i)
        {
            case 1:
                spriteRenderer.sprite = _diceSpritesDefence[0];
                break;
            case 2:
                spriteRenderer.sprite = _diceSpritesDefence[1];
                break;
            case 3:
                spriteRenderer.sprite = _diceSpritesDefence[2];
                break;
            case 4:
                spriteRenderer.sprite = _diceSpritesDefence[3];
                break;
            case 5:
                spriteRenderer.sprite = _diceSpritesDefence[4];
                break;
            case 6:
                spriteRenderer.sprite = _diceSpritesDefence[5];
                break;
            default:
                break;
        }
    }

}
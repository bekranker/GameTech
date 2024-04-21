using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private DiceSystem _diceSystem;
    [SerializeField] private WaveSystem _waveSystem;
    [SerializeField] private CameraFollow _cameraFollow;
    [SerializeField] private Player _player;
    [SerializeField] private MouseHandler _mouseHandler;
    [SerializeField] private List<DiceHolder> _diceHolders;

    void Start()
    {
        _waveSystem.SpawnEnemies();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void NextTurn()
    {
        StartCoroutine(nextTurnIE());
    }
    private IEnumerator nextTurnIE()
    {
        _waveSystem.RemoveEmpties();
        //kamera dusmanlarda
        //dusmanlar sirayla yurur ya da dusman yakinimizda ise bize saldirir
        for (int i = 0; i < _waveSystem.SpawnedEnemies.Count;)
        {
            print("waiting");
            _waveSystem.SpawnedEnemies[i].EnemyAction();
            yield return new WaitUntil(() => _waveSystem.SpawnedEnemies[i]._arrived == true);
            i++;
            print("Finish");
        }
        //kamera bize geri gelir
        _cameraFollow.SetTarget(_player.transform);
        //kamera bizde biraz bekler
        yield return new WaitForSeconds(1f);
        //dusmanlar sirayla spawn olmaya baslar
        //kamera yeni spawn olan dusmanlara gider
        _waveSystem.NextWave();
        _waveSystem.SpawnEnemies();
        yield return new WaitUntil(() => _waveSystem.TheySpawned == true);
        //spawn bittikten sonra kamera bize geri gelir
        yield return new WaitForSeconds(2f);
        _diceSystem.CanRoll = true;
        _diceSystem.DidRoll = false;
        _diceSystem.CanSetConfigs = true;
        _mouseHandler.Attacked = false;
        _diceHolders?.ForEach(x => x.DecreaseDiceHealth());

        //kamera bizde biraz bekler ve eger kaybetmediysek yukari da ki bar saga ilerler 
        //next Turn Effecti gelir.
    }
}

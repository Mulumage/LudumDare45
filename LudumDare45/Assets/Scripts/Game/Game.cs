using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance;

    [SerializeField] private IntReference _health;
    [SerializeField] private IntReference _maxHealth;
    [SerializeField] private IntReference _score;
    [SerializeField] private BoolReference _hasSelected;
    [SerializeField] private FloatReference _dungeonTime;
    [SerializeField] private FloatReference _maxDungeonTime;

    private int _numberOfTurns;


    private void Awake()
    {
        Instance = this;
        _health.Reset();
        _maxHealth.Reset();
        _score.Reset();
    }

    private IEnumerator Start()
    {   
        yield return GameLoop();
    }

    private IEnumerator GameLoop()
    {
        while (_health.Value > 0)
        {
            yield return DungeonPhase();          
            
            while (Time.timeScale > 0.01f)
            {
                var time = Time.timeScale;
                time -= 0.1f;
                Time.timeScale = Mathf.Max(time, 0);
                yield return new WaitForSecondsRealtime(0.1f);
            }

            Time.timeScale = 0;
            
            yield return DungeonSelectionPhase();
            yield return EnemySelectionPhase();

            while (Time.timeScale < 1)
            {
                Time.timeScale += 0.1f;
                yield return new WaitForSeconds(0.1f);
            }

            Time.timeScale = 1;
        }
    }
 

    private IEnumerator DungeonPhase()
    {
        _dungeonTime.Value = _maxDungeonTime.Value;
        _dungeonTime.Value += _numberOfTurns * 2;
        
        Time.timeScale = 1;   
        while (_dungeonTime.Value > 0)
        {
            yield return new WaitForEndOfFrame();
            _dungeonTime.Value -= Time.deltaTime;
        }

        _numberOfTurns++;
    }
   

    private IEnumerator EnemySelectionPhase()
    {
        if (EnemyUnlockInterface.Instance.IsAllUnlocked())
            yield break;
        
        Time.timeScale = 0;
        _hasSelected.Value = false;
        
        EnemyUnlockInterface.Instance.SetEnabled(true);

        while (!_hasSelected.Value)
        {
            yield return null;
        }
        
        EnemyUnlockInterface.Instance.SetEnabled(false);
    }
    
    private IEnumerator DungeonSelectionPhase()
    {
        if (DungeonUnlockInterface.Instance.IsAllUnlocked())
            yield break;
        
        Time.timeScale = 0;
        _hasSelected.Value = false;
        
        DungeonUnlockInterface.Instance.SetEnabled(true);

        while (!_hasSelected.Value)
        {
            yield return null;
        }
        
        DungeonUnlockInterface.Instance.SetEnabled(false);
    }
}

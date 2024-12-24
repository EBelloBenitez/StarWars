using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] 
    private GameObject panelGameOver;

    [SerializeField] 
    private EnemyManager enemyManager;

    public void LoadSceneLevel()
    {
        SceneManager.LoadScene("Level01");
    }
    
    public void GameOver()
    {
        panelGameOver.SetActive(true);
        enemyManager.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : DucHienMonoBehaviour
{
    private static LevelManager _instance;
    public static LevelManager Instance => _instance;
    public List<GameObject> levels; // Danh sách các prefab màn chơi
    //public Transform levelSpawnPoint; // Vị trí spawn màn chơi đầu tiên

    private int currentLevelIndex; // Chỉ số màn chơi hiện tại
    private GameObject currentLevel; // Màn chơi hiện tại

    protected override void Awake()
    {
        base.Awake();
        if (_instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        _instance = this;
    }
    protected override void Start()
    {
        base.Start();
        currentLevelIndex = 0;
        SpawnLevel();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLevels();
    }
    protected virtual void LoadLevels()
    {
        levels = new List<GameObject>();
        for (int i = 0; i < this.transform.childCount; i++)
        {
            levels.Add(this.transform.GetChild(i).gameObject);
        }
    }    

    private void SpawnLevel()
    {
        if (currentLevel != null)
        {
            Destroy(currentLevel);
        }

        currentLevel = Instantiate(levels[currentLevelIndex], transform.position, Quaternion.identity);
        currentLevel.gameObject.SetActive(true);
    }

    public void CompleteLevel()
    {
        // Kiểm tra nếu đã hoàn thành tất cả màn chơi
        if (currentLevelIndex >= levels.Count - 1)
        {
            Debug.Log("Game Completed");
            // Hiển thị thông báo hoặc chuyển sang màn chơi kết thúc trò chơi
            return;
        }

        currentLevelIndex++;
        SpawnLevel();
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class score : MonoBehaviour
{
    public static score Instance;
    public int score_ = 0;
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddPoint()
    {
        score_++;
        scoreText.text = "Score: " + score_;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

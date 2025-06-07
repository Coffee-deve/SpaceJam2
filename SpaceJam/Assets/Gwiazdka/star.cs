using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class star : MonoBehaviour
{
    [SerializeField] private int zebrane = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        score.Instance.AddPoint();
        Destroy(gameObject);
        zebrane++;
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

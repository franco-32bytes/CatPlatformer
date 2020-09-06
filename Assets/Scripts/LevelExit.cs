using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float LevelLoadDelay = 2f;
    [SerializeField] float LevelExitSlowMotionFactor = 0.2f;

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        StartCoroutine(LoadNextLevel());
    }

    public IEnumerator LoadNextLevel()
    {
        Time.timeScale = LevelExitSlowMotionFactor;
        yield return new WaitForSecondsRealtime(LevelLoadDelay);
        Time.timeScale = 1f;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Destroy(FindObjectOfType<ScenePersist>().gameObject);
        FindObjectOfType<ScenePersist>().gameObject.SetActive(false);
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}

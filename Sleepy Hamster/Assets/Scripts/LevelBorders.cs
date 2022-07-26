using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelBorders : MonoBehaviour
{
    [SerializeField] private float _delayBeforeLevelRestart;
    private bool _levelComplited = false;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out LevelBordersCross levelBordersCross) && _levelComplited == false)
        {
            StartCoroutine(RestartLevel());
        }
    }

    private IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(_delayBeforeLevelRestart);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}


using System.Collections;
using UnityEngine;

public class GameOverScrene : MonoBehaviour
{
    private const float DefaultDelay = 2f;

    [SerializeField]
    private GameObject _screne;

    public void Show()
    {
        _screne.SetActive(true);
    }

    public void ShowWithDelay(float delay = DefaultDelay)
    {
        StartCoroutine(ShowScrene(delay));
    }

    private IEnumerator ShowScrene(float delay)
    {
        yield return new WaitForSeconds(delay);
        _screne.SetActive(true);
    }
}
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public AudioSource audioSource; // Ses kayna��

    public void LoadSceneByNumber(int sceneNumber)
    {
        StartCoroutine(PlaySoundAndLoadScene(sceneNumber));
    }

    private IEnumerator PlaySoundAndLoadScene(int sceneNumber)
    {
        // Sesi �al
        audioSource.Play();

        // Sesin �alma s�resini bekle
        yield return new WaitForSeconds(audioSource.clip.length);

        // Sahne de�i�tir
        SceneManager.LoadScene(sceneNumber);
    }
}

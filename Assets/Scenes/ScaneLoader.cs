using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public AudioSource audioSource; // Ses kaynaðý

    public void LoadSceneByNumber(int sceneNumber)
    {
        StartCoroutine(PlaySoundAndLoadScene(sceneNumber));
    }

    private IEnumerator PlaySoundAndLoadScene(int sceneNumber)
    {
        // Sesi çal
        audioSource.Play();

        // Sesin çalma süresini bekle
        yield return new WaitForSeconds(audioSource.clip.length);

        // Sahne deðiþtir
        SceneManager.LoadScene(sceneNumber);
    }
}

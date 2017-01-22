using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{

    public GameObject warningMessage;

    public GameObject show;
    public GameObject hide;

    public void StartGame()
    {
        if (!AudioInput.checkMicrophone())
        {
            Vector3 position = warningMessage.transform.position;

            GameObject Warning = Instantiate(warningMessage);
            Warning.transform.SetParent(GameObject.Find("Canvas").transform);
            Warning.transform.localPosition = position;
            Destroy(Warning, 5.0f);
            //hide.SetActive(false);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowAboutPanel()
    {
        hide.SetActive(false);
        show.SetActive(true);
    }

    public void BackButton()
    {
        hide.SetActive(true);
        show.SetActive(false);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }
}

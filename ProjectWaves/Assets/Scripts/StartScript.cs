using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{

    public GameObject warningMessage;

    public void StartGame()
    {
        if (!AudioInput.checkMicrophone())
        {
            Vector3 position = warningMessage.transform.position;

            GameObject Warning = Instantiate(warningMessage);
            Warning.transform.SetParent(GameObject.Find("Canvas").transform);
            Warning.transform.localPosition = position;
            Destroy(Warning, 5.0f);
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
}

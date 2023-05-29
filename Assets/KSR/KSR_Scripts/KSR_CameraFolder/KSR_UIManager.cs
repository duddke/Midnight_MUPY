using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KSR_UIManager : MonoBehaviour
{
    public void CameraView()
    {
        SceneManager.LoadScene("CameraScene");
    }
    public void CharacterView()
    {
        SceneManager.LoadScene("CharacterScene");
    }
    public void BackToMain()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void BackToSelect()
    {
        SceneManager.LoadScene("SelectScene");
    }
}

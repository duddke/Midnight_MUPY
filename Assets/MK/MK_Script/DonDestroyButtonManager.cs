using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// 1. 버튼 클릭시 씬 이동
// 씬 넘어가도 남아있어야 함
public class DonDestroyButtonManager : MonoBehaviour
{
    // 자기 자신이 있으면 파괴하고 아니라면 유지한다
    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
    }
}

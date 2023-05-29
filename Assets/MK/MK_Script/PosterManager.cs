using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// prefab이 없으면 생성
public class PosterManager : MonoBehaviour
{
    // 프리팹 공장
    public GameObject[] posterFact = new GameObject[3];
    // 생성 위치
    public RectTransform l_pos;
    public RectTransform c_pos;
    public RectTransform r_pos;

    private void Start()
    {
        MakePost(l_pos, 0);
        MakePost(c_pos, 1);
        MakePost(r_pos, 2);
    }
  
    public void MakePost(RectTransform transform, int i)
    {
        GameObject[] poster = new GameObject[3];
        poster[i] = Instantiate(posterFact[i], transform);
        poster[i].transform.position = transform.position;
    }
}

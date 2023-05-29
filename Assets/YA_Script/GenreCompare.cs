using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenreCompare : MonoBehaviour
{
    public static GenreCompare Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            //인스턴스에 나를 넣고
            Instance = this;
            //나를 씬이 전환이 되어도 파괴되지 않게 하겠다
            DontDestroyOnLoad(gameObject);
        }
        //그렇지 않으면
        else
            //나르 파괴하겠다
            Destroy(gameObject);
    }


    //시작 스크르립트 서치세이브
    // 장르비교하기
    public List<int> genreCode = new List<int>();
    public void OnCompare(int[] genre)
    {
        genreCode.Clear();
        for(int i=0; i<genre.Length; i++)
        {
            if(genre[i]==1)
            {
                // 1이 찍혀 있는 자릿수+1 이 장르 코드
                genreCode.Add(i + 1);
                // 장르코드 갱신 뒤 1이찍혀있던 자릿수 속 할당 0으로 바꿔주기
                genre[i] = 0;
            }
        // 장르코드 적혀있는 리스트 이용해서 서버 접속 후 정보 불러오기
        }
        for(int i=0; i<genreCode.Count; i++)
            UIManager.Instance.OnMusicalGenreInfo(genreCode[i]);
        

        
        //엔딩 여기서
    }
}

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
            //�ν��Ͻ��� ���� �ְ�
            Instance = this;
            //���� ���� ��ȯ�� �Ǿ �ı����� �ʰ� �ϰڴ�
            DontDestroyOnLoad(gameObject);
        }
        //�׷��� ������
        else
            //���� �ı��ϰڴ�
            Destroy(gameObject);
    }


    //���� ��ũ����Ʈ ��ġ���̺�
    // �帣���ϱ�
    public List<int> genreCode = new List<int>();
    public void OnCompare(int[] genre)
    {
        genreCode.Clear();
        for(int i=0; i<genre.Length; i++)
        {
            if(genre[i]==1)
            {
                // 1�� ���� �ִ� �ڸ���+1 �� �帣 �ڵ�
                genreCode.Add(i + 1);
                // �帣�ڵ� ���� �� 1�������ִ� �ڸ��� �� �Ҵ� 0���� �ٲ��ֱ�
                genre[i] = 0;
            }
        // �帣�ڵ� �����ִ� ����Ʈ �̿��ؼ� ���� ���� �� ���� �ҷ�����
        }
        for(int i=0; i<genreCode.Count; i++)
            UIManager.Instance.OnMusicalGenreInfo(genreCode[i]);
        

        
        //���� ���⼭
    }
}

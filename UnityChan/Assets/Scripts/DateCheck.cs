using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateCheck : MonoBehaviour
{
    System.DateTime now;
    int nowMonth;
    int nowDay;

    private AudioSource univoice;
    public AudioClip voiceBirthday;
    public AudioClip voiceDate0101;
    public AudioClip voiceDate0115;
    public AudioClip voiceDate0203;
    public AudioClip voiceDate0211;
    public AudioClip voiceDate0214;
    public AudioClip voiceDate0303;
    public AudioClip voiceDate0314;
    public AudioClip voiceDate0319;
    public AudioClip voiceDate0401;
    public AudioClip voiceDate0421;
    public AudioClip voiceDate0422;
    public AudioClip voiceDate0503;
    public AudioClip voiceDate0504;
    public AudioClip voiceDate0505;
    public AudioClip voiceDate0602;
    public AudioClip voiceDate0707;
    public AudioClip voiceDate0720;
    public AudioClip voiceDate0813;
    public AudioClip voiceDate0915; 
    public AudioClip voiceDate0922;
    public AudioClip voiceDate1008;
    public AudioClip voiceDate1010;
    public AudioClip voiceDate1103;
    public AudioClip voiceDate1123;
    public AudioClip voiceDate1224;
    public AudioClip voiceDate1225;
    public AudioClip voiceDate1231;
    private AudioClip[, ] voiceDate = new AudioClip[12 + 1,  31 + 1];
    // Start is called before the first frame update
    void Start()
    {
        // 현재 날씨와 시간 얻기
        now = System.DateTime.Now;
        nowMonth = now.Month;
        nowDay = now.Day;

        // 음성 데이터 날짜별 정리
        voiceDate[1, 1] = voiceDate0101;
        voiceDate[1, 15] = voiceDate0115;
        voiceDate[2, 3] = voiceDate0203;
        voiceDate[2, 11] = voiceDate0211;
        voiceDate[2, 14] = voiceDate0214;
        voiceDate[3, 3] = voiceDate0303;
        voiceDate[3, 14] = voiceDate0314;
        voiceDate[3, 19] = voiceDate0319;
        voiceDate[4, 1] = voiceDate0401;
        voiceDate[4, 21] = voiceDate0421;
        voiceDate[4, 22] = voiceDate0422;
        voiceDate[5, 3] = voiceDate0503;
        voiceDate[5, 4] = voiceDate0504;
        voiceDate[5, 5] = voiceDate0505;
        voiceDate[6, 2] = voiceDate0602;
        voiceDate[7, 7] = voiceDate0707;
        voiceDate[7, 20] = voiceDate0720;
        voiceDate[8, 13] = voiceDate0813;
        voiceDate[9, 15] = voiceDate0915;
        voiceDate[9, 22] = voiceDate0922;
        voiceDate[10, 8] = voiceDate1008;
        voiceDate[10, 10] = voiceDate1010;
        voiceDate[11, 3] = voiceDate1103;
        voiceDate[11, 23] = voiceDate1123;
        voiceDate[12, 24] = voiceDate1224;
        voiceDate[12, 25] = voiceDate1225;
        voiceDate[12, 31] = voiceDate1231;

        // 이전에 실행했던 날짜 얻기
        int oldMonth = PlayerPrefs.GetInt("Month");
        int oldDay = PlayerPrefs.GetInt("Day");
        Debug.Log("이전 실행일 : " + oldMonth + "월 " + oldDay + "일\n" + "현재 실행일 : " + nowMonth + "월 " + nowDay + "일");

        // 해당 날짜의 음성이 있으면 재생
        univoice = GetComponent<AudioSource>();
        if (voiceDate[nowMonth, nowDay] != null && (oldMonth != nowMonth || oldDay != nowDay)) // 같은날에 한번밖에 실행안되게 되어있음
            univoice.PlayOneShot(voiceDate[nowMonth, nowDay]); // 처음 한번 재생

        // 현재 실행한 날짜 기록
        PlayerPrefs.SetInt("Month", nowMonth);
        PlayerPrefs.SetInt("Day", nowDay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

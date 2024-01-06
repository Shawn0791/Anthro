using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Video_change : MonoBehaviour
{
    double video_time, currentTime;
    //这里的video_img我是用来放RawImage的，挂载脚本后将RawImage拖入即可
    public GameObject video_img;

    public GameObject UI;
    void Start()
    {
        video_time = video_img.GetComponent<VideoPlayer>().clip.length;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= video_time)
        {
            //视频播放结束，这里可以写视频播放结束后的事件
            UI.SetActive(true);
        }
    }
}
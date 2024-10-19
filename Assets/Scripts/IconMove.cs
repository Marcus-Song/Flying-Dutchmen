using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconMove : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject tabletTop;

    // Start is called before the first frame update
    void Start()
    {
        // 如果没有指定摄像机,则使用主摄像机
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {

        // 更新摄像机和 tabletTop 的位置
        if (mainCamera != null && tabletTop != null)
        {
            Vector3 newPosition = transform.position;
            newPosition.y -= 1f; // 将 y 坐标降低 1 个单位
            newPosition.z = mainCamera.transform.position.z;
            mainCamera.transform.position = newPosition;
            
            // 更新 tabletTop 的位置
            Vector3 tabletTopPosition = newPosition;
            tabletTopPosition.z = tabletTop.transform.position.z; // 保持 tabletTop 的原始 z 坐标
            tabletTop.transform.position = tabletTopPosition;
        }
    }
}

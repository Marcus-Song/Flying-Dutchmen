using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    public bool isDragging = false;
    private Vector3 offset;
    private Camera mainCamera;
    private Rigidbody2D rb; // 添加 Rigidbody2D 引用

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>(); // 获取 Rigidbody2D 组件
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition) + offset;
            newPosition.z = 0f; // 保持z坐标不变，假设在2D平面上操作
            transform.position = newPosition;
            
            // 保持竖直角度
            transform.rotation = Quaternion.identity;
        }
    }

    void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - mainCamera.ScreenToWorldPoint(Input.mousePosition);
        
        if (rb != null)
        {
            rb.velocity = Vector2.zero; // 重置速度
            rb.angularVelocity = 0f; // 重置角速度
            rb.isKinematic = true; // 禁用物理模拟
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
        
        if (rb != null)
        {
            rb.isKinematic = false; // 重新启用物理模拟
        }
    }
}

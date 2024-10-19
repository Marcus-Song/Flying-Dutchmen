using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Materials : MonoBehaviour
{
    public string materialName;
    private Vector3 originalPosition;
    private bool isHidden = false;

    private DragDrop dragdrop;

    void Start()
    {
        originalPosition = transform.position;
        dragdrop = GetComponent<DragDrop>();
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);

        if (collision.gameObject.name == "Decanter" && !isHidden) {
            AddComponent addComponent = collision.gameObject.GetComponent<AddComponent>();
            DragDrop collideDragDrop = collision.gameObject.GetComponent<DragDrop>();
            if (addComponent != null && !collideDragDrop.isDragging && !dragdrop.isDragging)
            {
                addComponent.AddMaterial(this.gameObject);
                HideItem();
            }
        }
    }

    void HideItem()
    {
        // 禁用渲染器来隐藏物品
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.enabled = false;
        }

        // 禁用碰撞器
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.enabled = false;
        }

        // 禁用 DragDrop 脚本
        DragDrop dragDrop = GetComponent<DragDrop>();
        if (dragDrop != null)
        {
            dragDrop.enabled = false;
        }

        // 将物品移动到场景外
        transform.position = new Vector3(10000, 10000, 10000);

        isHidden = true;
    }

    public void RestoreItem()
    {
        if (isHidden)
        {
            // 启用渲染器
            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = true;
            }

            // 启用碰撞器
            Collider2D collider = GetComponent<Collider2D>();
            if (collider != null)
            {
                collider.enabled = true;
            }

            // 启用 DragDrop 脚本
            DragDrop dragDrop = GetComponent<DragDrop>();
            if (dragDrop != null)
            {
                dragDrop.enabled = true;
            }

            // 将物品移回原始位置
            transform.position = originalPosition;

            isHidden = false;
        }
    }
}

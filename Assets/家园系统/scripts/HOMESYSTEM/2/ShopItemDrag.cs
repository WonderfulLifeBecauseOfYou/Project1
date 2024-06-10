﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopItemDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private ShopItem Item;

    public static Canvas canvas;

    private RectTransform rt;
    private CanvasGroup cg;
    private Image img;

    private Vector3 originPos;
    private bool drag;



    public void Initialize(ShopItem item)
    {
        Item = item;
    }
    private void Awake()
    {

        rt = GetComponent<RectTransform>();
        cg = GetComponent<CanvasGroup>();

        img = GetComponent<Image>();
        originPos = rt.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        drag = true;
        cg.blocksRaycasts = false;
        img.maskable = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rt.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        drag = false;
        cg.blocksRaycasts = true;
        img.maskable = true;
        rt.anchoredPosition = originPos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        HomeShopManager.current.ShopButton_Click();

        Color c = img.color;
        c.a = 0f;
        img.color = c;

        Vector3 position = new Vector3(transform.position.x, transform.position.y);
        position = Camera.main.ScreenToWorldPoint(position);
        var obj = GridBuildingSystem.current.InitializeWithBuilding(Item.Prefab, position);
        obj.GetComponent<Building>().Initialize(Item);
    }

    private void OnEnable()
    {
        drag = false;
        cg.blocksRaycasts = true;
        img.maskable = true;
        rt.anchoredPosition = originPos;

        Color c = img.color;
        c.a = 1f;
        img.color = c;
    }
}

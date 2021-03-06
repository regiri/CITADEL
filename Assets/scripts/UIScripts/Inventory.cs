﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
//каждый раз когда я не буду понимать что здесь происходит я буду добавлять сюда 1
//текущий счётчик заёбанности: 4
public class Inventory : MonoBehaviour
{
    public Database data;

    public List<ItemInventory> items = new List<ItemInventory>();

    public GameObject gameObjShow;

    public GameObject InventoryMainObject;
    public int maxCount;

    public Camera cam;
    public EventSystem es;
    int trig;
    public int currentID;
    public ItemInventory currentItem;
    public RectTransform movingObject;
    public Vector3 offset;
    //public GameObject backGrownd;
    public void Start() {
        if (items.Count == 0) {
            AddGraphics();
        }
        for (int i = 0; i < maxCount; i++) { //тест, рандомное заполнение
            AddItem(i, data.items[0], 1);
        }
        UpdateInventory();
    }

    public void Update() {
        if (currentID != -1) {
            MoveObject();
        }
        trig = GameObject.Find("helper").GetComponent<mouse_follow>().flag;
        if (trig == 2 && Input.GetMouseButtonDown(1)) {
            SearchForSameItem(data.items[trig], 1);
        }
        /*for (int i = 0; i < maxCount; i++) {
            if (items[i].id == 0) {
                if (trig == 2 && Input.GetMouseButtonDown(1)) {
                    AddItem(i, data.items[trig], 1);
                    i = maxCount;
                }
            }
        }*/
        UpdateInventory();
        /*if (Input.GetKeyDown(KeyCode.I)) {
            backGrownd.SetActive(!backGrownd.activeSelf);
            if (backGrownd.activeSelf) {
                UpdateInventory();
            }
        }*/
    }

    public void SearchForSameItem(Item item, int count) {
        for (int i = 0; i < maxCount; i++) {
            if (items[i].id == item.id) {
                if (items[i].count < item.stuck) {
                    items[i].count += count;
                    if (items[i].count > item.stuck) {
                        count = items[i].count - item.stuck;
                        items[i].count = item.stuck / 2;
                    }
                    else {
                        count = 0;
                        i = maxCount;
                    }
                }
            }
        }

        if (count > 0) {
            for (int i = 0; i < maxCount; i++) {
                if (items[i].id == 0) {
                    AddItem(i, item, count);
                    i = maxCount;
                }
            }
        }
    }

    public void AddItem(int id, Item item, int count) {
        items[id].id = item.id;
        items[id].count = count;
        items[id].itemGameObj.GetComponent<Image>().sprite = item.img;

        if (count > 1 && item.id != 0) {
            items[id].itemGameObj.GetComponentInChildren<Text>().text = count.ToString();
        }
        else {
            items[id].itemGameObj.GetComponentInChildren<Text>().text = "";
        }
    }

    public void AddInventoryItem(int id, ItemInventory invItem) {
        items[id].id = invItem.id;
        items[id].count = invItem.count;
        items[id].itemGameObj.GetComponent<Image>().sprite = data.items[invItem.id].img;

        if (invItem.count > 1 && invItem.id != 0) {
            items[id].itemGameObj.GetComponentInChildren<Text>().text = invItem.count.ToString();
        }
        else {
            items[id].itemGameObj.GetComponentInChildren<Text>().text = "";
        }
    }

    public void AddGraphics() {
        for (int i = 0; i < maxCount; i++) {
            GameObject newItem = Instantiate(gameObjShow, InventoryMainObject.transform) as GameObject;

            newItem.name = i.ToString();

            ItemInventory ii = new ItemInventory();
            ii.itemGameObj = newItem;

            RectTransform rt = newItem.GetComponent<RectTransform>();
            rt.localPosition = new Vector3(0, 0, 0);
            rt.localScale = new Vector3(1, 1, 1);

            newItem.GetComponentInChildren<RectTransform>().localScale = new Vector3(1, 1, 1);

            Button tempButton = newItem.GetComponent<Button>();

            tempButton.onClick.AddListener(delegate { SelectObject(); });

            items.Add(ii);
        }
    }

    public void UpdateInventory() {
        for (int i = 0; i < maxCount; i++) {
            if (items[i].id != 0 && items[i].count > 1) {
                items[i].itemGameObj.GetComponentInChildren<Text>().text = items[i].count.ToString();
            }
            else {
                items[i].itemGameObj.GetComponentInChildren<Text>().text = "";
            }

            items[i].itemGameObj.GetComponentInChildren<Image>().sprite = data.items[items[i].id].img;
        }
    }

    public void SelectObject() {
        if (currentID == -1) {
            currentID = int.Parse(es.currentSelectedGameObject.name);
            currentItem = CopyInventoryItem(items[currentID]);
            movingObject.gameObject.SetActive(true);
            movingObject.GetComponent<Image>().sprite = data.items[currentItem.id].img;
            currentItem.stuck = data.items[currentItem.id].stuck;
            AddItem(currentID, data.items[0], 0); 
        }
        else {
            ItemInventory II = items[int.Parse(es.currentSelectedGameObject.name)];
            if (currentItem.id != II.id) {
                AddInventoryItem(currentID, II);
                AddInventoryItem(int.Parse(es.currentSelectedGameObject.name), currentItem); 
            }
            else {
                if(II.count + currentItem.count <= currentItem.stuck) {
                    II.count += currentItem.count;
                }
                else {
                    AddItem(currentID, data.items[II.id], II.count + currentItem.count - currentItem.stuck);
                    II.count = currentItem.stuck;
                }
                II.itemGameObj.GetComponentInChildren<Text>().text = II.count.ToString();
            }
            currentID = -1;

            movingObject.gameObject.SetActive(false);
        }
    }

    public void MoveObject() {
        Vector3 pos = Input.mousePosition + offset;
        pos.z = InventoryMainObject.GetComponent<RectTransform>().position.z;
        movingObject.position = cam.ScreenToWorldPoint(pos);
    }

    public ItemInventory CopyInventoryItem(ItemInventory old) {
        ItemInventory New = new ItemInventory {
            id = old.id,
            itemGameObj = old.itemGameObj,
            count = old.count
        };

        return New;
    }
}

[System.Serializable]

public class ItemInventory
{
    public int id;
    public GameObject itemGameObj;
    public int count;
    public int stuck;
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CSVReader : MonoBehaviour {
    public TextAsset textAssetData;
    [System.Serializable] public class Trash {
        public string name;
        public int trashType;
    }

    [System.Serializable] public class TrashList {
        public Trash[] trashList;
    }

    public TrashList trashList = new TrashList();

    // Start is called before the first frame update
    void Start() {
        ReadCSV();
    }

    void ReadCSV() {
        string[] data = textAssetData.text.Split(new string[] {",", "\n"}, StringSplitOptions.None);

        int tableSize = data.Length / 2 - 1;
        trashList.trashList = new Trash[tableSize];

        for (int i = 0; i < tableSize; i++) {
            trashList.trashList[i] = new Trash();
            trashList.trashList[i].name = data[2 * (i + 1)];
            trashList.trashList[i].trashType = int.Parse(data[2 * (i + 1) + 1]);
        }
    }
}

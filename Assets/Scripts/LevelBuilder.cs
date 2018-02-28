/// <summary>
/// This script builds out the level from an XML (text file). Functionalities include:
/// 
/// 1. Loading the file into an array of strings consisting of document lines.
/// 2. Iterating through each character in each line and instantiating the correct 
///    brick based on the brick legend (char, Transform pairs).
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelBuilder : MonoBehaviour {
    [SerializeField]
    private TextAsset levelMap;
    [SerializeField]
    private Transform pointer;
    private Vector3 initPointerPos;

    [Serializable]
    private struct LegendItem
    {
        public char name;
        public Transform brick;
    }

    [SerializeField]
    private LegendItem[] brickLegend;

    void Awake()
    {
        initPointerPos = pointer.position;
        BuildLevel();
    }

    void BuildLevel()
    {
        string[] rows = ReadFile(levelMap);

        for (int row = 0; row < rows.Length; row++)
        {
            foreach (char c in rows[row])
            {
                foreach (LegendItem li in brickLegend)
                {
                    if (li.name == c)
                    {
                        Instantiate(li.brick, pointer.position, Quaternion.identity);
                    }
                }

                //Move 1 Collum
                pointer.position += Vector3.right;
            }

            //Move 1 Row
            pointer.position = new Vector3(initPointerPos.x, pointer.position.y - 0.2f, initPointerPos.z);
        }
    }

    string[] ReadFile(TextAsset file)
    {
        string data = levelMap.text;

        string[] lines = data.Split( new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

        return lines;
    }
}

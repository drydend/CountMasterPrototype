using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class LevelCounterUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _text;

    private void Awake()
    {
        _text.text = "Level " + LevelLoader.Instance.CurrentLevelNumber.ToString();
    }
}


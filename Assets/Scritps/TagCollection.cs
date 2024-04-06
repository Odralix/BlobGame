using System.Collections.Generic;
using UnityEngine;

public class TagCollection : MonoBehaviour
{
    Dictionary<string, Color> TagDict = new Dictionary<string, Color>()
    {
        {"Helpful", Color.green},
        {"Playful", Color.yellow},
    };

}

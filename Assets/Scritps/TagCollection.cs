using System.Collections.Generic;
using UnityEngine;

public static class TagCollection
{
    static Dictionary<TagsEnum, Color> TagDict = new Dictionary<TagsEnum, Color>()
    {
        {TagsEnum.Helpful, Color.green},
        {TagsEnum.Violent, Color.red},
        {TagsEnum.Studious, Color.blue},
    };

}

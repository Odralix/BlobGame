using System.Collections.Generic;
using UnityEngine;

public static class TagCollection
{
    public static Dictionary<TagsEnum, Color> TagDict = new Dictionary<TagsEnum, Color>()
    {
        {TagsEnum.Helpful, Color.green},
        {TagsEnum.Violent, Color.red},
        {TagsEnum.Studious, Color.cyan},
        {TagsEnum.Playful, Color.yellow},
    };

}

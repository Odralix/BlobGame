using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerTagsAndCount : MonoBehaviour
{
    [SerializeField]
    Dictionary<TagsEnum, int> collectedTags = new Dictionary<TagsEnum, int>();

    [SerializeField]
    UIDocument document;

    Label infoText;
    // Start is called before the first frame update
    void Start()
    {
        infoText = (Label)document.rootVisualElement.Q("Info");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddTag(TagsEnum tag)
    {
        if (collectedTags.ContainsKey(tag))
        {
            collectedTags[tag] += 1;
        }
        else
        {
            collectedTags.Add(tag, 1);
        }
        infoText.text = $"+1 {Enum.GetName(typeof(TagsEnum), tag)} !";
        infoText.style.color = TagCollection.TagDict[tag];
    }
}

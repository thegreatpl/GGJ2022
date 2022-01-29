using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public struct InspectorAnimation
{
    public string name;
    public Sprite[] sprites;
}

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteAnimator : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    float count = 0;

    int frame = 0;

    /// <summary>
    /// How fast this animates. 
    /// </summary>
    public float AnimationRate = 0.1f;

    /// <summary>
    /// The current Animation of this object. 
    /// </summary>
    public string CurrentAnimation; 

    /// <summary>
    /// Collection of all possible sprites this entity can do. 
    /// </summary>
    public Dictionary<string, Sprite[]> sprites = new Dictionary<string,Sprite[]>();

    /// <summary>
    /// Make the sprites configurable in the editor. 
    /// </summary>
    public List<InspectorAnimation> InspectorAnimations = new List<InspectorAnimation>();

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        foreach(var insp in InspectorAnimations)
            sprites.Add(insp.name, insp.sprites);

        if (string.IsNullOrWhiteSpace(CurrentAnimation))
            CurrentAnimation = sprites.ElementAt(0).Key; 
    }

    // Update is called once per frame
    void Update()
    {
        if (count >= AnimationRate)
        {
            spriteRenderer.sprite = sprites[CurrentAnimation][frame];
            frame++;
            if (sprites[CurrentAnimation].Length <= frame)
                frame = 0;

            count = 0;
        }

        count += 1 * Time.deltaTime;
    }


    public void SetAnimation(string animation)
    {
        if (animation == CurrentAnimation)
            return;

        if (!sprites.ContainsKey(animation))
            return; 

        CurrentAnimation = animation;
        frame = 0;
    }
}

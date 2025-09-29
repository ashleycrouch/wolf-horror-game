using deVoid.Utils;
using Project.InputSignals;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Sprite NorthWestSprite, SouthEastSprite;

    struct SpriteDirectionInstructions {
        Sprite sprite;
        bool flipX;
        bool flipY;
    }

    [SerializeField]
    Dictionary<Direction, SpriteDirectionInstructions> directionSprites =
        new Dictionary<Direction, SpriteDirectionInstructions>();

    bool flipX, flipY;
    Direction currentDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Signals.Get<InputDirectionSignal>().AddListener(OnReceiveInputDirection);
    }

    private void OnDestroy()
    {
        Signals.Get<InputDirectionSignal>().RemoveListener(OnReceiveInputDirection);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetSprite(Direction direction)
    {
        currentDirection = direction;
        //directionSprites[direction];
    }

    void OnReceiveInputDirection(Direction direction)
    {
        if (direction == currentDirection)
        {
            return;
        }

        //directionSprites[direction];

    }
}

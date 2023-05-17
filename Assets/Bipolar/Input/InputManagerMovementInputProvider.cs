﻿using UnityEngine;
#if NAUGHTY_ATTRIBUTES
using NaughtyAttributes;
#endif

namespace Bipolar.Input
{
    public class InputManagerMovementInputProvider : MonoBehaviour, IMoveInputProvider
    {
#if NAUGHTY_ATTRIBUTES
        [InputAxis]
#endif
        [SerializeField]
        private string horizontalAxis = "Horizontal";
        
#if NAUGHTY_ATTRIBUTES
        [InputAxis]
#endif
        [SerializeField]
        private string verticalAxis = "Vertical";

        [SerializeField]
        private bool rawInput;

        public float GetHorizontal() => GetAxis(horizontalAxis);

        public float GetVertical() => GetAxis(verticalAxis);

        private float GetAxis(string axisName) => InputManagerAxisInputProvider.GetAxis(axisName, rawInput);
    }
}

namespace ReactUnity.Animations
{
    public enum TimingFunctionType
    {
        EaseIn = 0,
        EaseInQuad = 0,
        EaseOut = 1,
        EaseOutQuad = 1,
        EaseInOut = 2,
        EaseInOutQuad = 2,
        EaseInCubic = 3,
        EaseOutCubic = 4,
        EaseInOutCubic = 5,
        EaseInQuart = 6,
        EaseOutQuart = 7,
        EaseInOutQuart = 8,
        EaseInQuint = 9,
        EaseOutQuint = 10,
        EaseInOutQuint = 11,
        EaseInSine = 12,
        EaseOutSine = 13,
        EaseInOutSine = 14,
        EaseInExpo = 15,
        EaseOutExpo = 16,
        EaseInOutExpo = 17,
        EaseInCirc = 18,
        EaseOutCirc = 19,
        EaseInOutCirc = 20,
        Linear = 21,
        Spring = 22,
        EaseInBounce = 23,
        EaseOutBounce = 24,
        EaseInOutBounce = 25,
        EaseInBack = 26,
        EaseOutBack = 27,
        EaseInOutBack = 28,
        EaseInElastic = 29,
        EaseOutElastic = 30,
        EaseInOutElastic = 31,
        Clerp = 32,
        Ease = 33,
        SmoothStep = 33,
        SmootherStep = 34,
        SmoothestStep = 35,
        StepStart = 36,
        DownEdge = 36,
        MidEdge = 37,
        StepEnd = 38,
        UpEdge = 38,
    }

    public enum StepsJumpMode
    {
        None = 0,
        JumpNone = 0,
        Start = 1,
        JumpStart = 1,
        End = 2,
        JumpEnd = 2,
        Both = 3,
        JumpBoth = 3,
    }
}
﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Game.Beatmaps;
using osu.Game.Beatmaps.ControlPoints;
using osu.Game.Rulesets.Karaoke.Objects;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.Objects.Types;
using OpenTK;
using OpenTK.Graphics;

namespace osu.Game.Rulesets.Karaoke.Osu_Objects
{
    public abstract class OsuHitObject : KaraokeObject
    {
        public const double OBJECT_RADIUS = 64;

        private const double hittable_range = 300;
        private const double hit_window_50 = 150;
        private const double hit_window_100 = 80;
        private const double hit_window_300 = 30;

        //public Vector2 Position { get; set; }
        //public float X => Position.X;
        //public float Y => Position.Y;

        public Vector2 StackedPosition => Position + StackOffset;

        public virtual Vector2 EndPosition => Position;

        public Vector2 StackedEndPosition => EndPosition + StackOffset;

        public virtual int StackHeight { get; set; }

        public Vector2 StackOffset => new Vector2(StackHeight * Scale * -6.4f);

        public double Radius => OBJECT_RADIUS * Scale;

        public float Scale { get; set; } = 1;

        public Color4 ComboColour { get; set; } = Color4.Gray;

        public double HitWindowFor(HitResult result)
        {
            switch (result)
            {
                default:
                    return 300;
                case HitResult.Meh:
                    return 150;
                case HitResult.Good:
                    return 80;
                case HitResult.Great:
                    return 30;
            }
        }

        public HitResult ScoreResultForOffset(double offset)
        {
            if (offset < HitWindowFor(HitResult.Great))
                return HitResult.Great;
            if (offset < HitWindowFor(HitResult.Good))
                return HitResult.Good;
            if (offset < HitWindowFor(HitResult.Meh))
                return HitResult.Meh;
            return HitResult.Miss;
        }

        public override void ApplyDefaults(ControlPointInfo controlPointInfo, BeatmapDifficulty difficulty)
        {
            base.ApplyDefaults(controlPointInfo, difficulty);

            Scale = (1.0f - 0.7f * (difficulty.CircleSize - 5) / 5) / 2;
        }
    }
}

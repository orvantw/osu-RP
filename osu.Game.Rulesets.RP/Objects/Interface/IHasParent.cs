﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

namespace osu.Game.Rulesets.RP.Objects.Interface
{
    public interface IHasParent<T> : IHasParentID
    {
        T ParentObject { get; set; }

        double RelativeToParentStartTime { get; set; }
    }
}

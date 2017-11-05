﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.Objects;

namespace osu.Game.Rulesets.Karaoke.Osu_Objects.Drawables.Connections
{
    /// <summary>
    /// Connects hit objects visually, for example with follow points.
    /// </summary>
    public abstract class ConnectionRenderer<T> : Container
        where T : HitObject
    {
        /// <summary>
        /// Hit objects to create connections for
        /// </summary>
        public abstract IEnumerable<T> HitObjects { get; set; }
    }
}

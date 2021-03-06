﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System;
using System.Threading;
using osu.Framework.Platform;

namespace osu.Game.Database
{
    public abstract class DatabaseBackedStore
    {
        protected readonly Storage Storage;

        /// <summary>
        /// Create a new <see cref="OsuDbContext"/> instance (separate from the shared context via <see cref="GetContext"/> for performing isolated operations.
        /// </summary>
        protected readonly Func<OsuDbContext> CreateContext;

        private readonly ThreadLocal<OsuDbContext> queryContext;

        /// <summary>
        /// Retrieve a shared context for performing lookups (or write operations on the update thread, for now).
        /// </summary>
        protected OsuDbContext GetContext() => queryContext.Value;

        protected DatabaseBackedStore(Func<OsuDbContext> createContext, Storage storage = null)
        {
            CreateContext = createContext;

            // todo: while this seems to work quite well, we need to consider that contexts could enter a state where they are never cleaned up.
            queryContext = new ThreadLocal<OsuDbContext>(CreateContext);

            Storage = storage;
        }

        /// <summary>
        /// Perform any common clean-up tasks. Should be run when idle, or whenever necessary.
        /// </summary>
        public virtual void Cleanup()
        {
        }
    }
}

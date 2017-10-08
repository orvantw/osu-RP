﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using System.Linq;
using osu.Framework.Graphics;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.RP.Judgements;
using osu.Game.Rulesets.RP.KeyManager;
using osu.Game.Rulesets.RP.Objects.Drawables.Component.Interface;
using osu.Game.Rulesets.RP.Objects.Drawables.Extension;
using osu.Game.Rulesets.RP.Objects.Drawables.Interface;
using osu.Game.Rulesets.RP.Objects.Interface;
using OpenTK;
using OpenTK.Graphics;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Play
{
    public class DrawableBaseRpObject : DrawableHitObject<BaseRpObject>, IHasTemplate
    {
        public List<IComponentBase> Components { get; set; }
        public BaseRpObject RpObject => HitObject;

        //FadeInTime
        public virtual float FadeInTime => 200;

        //FadeOutTime
        public virtual float FadeOutTime => 300;

        public virtual float PreemptTime => HitObject.PreemptTime;

        /// <summary>
        ///     樣板，把物件綁上去就對了
        /// </summary>
        public Template.Template Template { get; set; }

        public DrawableBaseRpObject(BaseRpObject hitObject)
            : base(hitObject)
        {
            AccentColour = new Color4(255, 255, 255, 255);
            Alpha = 0;

            Components = new List<IComponentBase>();

            Origin = Anchor.Centre;
            Position = new Vector2(100, 100);

            //initial component
            ConstructObject();
            //initial template and 
            InitialChildObject();
        }

        //建構樣板物件
        protected virtual void ConstructObject()
        {

        }

        //建構
        protected void InitialChildObject()
        {
            if (RpObject as IHasParentID == null)
            {
                this.AddTemplateToChild();

            }
            else
            {
                
            }
        }

        protected override void UpdateState(ArmedState state)
        {
            FinishTransforms();

            using (BeginAbsoluteSequence(HitObject.StartTime - PreemptTime, true))
            {
                UpdateInitialState();

                UpdatePreemptState();

                using (BeginDelayedSequence(PreemptTime + (Judgements.FirstOrDefault()?.TimeOffset ?? 0), true))
                    UpdateCurrentState(state);
            }
        }

        /// <summary>
        /// initial state
        /// </summary>
        protected virtual void UpdateInitialState()
        {
            Hide();
        }

        //正在準備的時候
        protected virtual void UpdatePreemptState()
        {
            this.FadeIn(FadeInTime);
            //Fadein
            Template.FadeIn(FadeInTime);
        }

        /// <summary>
        ///     更新狀態
        /// </summary>
        /// <param name="state"></param>
        protected virtual void UpdateCurrentState(ArmedState state)
        {
           
        }

        /// <summary>
        ///     持續一直更新物件
        /// </summary>
        protected override void Update()
        {
            base.Update();
            //更新物件位置
            Template.UpdateTemplate(Time.Current);
        }

        private RpInputManager osuActionInputManager;
        internal RpInputManager OsuActionInputManager => osuActionInputManager ?? (osuActionInputManager = GetContainingInputManager() as RpInputManager);
    }
}

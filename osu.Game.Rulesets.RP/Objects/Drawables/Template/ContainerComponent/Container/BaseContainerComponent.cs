// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.Calculator;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.Component;
using OpenTK;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Template.RpContainer.Component
{
    public class ComponentBaseContainer :  Container
    {
        /// <summary>
        /// </summary>
        public BaseRpObject HitObject { get; set; }

        public void Initial()
        {
            //throw new System.NotImplementedException();
        }

        /// <summary>
        ///     ΣvZ¨έΤκyYLIΚu
        /// </summary>
        protected readonly ContainerLayoutPositionCounter _positionCounter = new ContainerLayoutPositionCounter();

        public ComponentBaseContainer(RpContainerLineGroup hitObject)
        {
            HitObject = hitObject;
            InitialObject();
            InitialChild();
        }

        /// <summary>
        ///     XVVI LayoutΙΚ
        /// </summary>
        /// <param name="newLayerNumber"></param>
        public virtual void UpdateLayerNumber()
        {
            //Ώn ParentObject ‘Κζ€ζ
        }

        /// <summary>
        ///     @ΚXVΉJn½₯©IΤ
        /// </summary>
        public virtual void UpdateTime()
        {
        }


        /// <summary>
        ///     n»Lθϋ¦¨
        /// </summary>
        protected virtual void InitialObject(int layerCount = 1)
        {
        }

        /// <summary>
        ///     n»Lθϋ¦¨
        /// </summary>
        protected virtual void InitialChild()
        {
        }

        /// <summary>
        ///     ͺΤκyvZ¨Κu
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        protected Vector2 CalculatePosition(double time)
        {
            return new Vector2(_positionCounter.GetPosition(time, HitObject.Velocity), 0);
        }

        /// <summary>
        ///     ζΎΤuΤ
        /// </summary>
        /// <returns></returns>
        protected double GetDeltaBeatTime()
        {
            return 1000 * 60 / HitObject.BPM;
        }
    }
}

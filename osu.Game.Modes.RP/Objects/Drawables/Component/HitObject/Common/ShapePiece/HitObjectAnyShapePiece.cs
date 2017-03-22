using osu.Framework.Graphics;
using osu.Game.Modes.RP.Objects.Drawables.Pieces;
using osu.Game.Modes.RP.SkinManager;
using OpenTK;
using OpenTK.Graphics;

namespace osu.Game.Modes.RP.Objects.Drawables.Component.HitObject.Common.ShapePiece
{
    /// <summary>
    /// èû¦©¨
    /// ÚOïÜ¨é : ©Ió¨
    /// </summary>
    class HitObjectAnyShapePiece : BaseHitObjectShapePiece
    {
        public bool IsFirst = true;

        /// <summary>
        /// Mask
        /// </summary>
        private ImagePicec _maskImagePicec;

        /// <summary>
        /// Mask êºIwi¨
        /// </summary>
        private ImagePicec _startBackgroundImagePicec;

        /// <summary>
        /// Oy
        /// </summary>
        private ImagePicec _borderImagePicec;


        /// <summary>
        /// \
        /// </summary>
        public HitObjectAnyShapePiece(BaseRpObject h)
        {
            HitObject = h;

            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;

            Children = new Drawable[]
              {

                //wiC©æmasking
                _startBackgroundImagePicec = new ImagePicec("")//(RPSkinManager.GetStartObjectBackgroundByType(HitObject as BaseHitObject))
                {
                    Colour = new Color4(100,230,17,255),
                    Scale = new Vector2(0.5f),
                    CornerRadius = DrawSize.X / 2,
                    Masking = true,
                },

                ////ÚOwmaskLpr
                 _maskImagePicec = new ImagePicec("")//RPSkinManager.GetStartObjectMaskByType(HitObject as BaseHitObject))
                {
                    //Colour = osuObject.Colour,
                    Scale=new Vector2(0.5f),
                    Masking = true,
                },

                //Oygp
                 _borderImagePicec=new ImagePicec(RPSkinManager.GetStartObjectImageNameByType(HitObject as BaseHitObject))
                {
                    Colour = SkinColorManager.GetKeyLayoutButtonShage(((BaseHitObject)HitObject).Shape),
                    Scale=new Vector2(0.5f),
                },
              };
        }

        /// <summary>
        /// n»èû¦
        /// </summary>
        public override void Initial()
        {

        }

        /// <summary>
        /// JnÁÁ
        /// </summary>
        public override void FadeIn(double time = 0)
        {

        }

        /// <summary>
        /// ©
        /// </summary>
        public override void FadeOut(double time = 0)
        {

        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="progress"></param>
        /// <param name="repeat"></param>
        public void UpdateProgress(double progress, double endProgress = 1)
        {
            if (IsFirst)
            {
                //ðª¨Ú®
                //_maskImagePicec.Position = HitObject.Curve.PositionAt(progress) - HitObject.Position;
                _borderImagePicec.Position = HitObject.Curve.PositionAt(progress) - HitObject.Position;
            }
            else
            {
                //ðª¨Ú®
                //_maskImagePicec.Position = HitObject.Curve.PositionAt(endProgress) - HitObject.Position;
                _borderImagePicec.Position = HitObject.Curve.PositionAt(endProgress) - HitObject.Position;
            }
            Alpha = 1;
        }

    }
}

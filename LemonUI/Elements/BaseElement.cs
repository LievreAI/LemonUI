#if FIVEM
using CitizenFX.Core.UI;
#elif SHVDN2
using GTA;
#elif SHVDN3
using GTA.UI;
#endif
using System.Drawing;

namespace LemonUI.Elements
{
    /// <summary>
    /// Base class for all of the 2D elements.
    /// </summary>
    public abstract class BaseElement : IDrawable
    {
        #region Private Fields

        /// <summary>
        /// The 1080 scaled position.
        /// </summary>
        protected PointF literalPosition = PointF.Empty;
        /// <summary>
        /// The relative position between 0 and 1.
        /// </summary>
        protected PointF relativePosition = PointF.Empty;
        /// <summary>
        /// The 1080 scaled size.
        /// </summary>
        protected SizeF literalSize = SizeF.Empty;
        /// <summary>
        /// The relative size between 0 and 1.
        /// </summary>
        protected SizeF relativeSize = SizeF.Empty;

        #endregion

        #region Public Properties

        /// <summary>
        /// The Position of the drawable.
        /// </summary>
        public PointF Position
        {
            get
            {
                return literalPosition;
            }
            set
            {
                literalPosition = value;
                Recalculate();
            }
        }
        /// <summary>
        /// The Size of the drawable.
        /// </summary>
        public SizeF Size
        {
            get
            {
                return literalSize;
            }
            set
            {
                literalSize = value;
                Recalculate();
            }
        }
        /// <summary>
        /// The Color of the drawable.
        /// </summary>
        public Color Color { get; set; }
        /// <summary>
        /// The rotation of the drawable.
        /// </summary>
        public float Heading { get; set; }

        #endregion

        #region Constructors

        public BaseElement(PointF pos, SizeF size)
        {
            // Save the position and size
            literalPosition = pos;
            literalSize = size;
            // And recalculate the relative values
            Recalculate();
        }

        #endregion

        #region Private Functions

        /// <summary>
        /// Recalculates the size and position of this item.
        /// </summary>
        protected virtual void Recalculate()
        {
            // Get the resolution of the game window
#if SHVDN2
            SizeF screenSize = Game.ScreenResolution;
#else
            SizeF screenSize = Screen.Resolution;
#endif
            // Calculate the ratio of the resolution (height relative to the width)
            float ratio = screenSize.Width / screenSize.Height;
            // And get the real width
            float width = 1080f * ratio;

            // And save the correct position and sizes
            relativePosition = new PointF(literalPosition.X / width, literalPosition.Y);
            relativeSize = new SizeF(literalSize.Width / width, literalSize.Height / 1080f);
        }

        #endregion

        #region Public Functions

        /// <summary>
        /// Draws the item on the screen.
        /// </summary>
        public abstract void Draw();

        #endregion
    }
}
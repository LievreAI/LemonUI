﻿#if SHVDN3
using GTA;

namespace LemonUI.Scaleform
{
    /// <summary>
    /// Class used to manage the phone scaleform.
    /// </summary>
    public sealed class Phone : BaseScaleform
    {
        #region Properties

        /// <summary>
        /// The type of phone.
        /// </summary>
        public PhoneType Type { get; }

        #endregion
        
        #region Constructors

        /// <inheritdoc/>
        public Phone(PhoneType type) : base(GetName(type))
        {
            Type = type;
        }

        #endregion

        #region Functions

        private static string GetName(PhoneType type)
        {
            switch (type)
            {
                case PhoneType.Badger:
                    return "cellphone_badger";
                case PhoneType.Facade:
                    return "cellphone_facade";
                case PhoneType.IFruit:
                    return "cellphone_ifruit";
                default:
                    return "cellphone_ifruit";
            }
        }
        /// <inheritdoc/>
        public override void Update()
        {
        }
        /// <summary>
        /// Adds a contact at the specified location.
        /// </summary>
        /// <param name="position">The position to add the contact at.</param>
        /// <param name="name">The name of the contact.</param>
        /// <param name="icon">The icon to use.</param>
        public void AddContactAt(int position, string name, string icon)
        {
            CallFunction("SET_DATA_SLOT", 2, position, 0, name, string.Empty, icon);
        }

        #endregion
    }
}
#endif

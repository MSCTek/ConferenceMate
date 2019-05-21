using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSC.CM.Xam.ModelObj.CM
{
    public partial class Session : ObservableObject
    {
        public bool HasLikes
        {
            get { return SessionLikes.Count > 0; }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web;

namespace HayzumTicaret.UI.App_Classes
{
    public class Settings
    {
        public static Size UrunKucukBoyut
        {
            get
            {
                Size sz = new Size();

                sz.Width = Convert.ToInt32(ConfigurationManager.AppSettings["UrunWidthK"]);
                sz.Height=Convert.ToInt32(ConfigurationManager.AppSettings["UrunHeightK"]);

                return sz;
            }
        }

        public static Size UrunBuyukBoyut
        {
            get
            {
                Size sz = new Size();

                sz.Width = Convert.ToInt32(ConfigurationManager.AppSettings["UrunWidthB"]);
                sz.Height = Convert.ToInt32(ConfigurationManager.AppSettings["UrunHeightB"]);

                return sz;
            }
        }

        public static Size SliderBoyut
        {
            get
            {
                Size s = new Size();
                s.Width = Convert.ToInt32(ConfigurationManager.AppSettings["SliderWidth"]);
                s.Height = Convert.ToInt32(ConfigurationManager.AppSettings["SliderHeight"]);
                return s;
            }
        }
    }
}
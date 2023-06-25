using System;
using System.Collections.Generic;
using System.Text;
using System.Workflow.ComponentModel.Design;
using System.Drawing;
using System.Workflow.ComponentModel;

namespace Host
{
    [ActivityDesignerTheme(typeof(WriteFileActivityDesignerTheme))]
	public class WriteFileActivityDesigner : ActivityDesigner
	{
        private const int TEXT_WIDTH = 75;
        private const int PADDING = 4;

        protected override Rectangle ImageRectangle
        {
            get
            {
                Rectangle rect = new Rectangle();
                rect.X = this.Bounds.Left + PADDING;
                rect.Y = this.Bounds.Top + PADDING;
              //  rect.Size = Properties.Resources.Write.Size;
                rect.Size = new Size(16, 16);
                return rect;
            }
        }

        protected override Rectangle TextRectangle
        {
            get
            {
                Rectangle imgRect = this.ImageRectangle;

                Rectangle rect = new Rectangle(
                    imgRect.Right + PADDING,
                    imgRect.Top,
                    TEXT_WIDTH,
                    imgRect.Height);
                return rect;
            }
        }

        protected override void Initialize(Activity activity)
        {
            base.Initialize(activity);

            //Bitmap image = Properties.Resources.Write;
            //image.MakeTransparent();
            //this.Image = image;
        }

        protected override Size OnLayoutSize(ActivityDesignerLayoutEventArgs e)
        {
            base.OnLayoutSize(e);

            //Size imgSize = Properties.Resources.Write.Size;
            //return new Size(imgSize.Width + TEXT_WIDTH + (PADDING * 3),
            //    imgSize.Height + (PADDING * 2));
            return new Size(32, 32);
        }
	}
}

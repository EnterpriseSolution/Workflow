using System;
using System.Collections.Generic;
using System.Text;
using System.Workflow.ComponentModel.Design;
using System.Runtime.Serialization;

namespace  Host
{
    [Serializable]
	public class MyActivityToolboxItem : ActivityToolboxItem
	{
        public MyActivityToolboxItem()
        {
        }

        public MyActivityToolboxItem(Type type)
            : base(type)
        {
            if (type != null)
            {
                if (type.Name.EndsWith("Activity") && !type.Name.Equals("Activity"))
                {
                    base.DisplayName =
                        type.Name.Substring(0, type.Name.Length - 8);
                }
            }
        }

        protected MyActivityToolboxItem(SerializationInfo info,
            StreamingContext context)
        {
            this.Deserialize(info, context);
        }
	}
}

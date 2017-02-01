using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FsxLogger.ViewModels.Messages
{
    public class CloseApplicationMessage : BaseMessage
    {
        public static CloseApplicationMessage Empty { get; set; } = new CloseApplicationMessage();
    }
}
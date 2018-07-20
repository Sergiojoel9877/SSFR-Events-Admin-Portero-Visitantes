using System;
using System.Collections.Generic;
using System.Text;

namespace SSFR_Events.Services
{
    public interface ITakeScreenshot
    {
        byte[] Capture();
    }
}

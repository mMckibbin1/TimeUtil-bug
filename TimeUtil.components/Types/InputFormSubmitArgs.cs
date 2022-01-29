using Microsoft.AspNetCore.Components.Forms;

namespace TimeUtil.Components.Types
{
    public class InputFormSubmitArgs
    {
        public InputFormSubmitArgs(IBrowserFile file)
        {
            File = file;
        }

        public IBrowserFile File { get; }
    }
}

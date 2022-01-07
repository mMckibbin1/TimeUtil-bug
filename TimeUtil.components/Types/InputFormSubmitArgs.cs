using Microsoft.AspNetCore.Components.Forms;

namespace TimeUtil.Components.Types
{
    public class InputFormSubmitArgs
    {
        public InputFormSubmitArgs(IBrowserFile file, IEnumerable<string?> categories)
        {
            File = file;
            Categories = categories;
        }

        public IBrowserFile File { get; }
        public IEnumerable<string?> Categories { get; }
    }
}

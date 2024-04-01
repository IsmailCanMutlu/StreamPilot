using Microsoft.Extensions.Options;
using StreamPilot.Api.Configurations;


namespace StreamPilot.Api.Utilities
{
    public class FileManagerValidation : IValidateOptions<FileManager>
    {
        public ValidateOptionsResult Validate(string name, FileManager options)
        {
            if (options.FolderName.Length > 150)
            {
                return ValidateOptionsResult.Fail("Number of characters exceeded");
            }

            if (string.IsNullOrWhiteSpace(options.Name))
            {
                return ValidateOptionsResult.Fail("Name is required");
            }

            return ValidateOptionsResult.Success;
        }
    }
}
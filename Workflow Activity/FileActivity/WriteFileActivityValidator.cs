using System;
using System.IO;
using System.Workflow.ComponentModel.Compiler;

namespace Host
{
    public class WriteFileActivityValidator : ActivityValidator
    {
        public override ValidationErrorCollection Validate(
            ValidationManager manager, object obj)
        {
            if (manager == null)
                throw new ArgumentNullException("manager");

            if (obj == null)
                throw new ArgumentNullException("obj");

            WriteFileActivity activity = obj as WriteFileActivity;

            if (activity == null)
                throw new
                    InvalidOperationException("obj should be a WriteFileActivity");

            if (activity.Parent != null)
            {
                ValidationErrorCollection errors = base.Validate(manager, obj);

                if (String.IsNullOrEmpty(activity.FileName))
                    errors.Add(ValidationError.GetNotSetValidationError("FileName"));

                if (String.IsNullOrEmpty(activity.FileText))
                    errors.Add(ValidationError.GetNotSetValidationError("FileText"));

                bool dirError = false;
                try 
                {
                    string fileDir = Path.GetDirectoryName(activity.FileName);
                    dirError = !Directory.Exists(fileDir);
                }
                catch { dirError = true; }

                if (dirError)
                {
                    errors.Add(new ValidationError(
                        "Directory for FileName is not valid or does not exist",
                        3,
                        false,
                        "FileName"));
                }

                if (Path.GetExtension(activity.FileName) != ".txt")
                    errors.Add(new ValidationError(
                        "This activity only supports .txt files!",
                        4,
                        false,
                        "FileName"));

                return errors;
            }
            else
            {
                return new ValidationErrorCollection();
            }
        }
    }
}

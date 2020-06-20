using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IFileUploader
    {
        Task<bool> UploadFileAsync(string fileName, Stream storageStream);
    }
}

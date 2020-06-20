using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Categories.Commands.AddCategoryCommand
{
    public class AddCategoryCommandHandler:IRequestHandler<AddCategoryCommand,bool>
    {
        private readonly IExpenseContext _context;
        private readonly IFileUploader _fileUploader;

        public AddCategoryCommandHandler(IExpenseContext context, IFileUploader fileUploader)
        {
            _context = context;
            _fileUploader = fileUploader;
        }
        public async Task<bool> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {

            var entity = new Category()
            {
                Description = request.Description,
                Image = getBytesFromImage(request.ImageFile)
            };

            _context.Categories.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            await uploadImage(request.ImageFile,entity.CategoryId);

            return true;
        }

        private byte[] getBytesFromImage(IFormFile imgFile)
        {
            byte[] imgBytes;
            using (var mStream = new MemoryStream())
            {
                mStream.CopyTo(imgFile.OpenReadStream());
                imgBytes = mStream.ToArray();
            }

            return imgBytes;
        }

        private async Task uploadImage(IFormFile file, int id)
        {
            if (file!= null)
            {
                var fileName = !string.IsNullOrEmpty(file.FileName) ? Path.GetFileName(file.FileName) : file.FileName;
                var filePath = $"{id}/{fileName}";
                try
                {
                    using (var readStream = file.OpenReadStream())
                    {
                        var result = await _fileUploader.UploadFileAsync(filePath, readStream);

                        if(!result)
                            throw new Exception("Could not upload the image to file repository. Please see the logs for details.");
                    }

                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        var bytes = ms.ToArray();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}

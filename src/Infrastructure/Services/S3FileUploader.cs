using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using Application.Common.Interfaces;
using Application.Common.Models;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services
{
    public class S3FileUploader:IFileUploader
    {
        private readonly S3Settings _s3Settings;
        public S3FileUploader(S3Settings s3Settings)
        {
            _s3Settings = s3Settings;
        }
        public async Task<bool> UploadFileAsync(string fileName, Stream storageStream)
        {
            if(string.IsNullOrEmpty(fileName)) throw new ArgumentException("Filename must be especified");

            var bucketName = _s3Settings.ImageBucket;

            using (var client = new AmazonS3Client())
            {
                if (storageStream.Length>0)
                    if (storageStream.CanSeek)
                        storageStream.Seek(0, SeekOrigin.Begin);
                var request = new PutObjectRequest()
                {
                    AutoCloseStream = true,
                    BucketName = bucketName,
                    InputStream = storageStream,
                    Key = fileName
                };

                var response = await client.PutObjectAsync(request);

                return response.HttpStatusCode == HttpStatusCode.OK;
            }
        }
    }
}

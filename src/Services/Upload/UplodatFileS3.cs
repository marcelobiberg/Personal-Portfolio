using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolio.Services.Upload
{
    public class UplodatFileS3
    {
        public async Task UploadFileToS3(IFormFile file)
        {
            using (var client = new AmazonS3Client("ASIAUMDIRDA44BKH3D5V", "HClz97bFcQk0Hza5bkaf1g7FhOpmFPEEQ4H25gvi", RegionEndpoint.USEast1))
            {
                using (var newMemoryStream = new MemoryStream())
                {
                    file.CopyTo(newMemoryStream);

                    var uploadRequest = new TransferUtilityUploadRequest
                    {
                        InputStream = newMemoryStream,
                        Key = file.FileName,
                        BucketName = "bukectmyportfolio",
                        CannedACL = S3CannedACL.PublicRead
                    };

                    var fileTransferUtility = new TransferUtility(client);
                    await fileTransferUtility.UploadAsync(uploadRequest);
                }
            }
        }
    }
}

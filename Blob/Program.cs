using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blob
{
    class Program
    {
        static void Main(string[] args)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse
   ("DefaultEndpointsProtocol=https;AccountName=aayazokulu;AccountKey=vcGOIzfmMjrj+lEBE+MADWNHYlR8MyFHChD2/0OSqmWDUzvaYt1G1CIBz9BhM9azTxftEH4KalvUpbgwn1IF8w==");

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            CloudBlobContainer container = blobClient.GetContainerReference("animals");

            container.CreateIfNotExists();

            CloudBlockBlob blockBlob = container.GetBlockBlobReference("zebra.jpg");
           

         
            var sas = blockBlob.GetSharedAccessSignature(new SharedAccessBlobPolicy()
            {
                Permissions = SharedAccessBlobPermissions.Read,
                SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(15),
            });
            Console.WriteLine(blockBlob.Uri + sas);
            Console.ReadLine();

        }
    }
}

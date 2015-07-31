using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Queue;
using System.Threading;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=aayazokulu;AccountKey=vcGOIzfmMjrj+lEBE+MADWNHYlR8MyFHChD2/0OSqmWDUzvaYt1G1CIBz9BhM9azTxftEH4KalvUpbgwn1IF8w==");
            // Create the queue client
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            // Retrieve a reference to a queue
            CloudQueue queue = queueClient.GetQueueReference("myqueue");

            // Create the queue if it doesn't already exist
            queue.CreateIfNotExists();

            for (int i = 9000; i < 100000; i++)
            {
                string s = "Hello, World " + i.ToString();
                Console.WriteLine(s);
                // Create a message and add it to the queue.
                CloudQueueMessage message = new CloudQueueMessage(s);
                queue.AddMessage(message);
                Thread.Sleep(100);
            }

        }
    }
}

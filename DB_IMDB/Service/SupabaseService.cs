using Supabase;
using Supabase.Storage;
using System;
using System.IO;

namespace DB_IMDB.Service
{
    public class SupabaseService
    {
        private readonly Supabase.Client _client;
        private readonly string _bucketName = "posters";

        public SupabaseService(string supabaseUrl, string supabaseKey)
        {
            var options = new SupabaseOptions
            {
                AutoConnectRealtime = false
            };

            _client = new Supabase.Client(supabaseUrl, supabaseKey, options);

           
            _client.InitializeAsync().GetAwaiter().GetResult();
        }

        public string UploadPoster(string filePath, string fileName)
        {
            var bucket = _client.Storage.From(_bucketName);

           
            byte[] fileBytes = File.ReadAllBytes(filePath);

          
            var result = bucket
                .Upload(fileBytes, fileName, new Supabase.Storage.FileOptions
                {
                    CacheControl = "3600",
                    Upsert = true
                })
                .GetAwaiter()
                .GetResult();

            if (result == null)
                throw new Exception("Upload failed.");

            return bucket.GetPublicUrl(fileName);
        }
    }
}

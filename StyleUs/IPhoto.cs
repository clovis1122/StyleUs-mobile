using System;
using System.IO;
using System.Threading.Tasks;

namespace StyleUs
{
    public interface IPhoto
    {
        Task<Stream> GetPhoto(string path);
    }
}

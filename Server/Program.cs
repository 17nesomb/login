using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to InstaOunce's most new bestest amazingest Server");

            //Create a HTTP server that listens on port 80
            const int port = 8080;
            string prefix = $"http://localhost:{port}/";


            Console.WriteLine("Listening...");
            HttpListener server = new HttpListener();

            server.Prefixes.Add(prefix);
            server.Start();

            while (true)
            {
                HttpListenerContext context = server.GetContext();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;

                string html = $"";


                
                Console.WriteLine($"Request:'{request.RawUrl}'");

                switch(request.RawUrl){

                    case "/":
                        html = File.ReadAllText($"W:/008. Computing/Student work/2022-2023/Y12/Ben Nesom/Login Page/Server/static/index.html");
                        break;

                    default:
                        Console.WriteLine($"Unknown URL {request.RawUrl}");
                        string path = "../../static" + request.RawUrl;
                        if(File.Exists(path))
                        {
                            html = File.ReadAllText(path);
                        }

                        else
                        {
                            response.StatusCode = 404;
                            html = "Sorry - file not found";
                            Console.WriteLine($"Unknown URL: {request.RawUrl}");
                        }
                        break;
                }

                byte[] buffer = Encoding.UTF8.GetBytes(html);
                Console.WriteLine(buffer.Length);
                response.ContentLength64 = buffer.Length;
                response.OutputStream.Write(buffer,0, buffer.Length);
                response.OutputStream.Close();
            }
            
        }
    }
}

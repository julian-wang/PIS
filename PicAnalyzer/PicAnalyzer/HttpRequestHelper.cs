using System;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace PicAnalyzer
{
    class HttpRequestHelper
    {
        public static string httpGET(string url, int timeOut, string encoding, out int status)
        {
            HttpWebRequest webRequst = (HttpWebRequest)WebRequest.Create(url);
            webRequst.Method = "GET";
            webRequst.Timeout = timeOut;
            HttpWebResponse webResp = (HttpWebResponse)webRequst.GetResponse();
            StreamReader sr = new StreamReader(webResp.GetResponseStream(), System.Text.Encoding.GetEncoding(encoding));
            status = (int)webResp.StatusCode;
            string result = sr.ReadToEnd();
            result = result.Replace("\r", "").Replace("\n", "").Replace("\t", "");
            sr.Close();
            return result;
        }

        public static string httpPOST(string url, int timeOut, string encoding, string fileKeyName,
                                    string filePath, NameValueCollection stringDict, out int status)
        {
            string responseContent = "";
            var memStream = new MemoryStream();
            var webRequest = (HttpWebRequest)WebRequest.Create(url);
            // 边界符
            var boundary = "---------------" + DateTime.Now.Ticks.ToString("x");
            // 边界符
            var beginBoundary = Encoding.ASCII.GetBytes("--" + boundary + "\r\n");
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            // 最后的结束符
            var endBoundary = Encoding.ASCII.GetBytes("--" + boundary + "--\r\n");

            // 设置属性
            webRequest.Method = "POST";
            webRequest.Timeout = timeOut;
            webRequest.ContentType = "multipart/form-data; boundary=" + boundary;

            // 写入文件
            const string filePartHeader =
                "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\n" +
                 "Content-Type: application/octet-stream\r\n\r\n";
            var header = string.Format(filePartHeader, fileKeyName, filePath);
            var headerbytes = Encoding.UTF8.GetBytes(header);

            memStream.Write(beginBoundary, 0, beginBoundary.Length);
            memStream.Write(headerbytes, 0, headerbytes.Length);

            var buffer = new byte[1024];
            int bytesRead; // =0

            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                memStream.Write(buffer, 0, bytesRead);
            }

            // 写入字符串的Key
            var stringKeyHeader = "\r\n--" + boundary +
                                   "\r\nContent-Disposition: form-data; name=\"{0}\"" +
                                   "\r\n\r\n{1}\r\n";

            foreach (byte[] formitembytes in from string key in stringDict.Keys
                                             select string.Format(stringKeyHeader, key, stringDict[key])
                                                 into formitem
                                                 select Encoding.UTF8.GetBytes(formitem))
            {
                memStream.Write(formitembytes, 0, formitembytes.Length);
            }

            // 写入最后的结束边界符
            memStream.Write(endBoundary, 0, endBoundary.Length);

            webRequest.ContentLength = memStream.Length;

            var requestStream = webRequest.GetRequestStream();

            memStream.Position = 0;
            var tempBuffer = new byte[memStream.Length];
            memStream.Read(tempBuffer, 0, tempBuffer.Length);
            memStream.Close();

            requestStream.Write(tempBuffer, 0, tempBuffer.Length);
            requestStream.Close();

            try { 
                var httpWebResponse = (HttpWebResponse)webRequest.GetResponse();
                status = (int)httpWebResponse.StatusCode;

                using (var httpStreamReader = new StreamReader(httpWebResponse.GetResponseStream(),
                                                                Encoding.GetEncoding(encoding)))
                {
                    responseContent = httpStreamReader.ReadToEnd();
                }
                httpWebResponse.Close();
            }
            finally
            {
                fileStream.Close();
                webRequest.Abort();
            }
           
            return responseContent;
        }
    }
}
